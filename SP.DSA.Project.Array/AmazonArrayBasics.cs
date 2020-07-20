using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class AmazonArrayBasics
    {
        public static void AmazonArrayBasicsDemo()
        {
            //RearrangeAnArrayStart();
            //ContainerWithMostWaterStart();
            //TrappingRainWaterStart();
            //KadaneAlgorithmStart();
            //SubarrayWithGivenSumStart();
            //MaxIndexStart();
            //ProductArrayPuzzleStart();
            //SticklerThiefStart();
            //EquilibriumPointStart();
            //WaveArray();
            //MountainSubArray();
            //FindDuplicatesInArray();
            //SortedSubsequenceStart();
            //MaxSumCnfiguration();
            //RemoveDuplicateStart();
            //MaximumSumPathStart();
            //RotateAnArrayStart();
            //MinimumDistance();
            //MaxAndSecondMax();
            //ThirdLargestElement();
            //ReplaceZeroWithFive();
        }

        private static void RearrangeAnArrayStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 3, 2, 0, 1 });
            arrColl.Add(new int[] { 4, 0, 2, 1, 3 });
            arrColl.Add(new int[] { 0, 1, 2, 3 });
            arrColl.Add(new int[] { 0, 1, 2, 3 });
            foreach (var arr in arrColl)
            {
                GetUpdatedArray(arr, arr.Length);
            }
        }

        private static void GetUpdatedArray(int[] arr, int length)
        {
            Console.WriteLine("Before update :" + string.Join(", ", arr));
            for (int i = 0; i < length; i++)
            {
                arr[i] += (arr[arr[i]] % length) * length;
            }
            Console.WriteLine("After after :" + string.Join(", ", arr));

            for (int i = 0; i < length; i++)
                arr[i] /= length;

            Console.WriteLine("After after :" + string.Join(", ", arr));
            Console.WriteLine("............................");

        }

        private static void ContainerWithMostWaterStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 1, 5, 4, 3 });
            arrColl.Add(new int[] { 3, 1, 2, 4, 5 });
            foreach (var arr in arrColl)
            {
                Console.WriteLine("Container max water :" + GetContainerWater(arr));
            }
        }

        private static int GetContainerWater(int[] arr)
        {
            int left = 0, right = arr.Length - 1, uMax = 0;

            while (left < right)
            {
                uMax = Math.Max(uMax, Math.Min(arr[left], arr[right]) * (right - left));
                if (arr[left] < arr[right])
                    left++;
                else
                    right--;
            }

            return uMax;
        }

        private static void TrappingRainWaterStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 3, 0, 0, 2, 0, 4 });
            arrColl.Add(new int[] { 7, 4, 0, 9 });
            arrColl.Add(new int[] { 6, 9, 9 });
            arrColl.Add(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            foreach (var arr in arrColl)
            {
                Console.WriteLine("max water :" + GetTrappingWater(arr));
            }
        }

        private static int GetTrappingWater(int[] arr)
        {
            int lmax = 0, rMax = 0, left = 0, right = arr.Length - 1, uMax = 0;

            while (left <= right)
            {
                if (arr[left] < arr[right])
                {
                    if (lmax < arr[left])
                        lmax = arr[left];
                    else
                        uMax += lmax - arr[left];

                    left++;
                }
                else
                {
                    if (rMax < arr[right])
                        rMax = arr[right];
                    else
                        uMax += rMax - arr[right];

                    right--;
                }
            }

            return uMax;
        }

        private static void KadaneAlgorithmStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 1, 2, 3, -2, 5 });
            arrColl.Add(new int[] { -1, -2, -3, -4 });

            foreach (var arr in arrColl)
            {
                Console.WriteLine("Max sum :" + GetMaximumSum(arr));
            }
        }

        private static int GetMaximumSum(int[] arr)
        {
            int lMax = arr[0], uMax = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                lMax = Math.Max(lMax + arr[i], arr[i]);
                uMax = Math.Max(lMax, uMax);
            }

            return uMax;
        }

        private static void SubarrayWithGivenSumStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 1, 2, 3, 7, 5 });
            arrColl.Add(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            arrColl.Add(new int[] { 5, 7, 1, 2 });
            int[] sum = { 12, 15, 15 };
            for (int i = 0; i < 3; i++)
            {
                subarraySumHelper(arrColl[i], sum[i]);
            }
        }

        private static void subarraySumHelper(int[] arr, int sum)
        {
            int start = 0, size = arr.Length, currSum = 0;
            bool isFound = false;
            for (int i = 0; i < size; i++)
            {
                currSum += arr[i];
                while (currSum > sum && start < i)
                {
                    currSum -= arr[start];
                    start++;
                }

                if (currSum == sum)
                {
                    int startPistion = start + 1;
                    int endPosition = i + 1;
                    Console.WriteLine("start: {0}, end: {1}", startPistion, endPosition);
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
                Console.WriteLine("There is no such sub array.");

        }

        private static void MaxIndexStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 1, 10 });
            arrColl.Add(new int[] { 34, 8, 10, 3, 2, 80, 30, 33, 1 });
            arrColl.Add(new int[] { 9, 2, 3, 4, 5, 6, 7, 8, 18, 0 });
            arrColl.Add(new int[] { 1, 2, 3, 4, 5, 6 });
            arrColl.Add(new int[] { 6, 5, 4, 3, 2, 1 });
            foreach (var arr in arrColl)
            {
                Console.WriteLine("max Index " + GetMaxIndex(arr, arr.Length));
            }
        }

        private static int GetMaxIndex(int[] arr, int length)
        {
            int index = -1;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        index = Math.Max(j - i, index);
                    }
                }
            }

            return index;
        }

        private static void ProductArrayPuzzleStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 10, 3, 5, 6, 2 });
            arrColl.Add(new int[] { 12, 0 });

            foreach (var arr in arrColl)
            {
                int[] output = GetproductArray(arr);
            }
        }

        private static int[] GetproductArray(int[] arr)
        {
            int uPro = 1, size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] != 0)
                    uPro *= arr[i];
            }

            int[] output = new int[size];

            for (int i = 0; i < size; i++)
            {
                output[i] = (int)(uPro * Math.Pow(arr[i], -1));
            }

            Console.WriteLine("Here is output :" + string.Join(", ", output));

            return output;
        }

        private static void SticklerThiefStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 5, 5, 10, 100, 10, 5 });
            arrColl.Add(new int[] { 1, 2, 3 });
            arrColl.Add(new int[] { 6, 7, 1, 3, 8, 2, 4 });
            arrColl.Add(new int[] { 5, 3, 4, 11, 2 });

            foreach (var arr in arrColl)
            {
                int[] cache = new int[arr.Length + 1];
                Console.WriteLine("Optimized money loot :" + GetOpMizedMoneyLoot(arr, 0, cache));
            }
        }

        private static int GetOpMizedMoneyLoot(int[] arr, int currIndex, int[] cache)
        {
            if (currIndex >= arr.Length)
                return 0;

            if (cache[currIndex] >= 0)
                return cache[currIndex];

            int first = arr[currIndex] + GetOpMizedMoneyLoot(arr, currIndex + 2, cache);
            int skipFirst = GetOpMizedMoneyLoot(arr, currIndex + 1, cache);

            //int result = Math.Max(first, skipFirst);
            cache[currIndex] = Math.Max(first, skipFirst);
            return cache[arr.Length];
        }

        private static void EquilibriumPointStart()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 1, 3, 5, 2, 2 });
            arrColl.Add(new int[] { 1 });
            arrColl.Add(new int[] { -7, 1, 5, 2, -4, 3, 0 });

            foreach (var arr in arrColl)
            {
                Console.WriteLine("Here is equilibrium Point :" + GetEquilibriamPoints(arr));
            }
        }

        private static int GetEquilibriamPoints(int[] arr)
        {
            if (arr.Length == 1) return 1;

            int RightSum = 0, leftSum = 0, size = arr.Length;

            foreach (var item in arr)
            {
                RightSum += item;
            }

            for (int i = 0; i < size; i++)
            {
                leftSum += arr[i];
                if (leftSum == RightSum)
                    return i + 1;
                RightSum -= arr[i];
            }

            return -1;
        }

        private static void WaveArray()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 1, 2, 3, 4, 5 });
            arrColl.Add(new int[] { 2, 4, 7, 8, 9, 10 });

            foreach (var arr in arrColl)
            {
                WaveArrayDemo(arr, arr.Length);
            }
        }

        private static void WaveArrayDemo(int[] arr, int n)
        {
            Console.WriteLine("Before wave :" + string.Join(", ", arr));
            for (int i = 0; i < n - 1; i += 2)
            {
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
            Console.WriteLine("After wave :" + string.Join(", ", arr));
        }

        private static void MountainSubArray()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 2, 3, 2, 4, 4, 6, 3, 2 });
            //arrColl.Add(new int[] { 2, 3, 2, 4, 4, 6, 3, 2 });
            List<int> Pair = new List<int>() { 1, 3 };

            foreach (var arr in arrColl)
            {
                PrintDuplicate(arr, Pair);
            }
        }

        private static void PrintDuplicate(int[] arr, List<int> pair)
        {
            int left = pair[0];
            int right = pair[1];
            int i = 0, n = arr.Length;
            for (i = left; i < n; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    break;
                }
            }

            for (; i < right; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    Console.WriteLine("this is not valid mountain.");
                    return;
                }
            }

            Console.WriteLine("this is a pefect mountain.");
        }

        private static void FindDuplicatesInArray()
        {
            List<int[]> arrColl = new List<int[]>();
            arrColl.Add(new int[] { 0, 3, 1, 2 });
            arrColl.Add(new int[] { 2, 3, 1, 2, 3 });
            foreach (var arr in arrColl)
            {
                PrintDuplicate(arr);
            }
        }

        private static void PrintDuplicate(int[] arr)
        {
            Console.WriteLine("=============Checking for array");
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine();
            HashSet<int> seen = new HashSet<int>();
            bool duplicate = false;
            foreach (var item in arr)
            {
                if (seen.Contains(item))
                {
                    Console.Write("{0}, ", item);
                    duplicate = true;
                }
                else
                    seen.Add(item);
            }

            Console.WriteLine();
            if (duplicate)
                Console.WriteLine("these is no duplicate in this array");

        }

        private static void SortedSubsequenceStart()
        {
            List<int[]> arrColl = new List<int[]>();
            //arrColl.Add(new int[] { 1, 2, 3, 2 });
            //arrColl.Add(new int[] { 86, 39, 90, 67, 84, 66, 62 });
            //arrColl.Add(new int[] { 22, 21, 19, 15, 16, 12, 35 });
            arrColl.Add(new int[] { 3, 4, 6, 9 });
            foreach (int[] arr in arrColl)
            {
                List<int> result = GetSortedSubsequenceNaive(arr);
                Console.WriteLine("output :" + string.Join(",", result.Count));
            }
        }

        private static List<int> GetSortedSubsequenceNaive(int[] arr)
        {
            List<int> output = new List<int>();
            int n = arr.Length, minIndex = 0, maxIndex = n - 1;
            int[] seeMin = new int[n];
            int[] seeMax = new int[n];

            seeMin[0] = -1; seeMax[n - 1] = -1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] <= arr[minIndex])
                {
                    seeMin[i] = -1;
                    minIndex = i;
                }
                else
                    seeMin[i] = minIndex;
            }

            Console.WriteLine("arry index     table " + string.Join(",", arr));

            Console.WriteLine("seen min index table " + string.Join(",", seeMin));

            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] >= arr[maxIndex])
                {
                    seeMax[i] = -1;
                    maxIndex = i;
                }
                else
                    seeMax[i] = maxIndex;
            }

            Console.WriteLine("seen max index table " + string.Join(",", seeMax));


            for (int i = 0; i < n; i++)
            {
                if (seeMin[i] != -1 && seeMax[i] != -1)
                {
                    Console.Write(arr[seeMin[i]] + " " + arr[i] + " " + arr[seeMax[i]] + " ");
                }
                Console.WriteLine();
            }

            return output;
        }

        private static List<int> GetSortedSubsequence(int[] arr)
        {
            Stack<int> result = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (result.Count > 0)
                {
                    if (arr[i] > result.Peek())
                        result.Push(arr[i]);
                    else
                    {
                        result.Pop();
                        result.Push(arr[i]);
                    }
                }
                if (result.Count == 0)
                    result.Push(arr[i]);

                if (result.Count == 3)
                    break;
            }

            Console.WriteLine(" Here is the result :" + string.Join(",", result));

            if (result.Count == 3)
                return result.ToList();

            return new List<int>();
        }

        private static void MaxSumCnfiguration()
        {
            int[] arr = { 8, 3, 1, 2 };
            int uMax = 0, result = 0;
            int count = 0, n = arr.Length;
            while (count < n)
            {
                result = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    result = result + arr[i + count] * 1;
                }
                uMax = Math.Max(result, uMax);
                count++;
            }
            Console.WriteLine("Max Configuration " + uMax);
        }

        private static void RotateByOne(int[] arr, int length)
        {
            int temp = arr[0];
            int i = 0;
            for (i = 0; i < length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[i] = temp;
        }

        private static void RemoveDuplicateStart()
        {
            int[] arr = { 2, 2, 3, 3, 5, 7 };
            int start = 0, n = arr.Length;
            Console.WriteLine("Before modification :" + string.Join(",", arr));

            arr = getUniqueArray(arr);


            //for (int i = 0; i < n; i++)
            //{
            //    if (arr[start] != arr[i])
            //    {
            //        start++;
            //        arr[start] = arr[i];
            //    }
            //}

            Console.WriteLine("After modification :" + string.Join(",", arr));
        }

        private static int[] getUniqueArray(int[] arr)
        {
            int[] result = new int[100];
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                result[arr[i]]++;
            }

            List<int> output = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                if (result[i] != 0)
                    output.Add(i);
            }

            return output.ToArray();
        }

        private static void MaximumSumPathStart()
        {
            int[] A = { 2, 3, 7, 10, 12 };
            int[] B = { 1, 5, 7, 8 };
            int n1 = A.Length;
            int n2 = B.Length;

            int maxSum = GetMaxSum(A, B, n1, n2);
            Console.WriteLine("max sum = {0}", maxSum);
        }

        private static int GetMaxSum(int[] a, int[] b, int n1, int n2)
        {
            int i = 0, sum = 0;
            for (i = 0; i < n2; i++)
            {
                sum += Math.Max(a[i], b[i]);
            }

            for (; i < n1; i++)
            {
                sum += a[i];
            }

            return sum;
        }

        private static void RotateAnArrayStart()
        {
            //int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            //int d = 3;

            int[] arr = { 1, 2, 3, 4, 5 };
            int d = 2;
            int n = arr.Length;

            Console.WriteLine(string.Join(", ", arr));
            if (d < n)
            {
                ReverseAnArray(arr, 0, d - 1);
                ReverseAnArray(arr, d, n - 1);
                ReverseAnArray(arr, 0, n - 1);
            }
            Console.WriteLine("Post rotation.");
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void ReverseAnArray(int[] arr, int left, int right)
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

        private static void MinimumDistance()
        {
            List<int[]> collection = new List<int[]>();
            collection.Add(new int[] { 1, 2, 3, 2 });
            collection.Add(new int[] { 86, 39, 90, 67, 84, 66, 62 });
            int x = 1, y = 2;
            int minDistance = GetMinDistance(collection[0], x, y);
            Console.WriteLine("min distance :" + minDistance);
        }

        private static int GetMinDistance(int[] arr, int x, int y)
        {
            int xIndex = 0, yIndex = 0, min = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                    xIndex = i + 1;
                if (arr[i] == y)
                    yIndex = i + 1;

                if (xIndex != 0 && yIndex != 0)
                    min = Math.Min(min, Math.Abs(xIndex - yIndex));
            }

            if (min != int.MaxValue)
                return min;
            return -1;
        }

        private static void MaxAndSecondMax()
        {
            List<int[]> collection = new List<int[]>();
            collection.Add(new int[] { 1, 2, 3, 4, 5 });
            collection.Add(new int[] { 2, 1, 2, 6 });
            collection.Add(new int[] { 5, 5 });
            collection.Add(new int[] { 9, 6, 8, 7, 10 });
            foreach (var arr in collection)
            {
                GetMaxAndSecondMax(arr);
            }
        }

        private static void GetMaxAndSecondMax(int[] arr)
        {
            int max = arr[0], min = -1, size = arr.Length;
            for (int i = 1; i < size; i++)
            {
                if (max < arr[i])
                {
                    min = max;
                    max = arr[i];
                }
                else if (max != arr[i])
                {
                    min = Math.Max(arr[i], min);
                }
            }
            Console.WriteLine("The max two numbers are :{0}, {1}", max, min);

        }

        private static void GetMaxAndSecondMaxUsingHashing(int[] arr)
        {
            HashSet<int> trackMax = new HashSet<int>();
            int max1 = -1, max2 = -1, size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                trackMax.Add(arr[i]);
                if (trackMax.Count > 2)
                {
                    trackMax.Remove(trackMax.Min());
                }
            }

            if (trackMax.Count == 2)
                Console.WriteLine("The max two numbers are :{0}, {1}", trackMax.Max(), trackMax.Min());
            else
                Console.WriteLine("The max two numbers are :{0}, {1}", trackMax.Max(), -1);

        }

        private static void ThirdLargestElement()
        {
            List<int[]> collection = new List<int[]>();
            collection.Add(new int[] { 1, 2, 3, 4, 5 });
            collection.Add(new int[] { 2, 1, 2 });
            collection.Add(new int[] { 10, 2 });

            foreach (int[] arr in collection)
            {
                Console.WriteLine("third largest element : " + GetThirdLargetstUsingPartition(arr, 3));
            }
            //int thirdElement = GetThirdLargestElementUsingSorting(arr);
            //Console.WriteLine("Third element using sorting :{0}", thirdElement);
            //int third = GetThirdLargestElement(arr);
            //Console.WriteLine("Third element :{0}", third);
        }

        private static int GetThirdLargetstUsingPartition(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1, size = arr.Length;
            while (left <= right)
            {
                int pivot = getPivotUsingLomuto(arr, left, right);
                if (pivot == size - k)
                    return arr[pivot];

                if (pivot < size - k)
                    left = pivot + 1;
                else
                    right = pivot - 1;
            }

            return -1;
        }

        private static int getPivotUsingLomuto(int[] arr, int left, int right)
        {
            int j = left - 1, pNum = arr[right];
            for (int i = left; i <= right; i++)
            {
                if (arr[i] <= pNum)
                {
                    j++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            return j;
        }

        private static int GetThirdLargetst(int[] arr)
        {
            Array.Sort(arr);
            if (arr.Length < 3)
            {
                return arr[arr.Length - 1];
            }
            return arr[arr.Length - 3];
        }

        private static int GetThirdLargestElementUsingSorting(int[] arr)
        {
            Array.Sort(arr);
            if (arr.Length < 3)
            {
                return arr[arr.Length - 1];
            }
            return arr[arr.Length - 3];
        }

        private static int GetThirdLargestElement(int[] arr)
        {
            HashSet<int> track = new HashSet<int>();
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                track.Add(arr[i]);
                if (track.Count >= 3)
                    track.Remove(track.Max());
            }

            if (track.Count == 3)
                return track.Min();

            return track.Min();
        }

        private static void ReplaceZeroWithFive()
        {
            int[] arr = { 10000, 100005, 8978005, 90000007 };
            foreach (var item in arr)
            {
                int output = GetModifiedNumber(item);
                Console.WriteLine($"no :{item} , updatedwith :{output}");
            }
        }

        private static int GetModifiedNumber(int number)
        {
            if (number == 0) return 5;
            int result = 0, dec = 1;
            while (number > 0)
            {
                int rem = number % 10 == 0 ? 5 : number % 10;
                result += rem * dec;
                number /= 10;
                dec *= 10;
            }
            return result;
        }
    }
}
