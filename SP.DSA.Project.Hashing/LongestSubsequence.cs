using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class LongestSubsequence
    {
        public static void LongestSubsequenceDemo()
        {
            // int[] arr = { 1, 9, 3, 10, 4, 20, 2 };
            int[] arr = { 2, 6, 1, 9, 4, 5, 3 };
            int maxLen = GetLongestSubsequenceNaive(arr);
            Console.WriteLine("maxLen from Naive Solution " + maxLen);
            maxLen = GetLongestSubsequence(arr);
            Console.WriteLine("maxLen from hasing....." + maxLen);
        }

        private static int GetLongestSubsequence(int[] arr)
        {
            int count = 1, result = 0;
            HashSet<int> set = new HashSet<int>();

            foreach (var item in arr)
            {
                set.Add(item);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!set.Contains(arr[i] - 1))
                {
                    Console.WriteLine(arr[i] - 1 + "not present so its starting point .");
                    count = 1;
                    while (set.Contains(arr[i] + count))
                    {
                        count++;
                    }
                    result = Math.Max(result, count);
                }
            }
            return result;
        }

        private static int GetLongestSubsequenceNaive(int[] arr)
        {
            int count = 1, result = 0;
            Array.Sort(arr);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] == 1)
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                result = Math.Max(result, count);
            }

            return result;
        }
    }
}
