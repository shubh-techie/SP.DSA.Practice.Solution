using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques694NumberDistinctIslands
    {
        public static void Demo()
        {
            int[][] grid = new int[][] { new int[] { 1, 1, 0, 1, 1 }, new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 1 }, new int[] { 1, 1, 0, 1, 1 } }; ;
            Console.WriteLine("NumDistinctIslands :" + NumDistinctIslands(grid));
        }

        public static int NumDistinctIslands(int[][] grid)
        {
            HashSet<string> set = new HashSet<string>();
            int rows = grid.Length, cols = grid[0].Length;
            bool[,] visisted = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1 && visisted[i, j] != true)
                    {
                        StringBuilder sb = new StringBuilder();
                        DFSHelper(grid, visisted, i, j, rows, cols, sb, "O");
                        if (!set.Contains(sb.ToString()))
                        {
                            set.Add(sb.ToString());
                        }
                    }
                }
            }

            return set.Count;
        }

        private static void DFSHelper(int[][] grid, bool[,] visisted, int i, int j, int rows, int cols, StringBuilder sb, string direction)
        {
            if (i < 0 || j < 0 || i >= rows || j >= cols || visisted[i, j] == true || grid[i][j] == 0)
                return;

            visisted[i, j] = true;
            sb.Append(direction);
            DFSHelper(grid, visisted, i - 1, j, rows, cols, sb, "U");
            DFSHelper(grid, visisted, i + 1, j, rows, cols, sb, "D");
            DFSHelper(grid, visisted, i, j - 1, rows, cols, sb, "L");
            DFSHelper(grid, visisted, i, j + 1, rows, cols, sb, "R");
            sb.Append("B");
        }
    }
}
