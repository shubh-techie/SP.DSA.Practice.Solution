using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class QuesThreeSum
    {
        public static void ThreeSumDemo()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> result = ThreeSum(nums);
            foreach (var rPairs in result)
            {
                Console.WriteLine(string.Join(", ", rPairs));
            }
        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> output = new List<IList<int>>();
            int size = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < size; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                    sumOfTwo(nums, nums[i], i + 1, size, output);
            }
            return output;
        }

        private static void sumOfTwo(int[] nums, int One, int left, int right, IList<IList<int>> output)
        {
            int lo = left, hi = right - 1;
            while (lo < hi)
            {
                int sum = One + nums[lo] + nums[hi];
                if (sum < 0 || (lo > lo + 1 && nums[lo] == nums[lo + 1]))
                {
                    lo++;
                }
                else if (sum > 0 || (hi < right - 1 && nums[hi] == nums[hi + 1]))
                {
                    hi--;
                }
                else
                {
                    IList<int> pair = new List<int>() { One, nums[lo], nums[hi] };
                    output.Add(pair);
                    lo++;
                    hi--;
                }
            }
        }
    }
}
