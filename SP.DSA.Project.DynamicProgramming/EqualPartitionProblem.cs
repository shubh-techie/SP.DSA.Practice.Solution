using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class EqualPartitionProblem
    {
        public static void EqualPartitionProblemDemo()
        {
            int[] arr = { 1, 5, 11, 5 };
            bool isFound = IsSubsetFound(arr, arr.Length);
            Console.WriteLine("isFound " + isFound);
        }

        private static bool IsSubsetFound(int[] arr, int length)
        {
            if (length < 2) return false;
            int totalSum = 0;
            for (int i = 0; i < length; i++)
            {
                totalSum += arr[i];
            }

            if (totalSum % 2 != 0)
            {
                return false;
            }
            return IsSubsetSum(arr, length, totalSum / 2);
        }

        private static bool IsSubsetSum(int[] arr, int n, int sum)
        {
            if (sum == 0) return true;
            if (n == 0 && sum != 0) return false;

            if (arr[n - 1] > sum)
            {
                return IsSubsetSum(arr, n - 1, sum);
            }
            else
                return IsSubsetSum(arr, n - 1, sum - arr[n - 1]) || IsSubsetSum(arr, n - 1, sum);
        }
    }
}
