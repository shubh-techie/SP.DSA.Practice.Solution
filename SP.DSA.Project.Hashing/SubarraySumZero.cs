using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class SubarraySumZero
    {
        public static void SubarraySumZeroDemo()
        {
            int[] arr = { 4, 2, -3, 1, 6 };
            bool isSum = IsSubarraySumZero(arr);
            Console.WriteLine("is sum :" + isSum);
        }

        private static bool IsSubarraySumZero(int[] arr)
        {
            int size = arr.Length;
            int currSum = 0;
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < size; i++)
            {
                currSum += arr[i];
                if (set.Contains(currSum) || currSum == 0)
                    return true;
                set.Add(currSum);
            }

            return false;
        }
    }
}
