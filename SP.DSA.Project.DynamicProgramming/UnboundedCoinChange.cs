using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class UnboundedCoinChange
    {
        public static void UnboundedCoinChangeDemo()
        {
            int[] coins = { 1, 2, 3 };
            int amount = 4;
            int count = GetNoOfWaysBT(coins, coins.Length, amount);
            Console.WriteLine("Count :" + count);


            count = GetNoOfWays(coins, coins.Length, amount);
            Console.WriteLine("Count Recursion:" + count);
        }

        private static int GetNoOfWaysBT(int[] coins, int n, int amount)
        {
            int[,] table = new int[n + 1, amount + 1];
            for (int i = 0; i < n + 1; i++)
            {
                table[i, 0] = 1;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < amount + 1; j++)
                {
                    if (coins[i - 1] > j)
                        table[i, j] = table[i - 1, j];
                    else
                        table[i, j] = table[i, j - coins[i - 1]] + table[i - 1, j];
                }
            }
            return table[n, amount];
        }

        private static int GetNoOfWays(int[] coins, int n, int amount)
        {
            if (n == 0)
                return amount == 0 ? 1 : 0;

            if (coins[n - 1] > amount)
                return GetNoOfWays(coins, n - 1, amount);
            else
                return GetNoOfWays(coins, n, amount - coins[n - 1]) + GetNoOfWays(coins, n - 1, amount);
        }
    }
}
