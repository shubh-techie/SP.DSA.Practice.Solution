using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class MedianOfTwoSortedArrays
    {
        public static void ProvideInput()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr1 = new int[m];
                int count = 0;
                string str = Console.ReadLine();
                foreach (string item in str.Split(' '))
                {
                    arr1[count++] = Convert.ToInt32(item);
                }
                int[] arr2 = new int[n];
                count = 0;
                str = Console.ReadLine();
                foreach (string item in str.Split(' '))
                {
                    arr2[count++] = Convert.ToInt32(item);
                }
                Console.WriteLine(string.Join(", ", arr1));
                Console.WriteLine(string.Join(", ", arr2));
                //Console.WriteLine(GetMedian(arr1, arr2));
                T--;
            }
        }

        public static void MedianOfTwoSortedArraysDemo()
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 3, 4, 5, 6, 7, 8 };

            //int[] arr1 = { 1, 2, 3, 4 };
            //int[] arr2 = { 11, 12, 13, 14 };
            double median = GetMedian(arr1, arr2);
            Console.WriteLine("median :" + median);
        }
        private static double GetMedian(int[] arr1, int[] arr2)
        {
            int m = arr1.Length, n = arr2.Length, mergeLength = m + n;
            if (m > n)
            {
                return GetMedian(arr2, arr1);
            }
            int left = 0, right = m;
            while (left <= right)
            {
                int i1 = (left + right) / 2;
                int i2 = ((mergeLength + 1) / 2) - i1;

                int min1 = i1 == m ? int.MaxValue : arr1[i1];
                int max1 = i1 == 0 ? int.MinValue : arr1[i1 - 1];

                int min2 = i2 == n ? int.MaxValue : arr2[i2];
                int max2 = i2 == 0 ? int.MinValue : arr2[i2 - 1];

                if (max1 <= min2 && max2 <= min1)
                {
                    return GetMedianResult(mergeLength, min1, min2, max1, max2);
                }
                if (max1 > min2)
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
                return (Math.Max(max1, max2) + Math.Min(min1, min2)) / 2;
            }
            else
            {
                return Math.Max(max1, max2);
            }
        }


        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0) return GetMedian(nums2);
            if (nums2.Length == 0) return GetMedian(nums1);

            int[] mergedArray = MergedSortedArrays(nums1, nums2);
            Console.Write(mergedArray.Length);
            return GetMedian(mergedArray);
        }
        public int[] MergedSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int[] output = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] <= nums2[j])
                {
                    output[k] = nums1[i];
                    i++;
                }
                else
                {
                    output[k] = nums2[j];
                    j++;
                }
                k++;
            }

            while (i < m)
            {
                output[k] = nums1[i];
                i++; k++;
            }
            while (j < n)
            {
                output[k] = nums2[j];
                j++; k++;
            }

            return output;
        }
        public double GetMedian(int[] A)
        {
            int size = A.Length;
            if (size % 2 == 0)
            {
                double output = (A[size / 2] + A[(size / 2) - 1]) / 2.0;
                return output;
            }
            else
            {
                return A[size / 2];
            }
        }
    }
}
