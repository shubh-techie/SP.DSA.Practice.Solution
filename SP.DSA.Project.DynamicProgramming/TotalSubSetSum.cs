using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class TotalSubSetSum
    {
        public static void TotalSubSetSumDemo()
        {
            int[] arr = { 1, 2, 3, 3 };
            int sum = 6;
            int count = GetTotalNumberOfSubsetBT(arr, sum, arr.Length);
            Console.WriteLine("Count :" + count);


            count = GetTotalNumberOfSubset(arr, sum, arr.Length);
            Console.WriteLine("Count Recursion :" + count);
        }

        private static int GetTotalNumberOfSubsetBT(int[] arr, int sum, int n)
        {
            int[,] table = new int[n + 1, sum + 1];
            for (int i = 0; i < n + 1; i++)
            {
                table[i, 0] = 1;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < sum + 1; j++)
                {
                    if (arr[i - 1] > j)
                    {
                        table[i, j] = table[i - 1, j];
                    }
                    else
                    {
                        table[i, j] = table[i - 1, j - arr[i - 1]] + table[i - 1, j];
                    }
                }
            }

            return table[n, sum];
        }

        private static int GetTotalNumberOfSubset(int[] arr, int sum, int n)
        {
            if (n == 0)
            {
                return sum == 0 ? 1 : 0;
            }

            if (arr[n - 1] > sum)
                return GetTotalNumberOfSubset(arr, sum, n - 1);
            else
                return GetTotalNumberOfSubset(arr, sum - arr[n - 1], n - 1) + GetTotalNumberOfSubset(arr, sum, n - 1);
        }
    }
}
