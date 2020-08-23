using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques198HouseRobber
    {
        public static void Ques198HouseRobberDemo()
        {
            int[] nums = { 1, 2, 3, 1 };
            Console.WriteLine(RobHelper(nums, nums.Length));
        }

        public static int RobHelper(int[] nums, int len)
        {
            int[] cache = new int[len];
            cache[0] = nums[0];
            cache[1] = nums[1];
            for (int i = 2; i < len; i++)
            {
                cache[i] = Math.Max(cache[i - 1], nums[i] + cache[i - 2]);
            }
            return cache[len];
        }

        public int RobHelperRecursion(int[] nums, int length)
        {
            if (length < 0)
                return 0;

            int currIndex = nums[length] + RobHelper(nums, length - 2);
            int skipIndex = RobHelper(nums, length - 1);
            return Math.Max(currIndex, skipIndex);
        }
    }
}
