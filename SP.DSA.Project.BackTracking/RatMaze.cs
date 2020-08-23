using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BackTracking
{
    public class RatMaze
    {
        public static void RatMazeDemo()
        {
            int[][] maze = new int[4][];
            maze[0] = new int[] { 1, 0, 0, 0 };
            maze[1] = new int[] { 1, 1, 0, 1 };
            maze[2] = new int[] { 0, 1, 0, 0 };
            maze[3] = new int[] { 1, 1, 1, 1 };

            int[][] Solution = new int[4][];
            Solution[0] = new int[] { 0, 0, 0, 0 };
            Solution[1] = new int[] { 0, 0, 0, 0 };
            Solution[2] = new int[] { 0, 0, 0, 0 };
            Solution[3] = new int[] { 0, 0, 0, 0 };


            Console.WriteLine("Input");
            for (int i = 0; i < maze.Length; i++)
            {
                Console.WriteLine(string.Join(", ", maze[i]));
            }
            Console.WriteLine(" is path found :" + IsValidMazeDemo(maze));

            Console.WriteLine("Output");
            for (int i = 0; i < maze.Length; i++)
            {
                Console.WriteLine(string.Join(", ", maze[i]));
            }
            Console.WriteLine();
            for (int i = 0; i < maze.Length; i++)
            {
                Console.WriteLine(string.Join(", ", Solution[i]));
            }
        }

        public static bool IsValidMazeDemo(int[][] maze)
        {
            return MazeHelper(maze, 0, 0, maze.Length, maze[0].Length);
        }

        private static bool MazeHelper(int[][] maze, int i, int j, int rows, int cols)
        {
            if (i == rows - 1 && j == cols - 1 && maze[i][j] == 1) return true;
            if (isSafe(maze, i, j, rows, cols))
            {
                maze[i][j] = 2;
                if (MazeHelper(maze, i + 1, j, rows, cols))
                    return true;
                else if (MazeHelper(maze, i, j + 1, rows, cols))
                    return true;
                maze[i][j] = 1;
            }
            return false;
        }

        private static bool isSafe(int[][] maze, int i, int j, int rows, int cols)
        {
            return i >= 0 && j >= 0 && i < rows && j < cols && maze[i][j] == 1;
        }

        private static bool IsValidMaze(int[][] maze, int[][] solution)
        {
            if (SolveMazeHelper(0, 0, maze, solution) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool SolveMazeHelper(int i, int j, int[][] maze, int[][] solution)
        {
            if (i == maze.Length - 1 && j == maze.Length - 1)
            {
                solution[i][j] = 1;
                maze[i][j] = 2;
                return true;
            }
            if (IsValidEntry(i, j, maze))
            {
                solution[i][j] = 1;
                maze[i][j] = 2;
                if (SolveMazeHelper(i + 1, j, maze, solution))
                    return true;
                else if (SolveMazeHelper(i, j + 1, maze, solution))
                    return true;
                solution[i][j] = 0;
            }
            return false;
        }

        private static bool IsValidEntry(int i, int j, int[][] maze)
        {
            return i < maze.Length && j < maze.Length && maze[i][j] == 1;
        }
    }
}
