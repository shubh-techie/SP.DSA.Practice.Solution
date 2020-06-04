using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques152MaximumProductSubarray
    {
        public static void MaxProductDemo()
        {
            int[] nums = { -2, 3, -4 };
            Console.WriteLine("MaxProduct(nums)  :" + MaxProductHelper(nums));
        }
        public static int MaxProductHelper(int[] nums)
        {

            int uMax = nums[0], lMax = nums[0], lMin = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    int temp = lMax;
                    lMax = lMin;
                    lMin = temp;
                }

                Console.WriteLine(lMin + " " + lMax);
                lMax = Math.Max(nums[i], nums[i] * lMax);
                lMin = Math.Max(nums[i], nums[i] * lMin);

                uMax = Math.Max(lMax, uMax);

            }

            return uMax;
        }
    }
}
