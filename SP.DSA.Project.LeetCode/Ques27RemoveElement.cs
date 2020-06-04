using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
   public class Ques27RemoveElement
    {
        public static void Ques27RemoveElementDemo()
        {
            int[] arr = { 3, 2, 2, 3 };
            Console.WriteLine(string.Join(",",arr));
            RemoveElement(arr, 3);
            Console.WriteLine(string.Join(",",arr));
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int cVal = 0, size = nums.Length;
            for (int i = 0; i < size; i++)
            {
                if (nums[i] != val)
                {
                    nums[cVal] = nums[i];
                    cVal++;
                }
            }
            return cVal;
        }
    }
}
