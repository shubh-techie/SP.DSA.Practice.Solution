using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class MedianNumber
    {
        public int search(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] >= nums[start])
                {
                    if (target >= nums[start] && target < nums[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else
                {
                    if (target <= nums[end] && target > nums[mid])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }

            return -1;
        }
        public int searchHello(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] >= nums[start])
                {
                    if (target >= nums[start] && target < nums[start])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else
                {
                    if (target < nums[end] && target > nums[mid])
                        start = mid + 1;
                    else
                        start = mid - 1;
                }
            }
            return -1;
        }

        public static void FindMedianSortedArrays()
        {
            int[] nums1 = { 2 };
            int[] nums2 = { };
            Console.WriteLine(FindMedianSortedArraysHelper(nums1, nums2));
        }

        public static double FindMedianSortedArraysHelper(int[] input1, int[] input2)
        {
            //if input1 length is greater than switch them so that input1 is smaller than input2.
            if (input1.Length > input2.Length)
            {
                return FindMedianSortedArraysHelper(input2, input1);
            }
            int x = input1.Length;
            int y = input2.Length;
            int mergeLength = x + y;
            int low = 0;
            int high = x;
            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                //if partitionX is 0 it means nothing is there on left side. Use -INF for maxLeftX
                //if partitionX is length of input then there is nothing on right side. Use +INF for minRightX
                int maxLeftX = (partitionX == 0) ? int.MinValue : input1[partitionX - 1];
                int minRightX = (partitionX == x) ? int.MaxValue : input1[partitionX];

                int maxLeftY = (partitionY == 0) ? int.MinValue : input2[partitionY - 1];
                int minRightY = (partitionY == y) ? int.MaxValue : input2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    return GetMedianResult(mergeLength, minRightX, minRightY, maxLeftX, maxLeftY);
                }
                else if (maxLeftX > minRightY)
                { //we are too far on right side for partitionX. Go on left side.
                    high = partitionX - 1;
                }
                else
                { //we are too far on left side for partitionX. Go on right side.
                    low = partitionX + 1;
                }
            }

            //Only we we can come here is if input arrays were not sorted. Throw in that scenario.
            throw new Exception();
        }

        private static double GetMedianHelper(int[] arr1, int[] arr2)
        {
            if (arr1.Length > arr2.Length)
            {
                GetMedianHelper(arr2, arr1);
            }
            int m = arr1.Length, n = arr2.Length, mergeLength = m + n;
            int left = 0, right = m;
            while (left <= right)
            {
                int i1 = (left + right) / 2;
                int i2 = (mergeLength + 1) / 2 - i1;

                int max1 = i1 == 0 ? int.MinValue : arr1[i1 - 1];
                int min1 = i1 == m ? int.MaxValue : arr1[i1];

                int max2 = i2 == 0 ? int.MinValue : arr2[i2 - 1];
                int min2 = i2 == n ? int.MaxValue : arr2[i2];

                if (max1 <= min2 && max2 <= min1)
                {
                    return GetMedianResult(mergeLength, min1, min2, max1, max2);
                }
                else if (max1 > min2)
                    right = i1 - 1;
                else
                    left = i1 + 1;
            }

            throw new Exception("There is some issue in input");
        }

        private static double GetMedianResult(int mergeLength, int min1, int min2, int max1, int max2)
        {
            if (mergeLength % 2 == 0)
            {
                return (double)((Math.Max(max1, max2) + Math.Min(min1, min2)) / 2.0);
            }
            else
            {
                return (double)Math.Max(max1, max2);
            }
        }

    }
}
