using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class PeakElement
    {
        public static void PeakElementDemo()
        {
            int[] arr = { 1, 3, 20, 4, 1, 0 };
            int n = arr.Length;
            Console.WriteLine("Index of a peak point is " + GetPeakElement(arr, n));
        }
        public static int GetPeakElement(int[] arr, int n)
        {
            int left = 0, right = n - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if ((mid == 0 || arr[mid] >= arr[mid - 1]) && (mid == n - 1 || arr[mid] >= arr[mid + 1]))
                    return mid;

                if (mid > 0 && arr[mid - 1] > arr[mid])
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
