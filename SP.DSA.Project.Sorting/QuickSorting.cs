using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class QuickSorting
    {
        public static void QuickSortingDemo()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] arr = { 4, 2, 6, 5, 9, 8 };
            Console.WriteLine("Before sorting   : " + string.Join(",", arr));
            QuickSort(arr);
            Console.WriteLine("After sorting   : " + string.Join(",", arr));
        }

        private static void QuickSort(int[] arr)
        {
            QuickSortingStart(arr, 0, arr.Length - 1);
        }

        private static void QuickSortingStart(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = GetHoarePartitionIndex(arr, left, right);
                QuickSortingStart(arr, left, pivot - 1);
                QuickSortingStart(arr, pivot + 1, right);
            }
        }

        private static int GetLomutoPartitionIndex(int[] arr, int left, int right)
        {
            int pNumber = arr[right], pIndex = left - 1;
            for (int j = left; j <= right; j++)
            {
                if (arr[j] <= pNumber)
                {
                    pIndex++;
                    int temp = arr[pIndex];
                    arr[pIndex] = arr[j];
                    arr[j] = temp;
                }
            }
            return pIndex;
        }

        private static int GetHoarePartitionIndex(int[] arr, int left, int right)
        {
            int pNumber = arr[left];
            int L = left - 1, R = right + 1;
            while (true)
            {
                do
                {
                    L++;
                } while (arr[L] < pNumber);

                do
                {
                    R--;
                } while (arr[R] > pNumber);

                if (L >= R) return R;

                int temp = arr[L];
                arr[L] = arr[R];
                arr[R] = temp;
            }
        }
    }
}
