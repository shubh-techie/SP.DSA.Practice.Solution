using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class KnapsackUnbounded
    {
        public void KnapsackUnboundedDemoSolution()
        {
            //UnboundedKnapsack();
            //RodCuttingProblem();
            //MaximumWayCoinChangeUnbounded();
            MinimumWayCoinChangeUnbounded();
        }

        /// <summary>
        /// 
        /// </summary>
        private void MinimumWayCoinChangeUnbounded()
        {
            int[] coins = { 6, 5, 1, 9 };
            int n = coins.Length;
            int sum = 11;
            Console.Write("Minimum coins required is " +
                                 GetMinimumCountBottomUP(coins, sum, n));
        }

        private int GetMinimumCountBottomUP(int[] coins, int sum, int n)
        {
            int[] cache = new int[sum + 1];
            cache[0] = 0;

            for (int i = 1; i <= sum; i++)
            {
                cache[i] = int.MaxValue - 1;
            }

            for (int s = 1; s <= sum; s++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (coins[i] <= s)
                    {
                        cache[s] = Math.Min(cache[s], 1 + cache[s - coins[i]]);
                    }
                }
                Console.WriteLine(string.Join(" ", cache));
            }
            return cache[sum] > sum ? -1 : cache[sum];
        }



        private static int GetMinimumCount(int[] coins, int sum, int n)
        {
            if (sum == 0)
                return 0;
            else
            {
                int result = int.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (coins[i] <= sum)
                    {
                        result = Math.Min(result, 1 + GetMinimumCount(coins, sum - coins[i], n));
                    }
                }
                return result;
            }
        }


        /// <summary>
        /// Coin Change | DP-7 Given a value N, if we want to make change for N cents, and we have infinite supply of each of S = { S1, S2, .. , Sm}
        /// </summary>
        private void MaximumWayCoinChangeUnbounded()
        {
            int[] coins = { 2, 5, 3, 6 };
            int sum = 10;
            Console.WriteLine("Maximum no of ways :" + GetMaximumOfWayCoinsBottomUP(coins, sum, coins.Length));

            coins = new int[] { 25, 10, 5 };
            sum = 30;
            Console.WriteLine("Maximum no of ways :" + GetMaximumOfWayCoinsBottomUP(coins, sum, coins.Length));

        }

        private int GetMaximumOfWayCoinsBottomUP(int[] coins, int sum, int n)
        {
            int[,] cache = new int[sum + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                cache[0, i] = 1;
            }

            for (int s = 1; s <= sum; s++)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (coins[i - 1] > s)
                    {
                        cache[s, i] = cache[s, i - 1];
                    }
                    else
                    {
                        cache[s, i] = cache[s - coins[i - 1], i] + cache[s, i - 1];
                    }
                }
            }
            Common.PrintMatrix(cache);
            return cache[sum, n];
        }

        private int GetMaximumOfWayCoins(int[] coins, int sum, int n)
        {
            if (sum == 0)
                return 1;
            if (n == 0 && sum != 0)
                return 0;

            if (coins[n - 1] > sum)
                return GetMaximumOfWayCoins(coins, sum, n - 1);
            else
                return GetMaximumOfWayCoins(coins, sum - coins[n - 1], n) + GetMaximumOfWayCoins(coins, sum, n - 1);
        }

        /// <summary>
        /// Cutting a Rod , rod Length is bag capacity,
        /// lengths : all different combination of rods 1-8
        /// n is the size of the arrray
        /// </summary>
        private void RodCuttingProblem()
        {
            int[] lengths = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
            int n = prices.Length;
            Console.WriteLine("Maximum Profit :" + GetMaxObtainValueBottomUP(lengths, prices, n, n));

            prices = new int[] { 3, 5, 8, 9, 10, 17, 17, 20 };
            Console.WriteLine("Maximum Profit :" + GetMaxObtainValueBottomUP(lengths, prices, n, n));
        }

        private int GetMaxObtainValueBottomUP(int[] lengths, int[] prices, int rodLength, int n)
        {
            int[,] cache = new int[rodLength + 1, n + 1];

            for (int len = 0; len <= rodLength; len++)
            {
                for (int i = 0; i <= n; i++)
                {
                    if (len == 0 || i == 0)
                    {
                        cache[len, i] = 0;
                    }
                    else if (lengths[i - 1] > len)
                    {
                        cache[len, i] = cache[len, i - 1];
                    }
                    else
                    {
                        cache[len, i] = Math.Max(prices[i - 1] + cache[len - lengths[i - 1], i], cache[len, i - 1]);
                    }
                }
            }
            Common.PrintMatrix(cache);
            return cache[rodLength, n];
        }

        private int GetMaxObtainValue(int[] lengths, int[] prices, int rodLength, int n)
        {
            if (n == 0 || rodLength == 0)
                return 0;

            if (lengths[n - 1] > rodLength)
                return GetMaxObtainValue(lengths, prices, rodLength, n - 1);
            else
                return Math.Max(prices[n - 1] + GetMaxObtainValue(lengths, prices, rodLength - lengths[n - 1], n), GetMaxObtainValue(lengths, prices, rodLength, n - 1));
        }


        /// <summary>
        /// 
        /// </summary>
        private void UnboundedKnapsack()
        {
            int[] values = { 10, 40, 50, 70 };
            int[] weights = { 1, 3, 4, 5 };
            int bagWeight = 8;
            Console.WriteLine("Maximum values in the bag" + GetKnapsackMaxBottomUP(weights, values, bagWeight, weights.Length));
        }
        private int GetKnapsackMaxBottomUP(int[] weights, int[] values, int bagWeight, int n)
        {
            int[,] cache = new int[n + 1, bagWeight + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= bagWeight; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        cache[i, w] = 0;
                    }
                    else if (weights[i - 1] > w)
                    {
                        cache[i, w] = cache[i - 1, w];
                    }
                    else
                    {
                        cache[i, w] = Math.Max(values[i - 1] + cache[i, w - weights[i - 1]], cache[i - 1, w]);
                    }
                }
            }

            return cache[n, bagWeight];
        }

        private int GetKnapsackMaxRecursion(int[] weights, int[] values, int bagWeight, int n)
        {
            if (bagWeight == 0 || n == 0) return 0;

            if (weights[n - 1] > bagWeight)
                return GetKnapsackMaxRecursion(weights, values, bagWeight, n - 1);
            else
                return Math.Max(values[n - 1] + GetKnapsackMaxRecursion(weights, values, bagWeight - weights[n - 1], n), GetKnapsackMaxRecursion(weights, values, bagWeight, n - 1));
        }
    }
}
