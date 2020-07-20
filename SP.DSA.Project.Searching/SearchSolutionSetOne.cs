using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class SearchSolutionSetOne
    {
        public static void SearchSolutionSetOneStart()
        {
            SearchSolutionSetOne srObj = new SearchSolutionSetOne();
            //srObj.BinarySearch();
            //srObj.CountOnes();
            //srObj.SquareRootDemo();
            //srObj.FindMajorityElement();
            //srObj.FindLeftIndex();
            //srObj.FindPickElement();
            //srObj.FindFloor();
            //srObj.MinNumberInRotatedArray();
            srObj.MedianOfTwoArray();
        }

        private void MedianOfTwoArray()
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 3, 4, 5, 6, 7, 8 };

            double median = GetMedia(arr1, arr2, arr1.Length, arr2.Length);
            Console.WriteLine("Median :" + median);
        }

        private double GetMedia(int[] arr1, int[] arr2, int m, int n)
        {
            int left = 0, right = m - 1;
            while (left <= right)
            {
                int i1 = (left + right) / 2;
                int i2 = (m + n + 1) / 2 - i1;
                int min1 = i1 == m ? int.MaxValue : arr1[i1];
                int max1 = i1 == 0 ? int.MinValue : arr1[i1 - 1];

                int min2 = i2 == n ? int.MaxValue : arr2[i2];
                int max2 = i2 == 0 ? int.MinValue : arr2[i2 - 1];

                if (max1 <= min2 && max2 <= min1)
                {
                    if ((m + n) % 2 == 0)
                    {
                        return (double)(Math.Max(max1, max2) + Math.Min(min1, min2)) / 2;
                    }
                    else
                        return Math.Max(max1, max2);
                }
                else if (max1 > min2)
                {
                    right = i1 - 1;
                }
                else
                {
                    left = i1 + 1;
                }
            }

            throw new Exception("Please provide a valid inputs.");
        }

        private void MinNumberInRotatedArray()
        {
            int[] arr = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };
            int min = GetMinimum(arr);
            Console.WriteLine("min :" + min);
        }

        private int GetMinimum(int[] arr)
        {
            int left = 0, size = arr.Length, right = size - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (mid != size - 1 || arr[mid + 1] > arr[mid])
                {

                }
            }
            return -1;
        }

        private void FindFloor()
        {
            int[] arr = { 1, 2, 8, 10, 11, 12, 19 };
            int floor = 7;

            int result = 0;

            int left = 0, right = arr.Length - 1, size = arr.Length;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == floor)
                    result = arr[mid];

                if (floor < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    result = arr[mid];
                    left = mid + 1;
                }
            }

            Console.WriteLine("result floor :" + result);
        }

        private void FindPickElement()
        {
            int[] arr = { 1, 3, 3 };
            int pick = GetPickNumber(arr, arr.Length);
        }

        private int GetPickNumber(int[] arr, int length)
        {
            int left = 0, right = length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if ((mid == 0 || arr[mid] >= arr[mid - 1]) && (mid == length - 1 || arr[mid] >= arr[mid + 1]))
                {
                    return arr[mid];
                }

                if (mid > 0 && arr[mid - 1] > arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }

        private void FindLeftIndex()
        {
            int[] arr = { 10, 20, 20, 20, 20, 20, 20 };
            int index = GetLeftMostIndex(arr, arr.Length, 20);
            Console.WriteLine("index : " + index);
        }

        private int GetLeftMostIndex(int[] arr, int length, int key)
        {
            int left = 0, right = length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == key && (mid == 0 || arr[mid - 1] != key))
                {
                    return mid;
                }

                if (arr[mid] > 20)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        private void FindMajorityElement()
        {
            int[] arr = { 3, 1, 3, 3, 2 };
            int major = arr[0], count = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == major)
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    major = arr[i];
                    count = 1;
                }
            }

            count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == major)
                    count++;

                if (count > arr.Length / 2)
                {
                    Console.WriteLine("major " + major);
                    break;
                }
            }

            //Console.WriteLine("no major ");
        }

        private void SquareRootDemo()
        {
            int n = 5;
            int sqRoot = GetSquareRoot(n);
            Console.WriteLine("square root of : {0}, is {1}", n, sqRoot);
        }

        private int GetSquareRoot(int n)
        {
            if (n == 0 || n == 1) return n;
            int left = 0, right = n;
            int result = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                Console.WriteLine("{0},{1},mid :{2}, result:{3}", left, right, mid, result);
                int square = mid * mid;
                if (square == n)
                    return square;

                if (square > n)
                {
                    right = mid - 1;
                }
                else
                {
                    result = mid;
                    left = mid + 1;
                }
            }
            return result;
        }

        private void CountOnes()
        {
            int[] arr = { 1, 1, 1, 1, 1, 0, 0, 0 };
            int count = GetOneCount(arr);
            Console.WriteLine("Total no of 1 :" + count);
        }

        private int GetOneCount(int[] arr)
        {
            int left = 0, right = arr.Length - 1, size = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == 1 && (mid == size - 1 || arr[mid + 1] == 0))
                {
                    return mid + 1;
                }
                if (arr[mid] == 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return 0;
        }

        private void BinarySearch()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int keyIndex = BinarySearchStart(arr, 5);
            Console.WriteLine("Search index :" + keyIndex);
        }

        private int BinarySearchStart(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == key)
                    return mid;

                if (key < arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
    }
}
