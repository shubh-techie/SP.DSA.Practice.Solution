using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class CoinChange
    {
        public static void CoinChangeDemo()
        {
            int[] arr = { 1, 2, 5 };
            int sum = 11;
            int count = GetCount(arr, sum);
            Console.WriteLine("Count :" + count);
        }

        private static int GetCount(int[] arr, int sum)
        {
            if (arr.Length == 0 || sum == 0) return 0;
            // return GetCountHelper(arr, arr.Length, sum);
            return 0;
        }

        private static int GetCountHelperDP(int[] coins, int n, int sum)
        {
            int[,] dp = new int[sum + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 1; i <= sum; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = dp[i, j - 1];
                    if (coins[j - 1] <= i)
                    {
                        dp[i, j] += dp[i - coins[j - 1], i];
                    }
                }
            }
            return dp[sum, n];
        }


    }
}
