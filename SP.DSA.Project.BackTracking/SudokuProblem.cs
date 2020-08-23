using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BackTracking
{
    public class SudokuProblem
    {
        public static void SudokuProblemDemo()
        {
            int[][] grid = new[]
             {
                new [] { 3, 0, 6, 5, 0, 8, 4, 0, 0},
                new [] { 5, 2, 0, 0, 0, 0, 0, 0, 0},
                new [] { 0, 8, 7, 0, 0, 0, 0, 3, 1},
                new [] { 0, 0, 3, 0, 1, 0, 0, 8, 0},
                new [] { 9, 0, 0, 8, 6, 3, 0, 0, 5},
                new [] { 0, 5, 0, 0, 9, 0, 6, 0, 0},
                new [] { 1, 3, 0, 0, 0, 0, 2, 5, 0},
                new [] { 0, 0, 0, 0, 0, 0, 0, 7, 4},
                new [] { 0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            char[][] charGrid = new char[9][];

            Console.WriteLine("Can be solved:" + SolveSodoku(charGrid));
            printGrid(grid);
        }

        private static void printGrid(int[][] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grid[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool SolveSodoku(char[][] grid)
        {
            int size = grid.Length;
            return SolveSodokuHelper(grid, size);
        }

        private static bool SolveSodokuHelper(char[][] grid, int size)
        {
            int row = -1, col = -1;
            bool isEmpty = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i][j] == ' ')
                    {
                        row = i;
                        col = j;
                        isEmpty = true;
                        break;
                    }
                }
                //if (isEmpty)
                //    break;
            }

            if (!isEmpty)
                return true;

            for (int no = 1; no <= 9; no++)
            {
                char noChar = (char)no;
                if (IsSafe(grid, row, col, size, no))
                {
                    grid[row][col] = noChar;
                    if (SolveSodokuHelper(grid, size))
                        return true;
                    else
                        grid[row][col] = ' ';
                }
            }
            return false;
        }

        private static bool IsSafe(char[][] grid, int row, int col, int size, int no)
        {
            for (int k = 0; k < size; k++)
            {
                if (grid[k][col] == no || grid[row][k] == no)
                    return false;
            }

            int sqrt = (int)Math.Sqrt(size);
            int rowStart = row - row % sqrt;
            int colStart = col - col % sqrt;

            for (int p = 0; p < sqrt; p++)
            {
                for (int q = 0; q < sqrt; q++)
                {
                    if (grid[p + rowStart][q + colStart] == no)
                        return false;
                }
            }
            return true;
        }
    }
}
