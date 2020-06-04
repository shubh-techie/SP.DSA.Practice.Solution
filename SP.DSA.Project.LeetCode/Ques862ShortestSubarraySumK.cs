using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques862ShortestSubarraySumK
    {
        public static void Ques862ShortestSubarraySumKDemo()
        {
            int[] arr = { 1, 2, 1, 2, 1 };
            int k = 3;
            //int result = GetShortestSubarraySumK(arr, k);
            //Console.WriteLine(result);
            Console.WriteLine(GetSubarraySum(arr, 3));
        }

        public static int GetSubarraySum(int[] nums, int k)
        {

            int count = 0, sum = 0;
            Dictionary<int, int> set = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                if (sum == k)
                {
                    count++;
                }
                int otherPair = sum - k;
                if (set.ContainsKey(otherPair))
                {
                    count += set[otherPair];
                    set[otherPair]++;
                }
                else
                    set[sum] = 1;
            }

            return count;
        }

        private static int GetShortestSubarraySumK(int[] arr, int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int currSum = 0, max = int.MaxValue;
            int start = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];
                if (currSum == sum)
                {
                    max = Math.Min(max, i + 1);
                }
                if (map.ContainsKey(currSum - sum))
                {
                    start = map[currSum - sum];
                    max = Math.Min(max, i - start);
                }
                map[currSum] = i;
            }

            return max == int.MaxValue ? -1 : max;
        }
    }
}
