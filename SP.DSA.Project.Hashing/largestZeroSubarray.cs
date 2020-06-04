using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class largestZeroSubarray
    {
        public static void largestZeroSubarrayDemo()
        {
            int[] arr = new int[] { 1, 1, 1, 0, 1, 0, 1, 1, 1 };
            int len = arr.Length;

            Console.WriteLine("Naive Solution.");
            Console.WriteLine(GetlargestZeroSubarrayNaive(arr, len));
            Console.WriteLine("Hasing Solution.");
            Console.WriteLine(GetlargestZeroSubarray(arr, len));
            Console.WriteLine("Hasing CountSolution.");
            Console.WriteLine(GetlargestZeroSubarrayCount(arr, len));
        }

        private static int GetlargestZeroSubarrayCount(int[] arr, int len)
        {
            int maxLen = 0, start = 0, end = -1;
            Dictionary<int, int> result = new Dictionary<int, int>();
            int preSum = 0;

            for (int i = 0; i < len; i++)
            {
                if (arr[i] == 0) arr[i] = -1;
            }

            for (int i = 0; i < len; i++)
            {
                preSum += arr[i];

                if (preSum == 0)
                {
                    maxLen++;
                }

                if (result.ContainsKey(preSum))
                {
                    maxLen += result[preSum];
                    result[preSum]++;
                }
                else
                {
                    result[preSum] = 1;
                }
            }

            return maxLen;
        }

        private static int GetlargestZeroSubarray(int[] arr, int len)
        {
            int maxLen = 0, start = 0, end = -1;
            Dictionary<int, int> result = new Dictionary<int, int>();
            int preSum = 0;

            for (int i = 0; i < len; i++)
            {
                if (arr[i] == 0) arr[i] = -1;
            }

            for (int i = 0; i < len; i++)
            {
                preSum += arr[i];

                if (preSum == 0)
                {
                    Console.WriteLine("Index :{0} To {1}", 0, i + 1);
                }

                if (result.ContainsKey(preSum))
                {
                    start = result[preSum];
                    end = i;

                    Console.WriteLine("Index :{0} To {1}", start + 1, end);
                    maxLen = Math.Max(end - start, maxLen);
                    //result[preSum] = i;
                }
                else
                    result[preSum] = i;
            }

            return maxLen;
        }

        private static object GetlargestZeroSubarrayNaive(int[] arr, int len)
        {
            int maxLen = 0;

            for (int i = 0; i < len; i++)
            {
                int c0 = 0, c1 = 0;
                for (int j = i; j < len; j++)
                {
                    if (arr[j] == 0) c0++;
                    if (arr[j] == 1) c1++;
                    if (c0 == c1)
                    {
                        Console.WriteLine(" print start :{0} and end :{1} index ", i, j);
                        maxLen = Math.Max(maxLen, j - i + 1);
                    }
                }
            }

            return maxLen;
        }
    }
}
