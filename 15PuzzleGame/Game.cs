using System;

namespace _15PuzzleGame
{
    class Game
    {
        private const int boardSize = 16;
        private int moves = 0;

        public int GetBoardSize => boardSize;

        public int Moves 
        {
            get { return moves; }
            set { moves = value; }
        }

        public int[] Randomizer()
        {
            int[] nums = new int[16];
            Random r = new Random();
            int num = 0;
            bool isUnique = true;

            for (int i = 1; i < nums.Length; i++)
            {
                num = r.Next(1, 16);
                for (int j = 1; j < i; j++)
                {
                    if (nums[j] == num)
                    {
                        isUnique = false;
                        j = -1;
                        num = r.Next(1, 16);
                        continue;
                    }
                    else
                    {
                        isUnique = true;
                    }
                }
                if (isUnique)
                    nums[i] = num;
            }

            return nums;
        }
    }
}
