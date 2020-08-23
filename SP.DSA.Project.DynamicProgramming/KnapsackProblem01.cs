using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class KnapsackProblem01
    {
        public static void KnapsackProblem01Demo()
        {
            int[] values = new int[] { 60, 100, 120 };
            int[] weights = new int[] { 10, 20, 30 };
            int capacity = 50;
            int n = weights.Length;
            int[,] cache = new int[n + 1, capacity + 1];
            int maxValuesTB = GetMaxKnapsackValues(weights, values, capacity, n, cache);
            Console.WriteLine("max values memoization maxValuesTB:" + maxValuesTB);


            int[,] table = new int[n + 1, capacity + 1];
            int maxValuesBT = GetMaxKnapsackBottomUP(weights, values, capacity, n, cache);
            Console.WriteLine("max values tabulation maxValuesBT:" + maxValuesBT);
        }

        private static int GetMaxKnapsackBottomUP(int[] weights, int[] values, int bagWeight, int size, int[,] table)
        {
            if (size == 0 || bagWeight == 0) return table[0, 0];
            int i = 0, j = 0;
            for (i = 0; i <= size; i++)
            {
                for (j = 0; j <= bagWeight; j++)
                {
                    if (i == 0 || j == 0)
                        table[i, j] = 0;
                    else if (weights[i - 1] <= j)
                    {
                        table[i, j] = Math.Max(values[i - 1] + table[i - 1, j - weights[i - 1]], table[i - 1, j]);
                    }
                    else
                    {
                        table[i, j] = table[i - 1, j];
                    }
                }
                Console.WriteLine();
            }
            return table[size, bagWeight];
        }

        private static int GetMaxKnapsackValues(int[] weights, int[] values, int capacity, int n, int[,] cache)
        {
            if (n == 0 || capacity == 0) return cache[0, 0];

            if (cache[n, capacity] != 0)
                return cache[n, capacity];

            if (weights[n - 1] > capacity)
                cache[n, capacity] = GetMaxKnapsackValues(weights, values, capacity, n - 1, cache);
            else
                cache[n, capacity] = Math.Max(values[n - 1] + GetMaxKnapsackValues(weights, values, capacity - weights[n - 1], n - 1, cache), GetMaxKnapsackValues(weights, values, capacity, n - 1, cache));

            return cache[n, capacity];
        }
    }
}
