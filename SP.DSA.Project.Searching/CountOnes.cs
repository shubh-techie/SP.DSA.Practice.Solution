using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class CountOnes
    {
        public static void countOnesDemo()
        {
            int[] arr = { 1, 1, 1, 1, 1, 1, 0, 0 };
            int count = GetCountOnes(arr);
            Console.WriteLine("Count s are " + count);
        }

        private static int GetCountOnes(int[] arr)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == 1 && (mid == arr.Length - 1 || arr[mid + 1] != 1))
                {
                    return mid + 1;
                }
                else if (arr[mid] == 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return 0;
        }
    }
}
