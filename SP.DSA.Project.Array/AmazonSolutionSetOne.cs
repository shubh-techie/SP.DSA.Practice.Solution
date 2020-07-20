using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class AmazonSolutionSetOne
    {
        public static void AmazonSolutionSetOneDemo()
        {
            //ReplaceZeroWithFive();
            //ThirdLargestElement();
            //MaxandSecondMax();
            //MinimumDistanceTwoNumbers();
            //RotateAnArray();
            //IntersactionCount();
            //Rearrange();
            MaxSumInCircularArray();
        }

        private static void MaxSumInCircularArray()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 8, -4, 3, -5, 4 });
            arrColl.Add(new int[] { 8, -8, 9, -9, 10, -11, 12 });
            arrColl.Add(new int[] { 10, -3, -4, 7, 6, 5, -4, -1 });
            arrColl.Add(new int[] { -1, 40, -14, 7, 6, 5, -4, -1 });
            foreach (var arr in arrColl)
            {
                Console.WriteLine("Container max water :" + GetCicularMaxEfficient(arr, arr.Length));
            }
        }

        private static int GetCicularMaxEfficient(int[] arr, int n)
        {
            int arrMax = GetConSubArrayMax(arr, n);
            int arrSum = arr[0];
            for (int i = 1; i < n; i++)
            {
                arrSum += arr[i];
            }
            int arrMin = GetConSubArrayMin(arr, n);
            int circularSum = arrSum - arrMin;
            Console.WriteLine("Array Max Sum :{0}, Array Sum :{1}, array min sum :{2}, cicurlar Sum :{3}", arrMax, arrSum, arrMin, circularSum);
            return Math.Max(arrMax, circularSum);
        }

        private static int GetConSubArrayMax(int[] arr, int n)
        {
            int uMax = arr[0], cSum = arr[0];
            for (int i = 1; i < n; i++)
            {
                cSum = Math.Max(cSum + arr[i], arr[i]);
                uMax = Math.Max(uMax, cSum);
            }
            return uMax;
        }


        private static int GetConSubArrayMin(int[] arr, int n)
        {
            int uMin = arr[0], cSum = arr[0];
            for (int i = 1; i < n; i++)
            {
                cSum = Math.Min(cSum + arr[i], arr[i]);
                uMin = Math.Min(uMin, cSum);
            }
            return uMin;
        }

        private static int GetCicularMax(int[] arr, int n)
        {
            int result = arr[0], currMax = 0, currSum = 0;

            for (int i = 0; i < n; i++)
            {
                currSum = arr[i];
                currMax = arr[i];
                for (int j = 1; j < n; j++)
                {
                    int cIndex = (i + j) % n;
                    currSum += arr[cIndex];
                    currMax = Math.Max(currSum, currMax);
                }

                result = Math.Max(result, currMax);
            }

            return result;
        }

        private static void Rearrange()
        {
            long[] arr = { 4, 0, 2, 1, 3 };
            RearrangeStart(arr, arr.Length);
        }

        private static void RearrangeStart(long[] arr, int n)
        {
            long[] output = new long[n];
            for (int i = 0; i < n; i++)
            {
                output[i] = arr[arr[i]];
            }

            foreach (long item in output)
            {
                Console.Write(item + " ");
            }
        }

        private static void IntersactionCount()
        {
            int[] arr1 = { 2, 3, 7, 10, 12 };
            int[] arr2 = { 7, 5, 7, 8 };
            int count = GetIntersactionCount(arr1, arr2, arr1.Length, arr2.Length);
            Console.WriteLine(count);
        }

        private static int GetIntersactionCount(int[] arr1, int[] arr2, int m, int n)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (var item in arr1)
            {
                seen.Add(item);
            }
            int count = 0;

            foreach (var item in arr1)
            {
                if (seen.Contains(item))
                {
                    count++;
                    seen.Remove(item);
                }
            }
            return count;
        }

        private static void RotateAnArray()
        {
            int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            int rotateBy = 3;
            int left = 0, right = arr.Length - 1;
            Console.WriteLine(string.Join(",", arr));
            ReverAnArray(arr, left, rotateBy - 1);
            ReverAnArray(arr, rotateBy, right);
            ReverAnArray(arr, left, right);
            Console.WriteLine(string.Join(",", arr));
        }

        private static void ReverAnArray(int[] arr, int left, int right)
        {
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }

        private static void MinimumDistanceTwoNumbers()
        {
            int[] arr = { 1, 2, 3, 2, 8, 9, 3, 2 };
            int x = 1, y = 2, n = arr.Length, xIndex = 0, yIndex = 0, distance = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == x)
                {
                    xIndex = i + 1;
                }
                if (arr[i] == y)
                {
                    yIndex = i + 1;
                }
                if (xIndex != 0 && yIndex != 0)
                {
                    distance = Math.Min(distance, Math.Abs(xIndex - yIndex));
                }
            }

            Console.WriteLine("distance  {0}", distance);
        }

        private static void MaxandSecondMax()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int n = arr.Length;
            int second = -1;
            int uMax = arr[0];

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > uMax)
                {
                    int temp = uMax;
                    uMax = arr[i];
                    second = temp;
                }
                else
                {
                    if (arr[i] != uMax)
                        second = arr[i];
                }
            }

            Console.WriteLine("{0}, {1}", uMax, second);
        }

        private static void ThirdLargestElement()
        {
            int k = 3;
            int[] arr = { 2, 4, 1, 3, 5 };
            int KthElement = GetKthElement(arr, k);
            Console.WriteLine("kth element :" + KthElement);

        }

        private static int GetKthElement(int[] arr, int k)
        {
            if (arr.Length < k) return -1;
            if (arr.Length == k) return arr[0];

            int pos = arr.Length - k;
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int pivot = GetPivotPoint(arr, left, right);
                if (pos == pivot)
                {
                    return arr[pivot];
                }

                if (pos < pivot)
                {
                    right = pivot - 1;
                }
                else
                {
                    left = pivot + 1;
                }
            }
            return -1;
        }

        private static int GetPivotPoint(int[] arr, int left, int right)
        {
            int j = left - 1;
            int pNumber = arr[right];
            for (int i = 0; i <= right; i++)
            {
                if (arr[i] <= pNumber)
                {
                    j++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                }
            }
            return j;
        }

        private static void ReplaceZeroWithFive()
        {
            int num = 100000004;
            int output = Convertfive(num);
            Console.WriteLine("Output  :" + output);

        }

        private static int Convertfive(int num)
        {
            if (num == 0) return 5;

            int dec = 1;
            int output = 0;

            while (num > 0)
            {
                int rem = num % 10 == 0 ? 5 : num % 10;
                output += rem * dec;
                dec = dec * 10;
                num = num / 10;
            }

            return output;
        }
    }
}
