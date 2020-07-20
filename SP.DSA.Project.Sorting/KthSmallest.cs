using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class KthSmallest
    {
        public static void KthSmallestDemo()
        {
            int[] arr = { 7, 10, 4, 20, 15 };
            int k = 4;

            int kth = GetkthNumber(arr, k);
            Console.WriteLine("kth :" + kth);
        }

        private static int GetkthNumber(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int pivot = getPivot(arr, left, right);

                if (pivot == k - 1)
                    return arr[pivot];

                if (pivot > k - 1)
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }

            return -1;
        }

        private static int getPivot(int[] arr, int left, int right)
        {
            int pNumber = arr[right];
            int j = left - 1;

            for (int i = left; i <= right; i++)
            {
                if (arr[i] <= pNumber)
                {
                    j++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            return j;
        }
    }
}
