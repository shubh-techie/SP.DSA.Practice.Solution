using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class LeftIndexOfNumber
    {
        public static void LeftIndexOfNumberDemo()
        {
            int[] arr = { 10, 20, 20, 20, 20, 20, 20 };
            int index = GetLeftIndexOfNumber(arr, 20);
            Console.WriteLine("index :" + index);
        }

        private static int GetLeftIndexOfNumber(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == key && (mid == 0 || arr[mid - 1] != key))
                {
                    return mid;
                }

                if (arr[mid] >= key)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}
