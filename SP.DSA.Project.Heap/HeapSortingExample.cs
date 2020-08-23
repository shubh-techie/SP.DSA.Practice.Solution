using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Heap
{
    public class HeapSortingExample
    {
        public static void HeapSortingDemo()
        {
            int[] storage = new int[] { 10, 15, 50, 4, 20 };
            Console.WriteLine("Before Sorting..." + string.Join(", ", storage));
            HeapSort(storage, storage.Length);
            Console.WriteLine("After Sorting..." + string.Join(", ", storage));
        }

        private static void HeapSort(int[] storage, int length)
        {
            BuildHeap(storage, length);

            for (int i = length - 1; i >= 0; i--)
            {
                Swapping(storage, i, 0);
                Heapify(storage, i, length);
            }
        }

        private static void Heapify(int[] storage, int i, int length)
        {
            throw new NotImplementedException();
        }

        private static void Swapping(int[] arr, int i, int rooIndex)
        {
            int temp = arr[rooIndex];
            arr[rooIndex] = arr[i];
            arr[i] = temp;
        }

        private static void BuildHeap(int[] storage, int length)
        {
            for (int i = (length - 2) / 2; i >= 0; i--)
            {
                MaxHeapify(storage, i, length);
            }
        }

        private static void MaxHeapify(int[] storage, int i, int length)
        {
            throw new NotImplementedException();
        }
    }
}
