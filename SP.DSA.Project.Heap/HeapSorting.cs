using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Heap
{
    public class HeapSorting
    {
        public static void HeapSortingDemo()
        {
            int[] storage = new int[] { 10, 15, 50, 4, 20 };
            Console.WriteLine("Before Sorting..." + string.Join(", ", storage));
            HeapSort(storage, storage.Length);
            Console.WriteLine("After Sorting..." + string.Join(", ", storage));
        }

        public static void HeapSort(int[] arr, int n)
        {
            BuildHeap(arr, arr.Length);
            for (int i = n - 1; i >= 0; i--)
            {
                Swapping(arr, i, 0);
                MaxHeapify(arr, i, 0);
            }
        }

        private static void MaxHeapify(int[] arr, int length, int i)
        {
            int largest = i, left = 2 * i + 1, right = 2 * i + 2;

            if (left < length && arr[left] > arr[largest])
                largest = left;
            if (right < length && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                Swapping(arr, i, largest);
                MaxHeapify(arr, length, largest);
            }
        }

        private static void Swapping(int[] arr, int i, int rooIndex)
        {
            int temp = arr[rooIndex];
            arr[rooIndex] = arr[i];
            arr[i] = temp;
        }

        private static void BuildHeap(int[] arr, int length)
        {
            for (int i = (length - 2) / 2; i >= 0; i--)
            {
                MaxHeapify(arr, length, i);
            }
        }

    }
}
