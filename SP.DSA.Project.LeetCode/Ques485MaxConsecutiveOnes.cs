using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques485MaxConsecutiveOnes
    {
        public static void Ques485MaxConsecutiveOnesDemo()
        {
            int[] arr = { 1, 1, 0, 1, 1, 1 };
            Console.WriteLine(" max consecutive  1 :" + FindMaxConsecutiveOnes(arr));
        }

        public static int FindMaxConsecutiveOnes(int[] arr)
        {
            int uMax = 0, lMax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                    lMax++;
                else
                    lMax = 0;

                uMax = Math.Max(uMax, lMax);
            }

            return uMax;
        }
    }
}
