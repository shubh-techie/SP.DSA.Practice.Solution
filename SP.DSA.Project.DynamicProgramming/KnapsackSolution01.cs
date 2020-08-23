using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class KnapsackSolution01
    {
        public void KnapsackSolution01Demo()
        {
            //KnapsackDemo();
            //SubsetSumProblem();
            //PartitionedIntoTwoSubsets();
            //CountSubsetSum();
            //MinimumSubsetSumDifference();
            //TotalSubSetCountIfSumDiffK();
            //TargetSum();
        }


        /// <summary>
        /// You are given a list of non-negative integers, a1, a2, ..., an, and a target, S.
        /// Find out how many ways to assign symbols to make sum of integers equal to target S.
        /// </summary>
        private void TargetSum()
        {
            int[] nums = { 1, 1, 1, 1, 1 };
            int sum = 3;
            Console.WriteLine("Total Way :" + FindTargetSumWays(nums, sum, nums.Length));
        }

        public int FindTargetSumWays(int[] nums, int sum, int n)
        {
            if (n == 0)
                return sum == 0 ? 1 : 0;
            return FindTargetSumWays(nums, sum - nums[n - 1], n - 1) + FindTargetSumWays(nums, sum + nums[n - 1], n - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        private void TotalSubSetCountIfSumDiffK()
        {
            int[] sets = { 1, 1, 2, 3 };
            int diff = 1;
            Console.WriteLine("Total Count :" + GetTotalSubSetCountIfSumDiffK(sets, diff, sets.Length));
        }

        private int GetTotalSubSetCountIfSumDiffK(int[] sets, int diff, int length)
        {
            int totalSum = Common.GetSum(sets);
            int sumS1 = (totalSum - diff) / 2;
            int count = GetSubsetCount(sets, sumS1, sets.Length);
            return count;
        }

        /// <summary>
        /// Partition a set into two subsets such that the difference of subset sums is minimum
        /// </summary>
        private void MinimumSubsetSumDifference()
        {
            int[] sets = { 1, 6, 11, 5 };
            int totalSum = GetSum(sets);
            Console.WriteLine("Min sum diff : " + GetMinSetsDiffBottomUP(sets, totalSum, 0, sets.Length));
        }

        private int GetMinSetsDiffBottomUP(int[] sets, int totalSum, int currSum, int n)
        {
            bool[,] dp = new bool[n + 1, totalSum + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = true;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= totalSum; s++)
                {
                    if (sets[i - 1] > s)
                        dp[i, s] = dp[i - 1, s];
                    else
                        dp[i, s] = dp[i - 1, s - sets[i - 1]] || dp[i - 1, s];
                }
            }

            Common.PrintBoolMatrix(dp);

            List<int> setSum = new List<int>();
            for (int j = 0; j <= totalSum / 2; j++)
            {
                if (dp[n, j] == true)
                {
                    setSum.Add(j);
                }
            }
            int minDiff = int.MaxValue;
            foreach (var item in setSum)
            {
                minDiff = Math.Min(minDiff, totalSum - 2 * item);
            }
            return minDiff;
        }


        private int GetMinSetsDiff(int[] sets, int totalSum, int currSum, int n)
        {
            if (n == 0)
                return Math.Abs((totalSum - currSum) - currSum);
            return Math.Min(GetMinSetsDiff(sets, totalSum, currSum + sets[n - 1], n - 1), GetMinSetsDiff(sets, totalSum, currSum, n - 1));
        }




        /// <summary>
        /// Count of subsets with sum equal to X
        /// </summary>
        private void CountSubsetSum()
        {
            int[] arr = { 1, 2, 3, 3 };
            int sum = 6;
            Console.WriteLine(GetSubsetCount(arr, sum, arr.Length));
        }

        private int GetSubsetCount(int[] set, int sum, int n)
        {
            int[,] dp = new int[n + 1, sum + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= sum; s++)
                {
                    if (set[i - 1] > s)
                        dp[i, s] = dp[i - 1, s];
                    else
                        dp[i, s] = dp[i - 1, s - set[i - 1]] + dp[i - 1, s];
                }
            }
            return dp[n, sum];
        }



        /// <summary>
        /// Partition problem is to determine whether a given set can be partitioned into two subsets such that the sum of elements in both subsets is same.
        /// </summary>
        private void PartitionedIntoTwoSubsets()
        {
            int[] arr = { 2, 5, 3 };
            int n = arr.Length;
            if (HasPartitionSets(arr, n) == true)
                Console.Write("Subset Found");
            else
                Console.Write("Subset Not Found");
        }

        private bool HasPartitionSets(int[] arr, int n)
        {
            int totalSum = GetSum(arr);
            if (totalSum % 2 != 0) return false;
            return HasEqualPartionSum(arr, totalSum / 2, n);
        }

        private bool HasEqualPartionSum(int[] set, int sum, int n)
        {
            bool[,] table = new bool[n + 1, sum + 1];
            for (int i = 0; i <= n; i++)
            {
                table[i, 0] = true;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= sum; s++)
                {
                    if (set[i - 1] > s)
                        table[i, s] = table[i - 1, s];
                    else
                        table[i, s] = table[i - 1, s - set[i - 1]] || table[i - 1, s];
                }
            }
            return table[n, sum];
        }

        private int GetSum(int[] arr)
        {
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            return sum;
        }

        /// <summary>
        /// subset sum problem
        /// </summary>
        private void SubsetSumProblem()
        {
            int[] sets = { 3, 34, 4, 12, 5, 2 };
            int sum = 16;
            int n = sets.Length;
            if (HasSubsetSumBottomUP(sets, n, sum) == true)
                Console.WriteLine("Found");
            else
                Console.WriteLine("Not Found");
        }

        private bool HasSubsetSumBottomUP(int[] set, int n, int sum)
        {
            bool[,] setTable = new bool[n + 1, sum + 1];

            for (int i = 0; i <= n; i++)
            {
                setTable[i, 0] = true;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= sum; s++)
                {
                    if (set[i - 1] > s)
                        setTable[i, s] = setTable[i - 1, s];
                    else
                        setTable[i, s] = setTable[i - 1, s - set[i - 1]] || setTable[i - 1, s];
                }
            }

            return setTable[n, sum];
        }

        private bool HasSubsetSum(int[] set, int n, int sum)
        {
            if (sum == 0) return true;
            if (n == 0 && sum != 0)
                return false;

            if (set[n - 1] > sum)
                HasSubsetSum(set, n - 1, sum);
            return HasSubsetSum(set, n - 1, sum - set[n - 1]) || HasSubsetSum(set, n - 1, sum);
        }



        /// <summary>
        /// /
        /// </summary>
        private void KnapsackDemo()
        {
            int[] values = new int[] { 60, 100, 120 };
            int[] weights = new int[] { 10, 20, 30 };
            int capacity = 50;
            int n = weights.Length;
            Console.WriteLine("Max values set: " + GetKnapsackMaxTopDown(weights, values, capacity, n));
        }

        private int GetKnapsackMaxTopDown(int[] weights, int[] values, int bagWeight, int size)
        {
            int[,] dp = new int[size + 1, bagWeight + 1];

            for (int i = 0; i <= size; i++)
            {
                for (int w = 0; w <= bagWeight; w++)
                {
                    if (i == 0 || w == 0)
                        dp[i, w] = 0;
                    else if (weights[i - 1] > w)
                        dp[i, w] = dp[i - 1, w];
                    else
                        dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                }
            }
            //Common.PrintMatrix(dp);
            return dp[size, bagWeight];
        }

        private int GetKnapsackMax(int[] weights, int[] values, int capacity, int n)
        {
            if (n == 0 || capacity == 0)
                return 0;

            if (weights[n - 1] > capacity)
                GetKnapsackMax(weights, values, capacity, n - 1);
            return Math.Max(values[n - 1] + GetKnapsackMax(weights, values, capacity - weights[n - 1], n - 1), GetKnapsackMax(weights, values, capacity, n - 1));
        }


    }
}
