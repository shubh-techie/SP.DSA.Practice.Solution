using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class SubsetSumsIsMinimum
    {
        public static void SubsetSumsIsMinimumDemo()
        {
            int[] arr = { 1, 6, 11, 5 };
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            int minDiff = GetMinDiffSubSet(arr, arr.Length, sum);
        }

        private static int GetMinDiffSubSet(int[] arr, int length, int totalSum)
        {
            return GetMinDiffSubSetHelper(arr, length, totalSum);
        }

        private static int GetMinDiffSubSetHelper(int[] arr, int n, int totalSum)
        {

            return Math.Abs(GetMinDiffSubSetHelper(arr, n - 1, totalSum - arr[n - 1]) - GetMinDiffSubSetHelper(arr, n - 1, totalSum));
        }
    }
}
