using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class BubbleSorting
    {
        public static void BubbleSortingDemo()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            //BubbleSortingHelper(arr);
            //InsertionSortingHelper(arr);
            mergeSortHelper(arr);
            Console.WriteLine("After sorting..............");
            Console.WriteLine(string.Join(",", arr));
        }

        private static void mergeSortHelper(int[] arr)
        {
            int length = arr.Length;
            MargeSort(arr, 0, length - 1);
        }

        private static void MargeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MargeSort(arr, left, mid);
                MargeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int i = 0, j = 0, k = 0;

            int leftLength = mid - left + 1;
            int rightLength = right - mid;

            int[] leftArray = new int[leftLength];
            int[] rightArray = new int[rightLength];

            for (i = 0; i < leftLength; i++)
            {
                leftArray[i] = arr[left + i];
            }
            Console.WriteLine(string.Join(",", leftArray));

            for (j = 0; j < rightLength; j++)
            {
                rightArray[j] = arr[mid + j + 1];
            }
            Console.WriteLine(string.Join(",", rightArray));

            i = 0;
            j = 0;
            k = left;

            while (i < leftLength && j < rightLength)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                arr[k] = leftArray[i];
                k++;
                i++;

            }
            while (j < rightLength)
            {
                arr[k] = rightArray[j];
                k++;
                j++;
            }

        }

        private static void InsertionSortingHelper(int[] arr)
        {
            int size = arr.Length;
            for (int i = 1; i < size; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                Console.WriteLine(string.Join(",", arr));
            }
        }

        private static void BubbleSortingHelper(int[] arr)
        {
            int size = arr.Length; bool isSwap = false;
            for (int i = 0; i < size; i++)
            {
                isSwap = false;
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (arr[j] >= arr[j + 1])
                    {
                        isSwap = true;
                        //Swappping
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                Console.WriteLine(string.Join(",", arr));
                if (isSwap == false) break;
            }
        }
    }
}
