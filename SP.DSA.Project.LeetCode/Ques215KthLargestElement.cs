using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques215KthLargestElement
    {
        public static void Ques215KthLargestElementDemo()
        {
            //int[] arr = { 3, 2, 1, 5, 6, 4 };
            //int k = 2;
            int[] arr = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            int k = 4;
            int kthElement = GetKthLargest(arr, k);
            Console.WriteLine("Kth Largest element :" + kthElement);
            Console.WriteLine("printing array : " + string.Join(",", arr));
        }

        private static int GetKthLargest(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1, size = arr.Length;
            while (left <= right)
            {
                int pivot = GetLomutoPartition(arr, left, right);

                if (pivot == size - k)
                    return arr[pivot];
                else if (pivot > size - k)
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }

            return -1;
        }

        private static int GetLomutoPartition(int[] arr, int left, int right)
        {
            int pNumber = arr[right], pIndex = left - 1;

            for (int i = left; i <= right; i++)
            {
                if (arr[i] <= pNumber)
                {
                    pIndex++;
                    int temp = arr[pIndex];
                    arr[pIndex] = arr[i];
                    arr[i] = temp;
                }
            }

            return pIndex;
        }


        private static int GetKthElementHasing(int[] arr, int k)
        {
            HashSet<int> keepMax = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                keepMax.Add(arr[i]);
                Console.WriteLine(string.Join(" ,", keepMax));
                if (keepMax.Count >= k)
                    keepMax.Remove(keepMax.Min());

            }
            return keepMax.Min();
        }


        private static int GetKthElement(int[] arr, int k)
        {
            Array.Sort(arr);
            return arr[arr.Length - k];
        }
    }
}
