using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _15PuzzleGame
{
    public partial class Board : Form
    {
        private Game game;
        private bool win = false;

        public Board()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            game = new Game();
            game.Moves = 0;
            movesLabel.Text = game.Moves.ToString();

            int[] nums = game.Randomizer();
            int i = 0;
            foreach (Button btn in gamePanel.Controls)
            {
                btn.Text = (nums[i] == 0) ? btn.Text = "" : btn.Text = nums[i].ToString();
                btn.BackColor = (btn.Text == "") ? btn.BackColor = Color.White : btn.BackColor = Color.Aqua;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Verdana", 16f);
                btn.ForeColor = Color.Red;
                i++;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "")
                return;

            Button emptyBtn = null;
            foreach (Button b in gamePanel.Controls)
            {
                if (b.Text == "")
                {
                    emptyBtn = b;
                    break;
                }
            }

            if (btn.TabIndex == emptyBtn.TabIndex - 1 || btn.TabIndex == emptyBtn.TabIndex - 4 ||
                btn.TabIndex == emptyBtn.TabIndex + 1 || btn.TabIndex == emptyBtn.TabIndex + 4)
            {
                Color tempC = emptyBtn.BackColor;
                emptyBtn.BackColor = btn.BackColor;
                btn.BackColor = tempC;
                emptyBtn.Text = btn.Text;
                btn.Text = "";
                game.Moves++;
                movesLabel.Text = game.Moves.ToString();
            }

            WinCheck();

        }

        private void WinCheck()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<int> list = new List<int>();
            int btnNum;

            foreach (Button button in gamePanel.Controls)
            {
                if (Int32.TryParse(button.Text, out btnNum))
                    list.Add(btnNum);
            }

            if (Enumerable.SequenceEqual(nums, list.ToArray()))
                win = true;

            if (win)
                MessageBox.Show("Congratulations", "Congratulations, you won the game\n" +
                    "Your score " + game.Moves, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
