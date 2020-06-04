using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class FindingKthSmallestNumber
    {
        public static void FindingKthSmallestNumberDemo()
        {
            int[] arr = { 10, 5, 30, 12 };
            int k = 2;
            int no = GetKthSmallest(arr, k);
            Console.WriteLine("no is :" + no);
        }

        private static int GetKthSmallest(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int pivot = GetLomutoPartition(arr, left, right);

                if (pivot == k - 1)
                    return arr[pivot];
                else if (pivot > k - 1)
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


        private static int GetKthSmallesNumberHashing(int[] arr, int k)
        {
            HashSet<int> track = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                track.Add(arr[i]);
                if (track.Count > 2)
                    track.Remove(track.Max());
            }
            return track.Max();
        }

        private static int GetKthSmallesNumberSorting(int[] arr, int k)
        {
            Array.Sort(arr);
            return arr[k - 1];
        }
    }
}
