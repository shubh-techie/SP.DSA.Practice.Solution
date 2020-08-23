using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques200NumberOfIslands
    {
        public static void Ques200NumberOfIslandsDemo()
        {
            int[][] grid = new[] {
                new[] {1,1,1,1,0},
                new[] {1,1,0,1,0 },
                new[] {1,1,0,0,0 },
                new[] {0,0,0,0,0 },
            };
            Console.WriteLine(NumIslands(grid));
        }

        private static int NumIslands(int[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0) return 0;
            int cols = grid[0].Length;
            bool[,] visited = new bool[rows, cols];
            int count = 0;
            int[][] cods = new[] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 } };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1 && visited[i, j] == false)
                    {
                        GetCount(grid, visited, i, j, rows, cols, cods);
                        count++;
                        PrintMatrix(visited, rows, cols);
                    }
                }
            }

            return count;
        }

        private static void PrintMatrix(bool[,] visited, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(visited[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void GetCount(int[][] grid, bool[,] visited, int i, int j, int rows, int cols, int[][] cods)
        {
            visited[i, j] = true;
            foreach (var co in cods)
            {
                int xRow = i + co[0];
                int yRow = j + co[1];
                if (IsValid(grid, visited, xRow, yRow, rows, cols))
                {
                    GetCount(grid, visited, xRow, yRow, rows, cols, cods);
                }
            }
        }

        public static bool IsValid(int[][] grid, bool[,] visited, int i, int j, int rows, int cols)
        {
            return i >= 0 && j >= 0 && i < rows && j < cols && grid[i][j] == 1 && visited[i, j] == false;
        }
    }
}
