using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class MinimumCoins
    {
        public static void MinimumCoinsDemo()
        {
            int[] arr = { 3, 4, 5 };
            int sum = 1;
            int count = GetMinCoinsCount(arr, arr.Length, sum);
            if (count == -1)
            {
                Console.WriteLine("Not Possible");
            }
            else
            {
                Console.WriteLine("MinimumCoins count :" + count);
            }
        }

        private static int GetMinCoinsCount(int[] coins, int n, int sum)
        {
            int[] table = new int[sum + 1];
            table[0] = 0;
            for (int i = 1; i < sum + 1; i++)
            {
                table[i] = int.MaxValue - 1;
            }

            for (int i = 1; i < sum + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (coins[j] <= i)
                    {
                        table[i] = Math.Min(table[i], 1 + table[i - coins[j]]);
                    }
                }
            }

            return table[sum] > sum ? -1 : table[sum];
        }

        private static int GetMinimumCountRecursion(int[] coins, int n, int sum)
        {
            if (sum == 0) return 0;

            int result = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (coins[i] <= sum)
                {
                    result = Math.Min(result, 1 + GetMinimumCountRecursion(coins, n, sum - coins[i]));
                    //if (currResult != int.MaxValue)
                    //{
                    //    result = Math.Min(result, currResult + 1);
                    //}
                }
            }

            return result;
        }

        private static int GetMinimumCount(int[] arr, int n, int sum)
        {
            if (n == 0)
            {
                return sum == 0 ? 1 : int.MaxValue;
            }

            if (arr[n - 1] > sum)
                return GetMinimumCount(arr, n - 1, sum);
            else
                return Math.Min(1 + GetMinimumCount(arr, n, sum - arr[n - 1]), GetMinimumCount(arr, n - 1, sum));
        }
    }
}
