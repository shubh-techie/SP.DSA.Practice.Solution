using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class SubsetSumProblem
    {
        public static void SubsetSumProblemDemo()
        {
            int[] arr = { 3, 34, 4, 12, 5, 2 };
            int sum = 30;
            bool isPresent = IsSubSetPresent(arr, arr.Length, sum);
            Console.WriteLine("isPresent :" + isPresent);
            isPresent = IsSubSetPresentBT(arr, arr.Length, sum);
            Console.WriteLine("Bottom up isPresent :" + isPresent);
        }

        private static bool IsSubSetPresentBT(int[] sets, int n, int sum)
        {
            bool[,] table = new bool[n + 1, sum + 1];
            for (int i = 0; i < n + 1; i++)
            {
                table[i, 0] = true;
            }
            PrintTable(table);

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < sum + 1; j++)
                {
                    if (sets[i - 1] > j)
                    {
                        table[i, j] = table[i - 1, j];
                    }
                    else
                        table[i, j] = table[i - 1, j - sets[i - 1]] || table[i - 1, j];
                }
            }
            Console.WriteLine();
            PrintTable(table);
            return table[n, sum];
        }

        private static void PrintTable(bool[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsSubSetPresent(int[] sets, int n, int sum)
        {
            if (sum == 0) return true;
            if (n == 0 && sum != 0) return false;

            if (sets[n - 1] > sum)
                return IsSubSetPresent(sets, n - 1, sum);
            else
                return IsSubSetPresent(sets, n - 1, sum - sets[n - 1]) || IsSubSetPresent(sets, n - 1, sum);
        }
    }
}
