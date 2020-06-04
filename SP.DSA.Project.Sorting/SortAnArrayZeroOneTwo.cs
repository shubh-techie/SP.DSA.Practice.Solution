using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class SortAnArrayZeroOneTwo
    {
        public static void SortAnArrayZeroOneTwoDemo()
        {
            //int[] arr = { 0, 1, 2, 0, 1, 2 };
            int[] arr = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            SortByAlgo(arr);
            //SortTheArrayNaive2Solution(arr);
        }

        private static void SortByAlgo(int[] arr)
        {
            int left = 0, right = arr.Length - 1, mid = 0;

            while (mid <= right)
            {
                switch (arr[mid])
                {
                    case 0:
                        Swapping(arr, left, mid); left++; mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        Swapping(arr, right, mid); right--;
                        break;
                }
            }

            Console.WriteLine("After Alog sorting Solution :" + string.Join(",", arr));
        }

        private static void Swapping(int[] arr, int left, int mid)
        {
            int temp = arr[left];
            arr[left] = arr[mid];
            arr[mid] = temp;
        }

        private static void SortTheArrayNaive2Solution(int[] arr)
        {
            int[] temp = new int[arr.Length];
            int k = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    temp[k++] = 0;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                    temp[k++] = 1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 2)
                    temp[k++] = 2;
            }
            Console.WriteLine("After Naive two Solution :" + string.Join(",", temp));
        }

        private static void SortTheArrayNaiveSolution(int[] arr)
        {
            int zeroCount = 0, oneCount = 0, twoCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    zeroCount++;
                if (arr[i] == 1)
                    oneCount++;
                if (arr[i] == 2)
                    twoCount++;
            }
            int k = 0;
            while (zeroCount > 0)
            {
                arr[k++] = 0;
                zeroCount--;
            }
            while (oneCount > 0)
            {
                arr[k++] = 1;
                oneCount--;
            }
            while (twoCount > 0)
            {
                arr[k++] = 2;
                twoCount--;
            }
            Console.WriteLine("After Naiver Solution :" + string.Join(",", arr));
        }
    }
}
