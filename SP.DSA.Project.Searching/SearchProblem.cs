using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class SearchProblem
    {
        public static void SearchProblemDemo()
        {
            ////int[] arr = { 1, 3, 20, 4, 1, 0 };
            //int[] arr = { 1, 2, 3 };
            //int n = arr.Length;
            //Console.WriteLine("Index of a peak point is " + GetPeakElement(arr, n));

            ////int[] arr = { 10, 20, 20, 20, 20, 20, 20 };
            //int[] arr = { 1, 1, 2, 2, 3, 4, 5, 5, 6, 7 };
            //int indexLeft = GetLeftMostIndex(arr, 1);
            //Console.WriteLine("indexLeft :" + indexLeft);

            //int[] arr = { 3, 3, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 5 };
            ////int[] arr = { 3 };
            //int majorityElement = GetMajorityElementUsingAlgo(arr);
            //Console.WriteLine("majorityElement :" + majorityElement);

            //long sqRoot = GetSquareRoot(4);
            //Console.WriteLine("sqRoot :" + sqRoot);

            //int[] arr = { 1, 1, 1, 1, 1, 0, 0, 0 };
            //int count = GetOneCount(arr, arr.Length);
            //Console.WriteLine("count :" + count);

            //int[] arr = { 1, 2, 3, 4, 5 };
            //Array.Sort(arr);
            //int index = GetSearchBinarySearchRec(arr, arr.Length, 5);
            //Console.WriteLine(index);

            //int[] arr = { 1, 2, 3, 4, 5 };
            //int index = GetSearchIndex(arr, arr.Length, 5);
            //Console.WriteLine(index);

            //long[] arr = { 1, 2, 8, 10, 11, 12, 19 };
            //int n = arr.Length;
            //Console.WriteLine("Floor element. " + GetPeakElement(arr, 0, n - 1, 0));

            //long[] arr = { 1, 2, 8, 10, 11, 12, 19 };
            //int n = arr.Length;
            //Console.WriteLine("Floor element. " + MinimumNumber(arr, 0, n - 1));

            ////  long[] arr = { 1, 2, 2, 3, 2 };
            //long[] arr = { 1, 2, 3, 4 };
            //int n = arr.Length;
            //Console.WriteLine("ConsecutiveSteps. " + ConsecutiveSteps(arr, n));

            //long[] arr = { 1, 2, 1, 3, 4, 3 };
            //long[] arr = { 1, 1, 2, 2 };
            //long[] arr = { 1, 2, 2, 1 };
            //int n = arr.Length;
            //Console.WriteLine("ConsecutiveSteps. " + TwoRepeated(arr, n));


            ////long[] arr = { 2, 1, 3, 4, 6, 5 };
            //long[] arr = { 1, 2 };
            //int n = arr.Length;
            //Console.WriteLine("MaxWater. " + MaxWater(arr, n));

            int[] arr = { 3, 1, 2, 2, 1, 2, 3, 3 };
            int n = arr.Length;
            int k = 4;
            Console.WriteLine("CountOccurence. " + CountOccurenceSorting(arr, n, k));
        }

        private static int CountOccurenceSorting(int[] arr, int n, int k)
        {
            Array.Sort(arr);
            int count = 1, Major = arr[0], itemCount = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == Major)
                {
                    count++;
                }
                else
                {
                    if (count > n / k && arr[i] != Major)
                    {
                        itemCount++;
                    }
                    Major = arr[i];
                    count = 1;
                }
            }

            if (count > n / k)
            {
                itemCount++;
            }

            return itemCount;
        }

        private static int CountOccurence(long[] arr, int n, int k)
        {
            Dictionary<int, int> mapCollection = new Dictionary<int, int>();
            foreach (int item in arr)
            {
                if (!mapCollection.ContainsKey(item))
                {
                    mapCollection.Add(item, 1);
                }
                else
                    mapCollection[item]++;

                if (mapCollection[item] >= n / k)
                    return item;
            }
            return -1;
        }

        private static int MaxWater(long[] arr, int n)
        {
            int left = 0, right = n - 1, uMax = int.MinValue, maxremoval = 0;

            while (left <= right)
            {
                int totalMaxWater = (int)Math.Min(arr[left], arr[right]) * (right - left);
                if (totalMaxWater > uMax)
                {
                    uMax = totalMaxWater;
                    maxremoval = Math.Max(maxremoval, (right - left - 1) * (int)Math.Min(arr[left], arr[right]));
                }

                if (arr[left] < arr[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxremoval;
        }

        private static string TwoRepeated(long[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int index = (int)Math.Abs(arr[i]);
                if (arr[index - 1] < 0)
                    Console.Write(Math.Abs(arr[i]) + " ");
                else
                {
                    arr[index - 1] *= -1;
                }
            }
            return "";
        }

        private static int ConsecutiveSteps(long[] arr, int n)
        {
            int count = 0, uMax = int.MinValue;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                    count++;
                else
                {
                    uMax = Math.Max(uMax, count);
                    count = 0;
                }
            }
            return Math.Max(uMax, count);
        }

        private static long MinimumNumber(long[] arr, long low, long high)
        {
            while (low < high)
            {
                long mid = (low + high) / 2;
                //if (mid == 0 || arr[mid] < arr[mid - 1])



            }

            return -1;
        }

        private static int GetPeakElement(long[] arr, int left, int right, long x)
        {
            int floor = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == x)
                    return mid;

                if (x < arr[mid])
                    right = mid - 1;
                else
                {
                    floor = mid;
                    left = mid + 1;
                }
            }

            return floor == 0 ? -1 : floor;
        }

        private static int GetPeakElement(int[] arr, int n)
        {
            if (n == 1) return arr[0];

            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if ((mid == 0 || arr[mid] >= arr[mid - 1]) && (mid == n - 1 || arr[mid] >= arr[mid + 1]))
                {
                    return mid;
                }

                if (mid > 0 && arr[mid - 1] > arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        private static int GetLeftMostIndex(int[] arr, int x)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == x && (mid == 0 || arr[mid - 1] != x))
                {
                    return mid;
                }

                if (arr[mid] >= x)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        private static int GetMajorityElementUsingAlgo(int[] arr)
        {
            int size = arr.Length;
            if (size == 1) return arr[size - 1];
            int count = 1, majority = arr[0];
            for (int i = 1; i < size; i++)
            {
                if (majority == arr[i])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    majority = arr[i];
                    count = 1;
                }
            }
            count = 0;
            for (int i = 0; i < size; i++)
            {
                if (majority == arr[i])
                    count++;
            }

            if (count > size / 2)
                return majority;

            return -1;
        }

        private static int GetMajorityElementUsingSorting(int[] arr)
        {
            if (arr.Length == 1) return arr[0];
            Array.Sort(arr);
            int count = 1, size = arr.Length;
            for (int i = 1; i < size; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    Console.WriteLine("no :{0} , count :{1}", arr[i], count);
                    count++;
                    if (count > size / 2)
                        return arr[i];
                }
                else
                    count = 1;
            }
            return -1;
        }

        private static int GetMajorityElementUsingSortingAndMiddle(int[] arr)
        {
            Array.Sort(arr);
            return arr[arr.Length / 2];
        }

        private static int GetMajorityElement(int[] arr)
        {
            if (arr.Length == 0) throw new Exception("array is empty.");
            //Array.Sort(arr);
            int count = 0, size = arr.Length;

            for (int i = 0; i < size; i++)
            {
                int ele = arr[i]; count = 0;
                for (int j = 0; j < size; j++)
                {
                    if (arr[j] == ele)
                    {
                        count++;
                    }
                }
                if (count > size / 2)
                {
                    return arr[i];
                }
            }

            return -1;
        }

        private static long GetSquareRoot(int x)
        {
            if (x == 0 || x == 1) return x;
            long result = 0;
            int left = 1, right = x;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (mid * mid == x)
                {
                    result = mid;
                    break;
                }

                if (mid * mid < x)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                    right = mid - 1;
            }
            return result;
        }

        private static int GetOneCount(int[] arr, int length)
        {
            if (length == 0) return 0;

            int left = 0, right = length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == 1 && (mid == length - 1 || arr[mid + 1] == 0))
                    return mid + 1;

                if (arr[mid] == 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return 0;
        }

        private static int GetSearchBinarySearchRec(int[] arr, int length, int x)
        {
            if (length == 0) return -1;
            return Helper(arr, x, 0, arr.Length - 1);
        }

        private static int Helper(int[] arr, int x, int left, int right)
        {
            if (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == x)
                    return 1;
                else if (x < arr[mid])
                    return Helper(arr, x, left, mid - 1);
                else
                    return Helper(arr, x, mid + 1, right);
            }
            return -1;
        }

        private static int GetSearchBinarySearch(int[] arr, int length, int x)
        {
            if (length == 0) return -1;
            int left = 0; int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == x)
                    return mid;

                if (x < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        private static int GetSearchIndex(int[] arr, int length, int x)
        {
            if (length == 0) return -1;
            for (int i = 0; i < length; i++)
            {
                if (arr[i] == x)
                    return i;
            }
            return -1;
        }
    }
}
