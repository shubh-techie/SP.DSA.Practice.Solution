using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BackTracking
{
    public class QueenProblem
    {
        public static void QueenProblemDemo()
        {
            int length = 5;

            List<List<int>> solution = new List<List<int>>(length);
            for (int i = 0; i < length; i++)
            {
                solution.Add(new List<int>() { 0, 0, 0, 0, 0 });
            }
            Console.WriteLine(isSolutionFound(length, solution));
        }

        private static bool isSolutionFound(int length, List<List<int>> solution)
        {
            return isSolutionFoundHelper(0, length, solution);
        }

        private static bool isSolutionFoundHelper(int col, int length, List<List<int>> solution)
        {
            if (col == length) return true;
            for (int i = 0; i < length; i++)
            {
                if (IsValidEntry(i, col, length))
                {
                    solution[i][col] = 1;
                    if (isSolutionFoundHelper(col + 1, length, solution))
                        return true;
                    solution[i][col] = 0;
                }
            }
            return false;
        }

        private static bool IsValidEntry(int i, int j, int length)
        {
            return true;
        }
    }
}
