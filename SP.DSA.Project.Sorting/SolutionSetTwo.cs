using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class SolutionSetTwo
    {
        public static void SolutionSetTwoDemo()
        {
            SolutionSetTwo solutionObj = new SolutionSetTwo();
            //solutionObj.BubbleSortingDemo();
            //solutionObj.InsertionSortDemo();
            //solutionObj.QuickSortDemo();
            //solutionObj.BinaryArraySort();
            //solutionObj.InverCount();
            //solutionObj.UnionOFSortedArray();
            //solutionObj.FindNumberOfTriangles();
            //solutionObj.FindTriplate();
            //solutionObj.ThreeWayPartition();
            //solutionObj.Segragate012();
            //solutionObj.AbsoluteSort();
            //solutionObj.TripleSum();
            //solutionObj.KthSmallestNumber();
            //solutionObj.MergerTwoSortedArray();
            //solutionObj.MergeThreeSortedArray();

        }

        private void MergeThreeSortedArray()
        {
            int[] arr1 = { 1, 2, 3, 4 };
            int[] arr2 = { 1, 2, 3, 4, 5 };
            int[] arr3 = { 1, 2, 3, 4, 5, 6 };

            List<int> mergedList = GetFinalMergerList(arr1, arr2, arr3);
            Console.WriteLine(string.Join(", ", mergedList));
        }

        private List<int> GetFinalMergerList(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> output = MergeTwo(arr1, arr2);
            output = MergeTwo(output.ToArray(), arr3);
            return output;
        }

        private List<int> MergeTwo(int[] arr1, int[] arr2)
        {
            List<int> output = new List<int>();

            int i = 0, m = arr1.Length, j = 0, n = arr2.Length;
            while (i < m && j < n)
            {
                if (arr1[i] <= arr2[j])
                    output.Add(arr1[i++]);
                else
                    output.Add(arr2[j++]);
            }

            while (i < m)
            {
                output.Add(arr1[i++]);
            }
            while (j < n)
            {
                output.Add(arr2[j++]);
            }
            return output;
        }

        private void MergerTwoSortedArray()
        {
            int[] arr1 = { 1, 5, 9, 10, 15, 20 };
            int[] arr2 = { 2, 3, 8, 13 };
            int m = arr1.Length, n = arr2.Length, mergedSize = m + n; ;
            int[] Merged = new int[mergedSize];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (arr1[i] > arr2[j])
                {
                    Swapping(arr1, arr2, i, j);
                    i++;
                }
            }
            for (int p = 0; p < mergedSize; p++)
            {
                Console.Write(Merged[p] + " ");
            }
        }

        private void Swapping(int[] arr1, int[] arr2, int i, int j)
        {
            throw new NotImplementedException();
        }

        private void KthSmallestNumber()
        {
            int[] arr = { 7, 10, 4, 3, 20, 15 };
            int k = 3;
            int output = GetKthSmallestNumber(arr, k);
            Console.WriteLine("kth smallest number :" + output);

        }

        private int GetKthSmallestNumber(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1, kthIndex = k - 1;
            while (left <= right)
            {
                int pivot = GetPivotPointLumido(arr, left, right);

                if (pivot == kthIndex)
                    return arr[pivot];

                if (kthIndex < pivot)
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }
            return -1;
        }


        private void TripleSum()
        {
            int[] arr = { 1, 4, 45, 6, 10, 8 };
            int sum = 13;
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 2; i++)
            {
                GetTriplate(arr, i, arr.Length, sum);
            }

        }

        private void GetTriplate(int[] arr, int i, int length, int sum)
        {
            int left = i + 1, right = length - 1;
            while (left < right)
            {
                int currSum = arr[i] + arr[left] + arr[right];
                if (currSum == sum)
                {
                    Console.WriteLine("here is triplate : {0}, {1}, {2}", arr[i], arr[left], arr[right]);
                    left++;
                    right--;
                }

                if (currSum < sum)
                    left++;
                else
                    right--;
            }
        }

        private void AbsoluteSort()
        {
            int[] arr = { 10, 5, 3, 9, 2 };
            int length = arr.Length - 1; int k = 7;
            int[] output = new int[arr.Length];
            SortedList<int, List<int>> mapPosition = new SortedList<int, List<int>>();
            foreach (var item in arr)
            {
                int diff = Math.Abs(k - item);
                if (mapPosition.ContainsKey(diff))
                {
                    List<int> al = mapPosition[diff];
                    al.Add(item);
                    mapPosition[diff] = al;
                }
                else
                {
                    List<int> al = new List<int>();
                    al.Add(item);
                    mapPosition.Add(diff, al);
                }
            }
            foreach (var item in mapPosition)
            {
                foreach (var ls in item.Value)
                {
                    Console.Write(string.Join(", ", ls) + " ");
                }
            }
        }

        private void Segragate012()
        {
            int[] arr = { 0, 2, 1, 2, 0 };
            int left = 0, mid = 0, right = arr.Length - 1;
            while (mid < right)
            {
                switch (arr[mid])
                {
                    case 0:
                        Swapping(arr, left, mid);
                        left++;
                        mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        Swapping(arr, right, mid);
                        right--;
                        break;
                }
            }
            Console.WriteLine("After seggregate :" + string.Join(",", arr));
        }

        private void ThreeWayPartition()
        {
            int[] arr = { 1, 14, 5, 20, 4, 2, 54, 20, 87, 98, 3, 1, 32 };
            int a = 10, b = 20;
            int left = 0, mid = 0, right = arr.Length - 1;
            while (mid < right)
            {
                int midNumber = arr[mid];
                if (midNumber < a)
                {
                    Swapping(arr, left, mid);
                    left++;
                    mid++;
                }
                else if (midNumber > b)
                {
                    Swapping(arr, right, mid);
                    right--;
                }
                else
                {
                    mid++;
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        private void FindTriplate()
        {
            int[] arr = { 0, -1, 2, -3, 1 };
            FindTriplateCode(arr);
        }

        private void FindTriplateCode(int[] arr)
        {
            Array.Sort(arr);
            int size = arr.Length;
            for (int i = 0; i < size - 2; i++)
            {
                PrintAllTriplate(arr, i, size);
            }
        }

        private void PrintAllTriplate(int[] arr, int i, int size)
        {
            int left = i + 1, right = size - 1;
            while (left < right)
            {
                int sum = arr[i] + arr[left] + arr[right];
                if (sum == 0)
                {
                    Console.WriteLine("here is triplate : {0}, {1}, {2}", arr[i], arr[left], arr[right]);
                    left++;
                    right--;
                }

                if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        private void FindNumberOfTriangles()
        {
            int[] arr = { 4, 6, 3, 7 };
            int size = arr.Length;
            Console.WriteLine("Total number of triangles possible is " + FindNumberOfTrianglesCode(arr, size));
        }

        private int FindNumberOfTrianglesCode(int[] arr, int length)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    for (int k = j + 1; k < length; k++)
                    {
                        if (arr[i] + arr[j] > arr[k] && arr[j] + arr[k] > arr[i] && arr[i] + arr[k] > arr[j])
                            count++;
                    }
                }
            }
            return count;
        }

        private void UnionOFSortedArray()
        {
            int[] arr1 = { 2, 2, 3, 4, 5 };
            int[] arr2 = { 1, 1, 2, 3, 4 };

            List<int> output = GetUnion(arr1, arr2, arr1.Length, arr2.Length);
            Console.WriteLine(string.Join(", ", output));
        }

        private List<int> GetUnion(int[] arr1, int[] arr2, int length1, int length2)
        {
            int i = 0, j = 0;
            List<int> output = new List<int>();
            while (i < length1 && j < length2)
            {
                if (arr1[i] < arr2[j])
                {
                    if (i == 0 || arr1[i] != arr1[i - 1])
                        output.Add(arr1[i]);
                    i++;
                }
                else if (arr2[j] < arr1[i])
                {
                    if (j == 0 || arr2[j] != arr2[j - 1])
                        output.Add(arr2[j]);
                    j++;
                }
                else
                {
                    output.Add(arr1[i]);
                    i++;
                    j++;
                }
            }

            while (i < length1)
            {
                if (i == 0 || arr1[i] != arr1[i - 1])
                    output.Add(arr1[i]);
                i++;
            }

            while (j < length2)
            {
                if (j == 0 || arr2[j] != arr2[j - 1])
                    output.Add(arr2[j]);
                j++;
            }
            return output;
        }

        private void InverCount()
        {
            List<int[]> arrCollection = new List<int[]>();
            arrCollection.Add(new int[] { 1, 2, 3, 4, 5, 6, 8, 7, 10, 9 });
            arrCollection.Add(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            arrCollection.Add(new int[] { 4, 1, 3, 9, 7 });

            foreach (var arr in arrCollection)
            {
                Console.WriteLine();
                PrintArray(arr, "");
                Console.WriteLine("Inversion  :" + GetInversionCount(arr));
                Console.WriteLine();
            }
        }

        private int GetInversionCount(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                        count++;
                }
            }
            return count;
        }

        private void BinaryArraySort()
        {
            List<int[]> arrCollection = new List<int[]>();
            arrCollection.Add(new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 });
            arrCollection.Add(new int[] { 1, 1, 0, 0, 1, 1 });
            arrCollection.Add(new int[] { 1, 1, 0, 0, 1 });

            foreach (var arr in arrCollection)
            {
                Console.WriteLine();
                PrintArray(arr, "Before Sorting.");
                BinaryArraySorting(arr, 0, arr.Length - 1);
                PrintArray(arr, "Post Sorting.");
                Console.WriteLine();
            }
        }

        private void BinaryArraySorting(int[] arr, int left, int right)
        {
            int j = -1;
            for (int i = 0; i < right; i++)
            {
                if (arr[i] < 1)
                {
                    j++;
                    Swapping(arr, i, j);
                }
            }
        }

        private void QuickSortDemo()
        {
            List<int[]> arrCollection = new List<int[]>();
            arrCollection.Add(new int[] { 1, 2, 3, 4, 5, 6, 8, 7, 10, 9 });
            arrCollection.Add(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            arrCollection.Add(new int[] { 4, 1, 3, 9, 7 });

            foreach (var arr in arrCollection)
            {
                Console.WriteLine();
                PrintArray(arr, "Before Sorting.");
                QuickSorting(arr, 0, arr.Length - 1);
                PrintArray(arr, "Post Sorting.");
                Console.WriteLine();
            }
        }

        private void QuickSorting(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = GetPivotPointHoare(arr, left, right);
                QuickSorting(arr, left, pivot - 1);
                QuickSorting(arr, pivot + 1, right);
            }
        }

        private int GetPivotPointHoare(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            left = left - 1; right = right + 1;
            while (true)
            {
                do
                {
                    left++;
                } while (arr[left] < pivot);

                do
                {
                    right--;
                } while (arr[right] > pivot);

                if (left >= right) return right;
                Swapping(arr, left, right);
            }
        }

        private int GetPivotPointLumido(int[] arr, int left, int right)
        {
            int pNumber = arr[right];
            int pIndex = left - 1;
            for (int i = left; i <= right; i++)
            {
                if (arr[i] <= pNumber)
                {
                    pIndex++;
                    Swapping(arr, i, pIndex);
                }
            }
            return pIndex;
        }

        private void InsertionSortDemo()
        {
            List<int[]> arrCollection = new List<int[]>();
            arrCollection.Add(new int[] { 1, 2, 3, 4, 5, 6, 8, 7, 10, 9 });
            arrCollection.Add(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            arrCollection.Add(new int[] { 4, 1, 3, 9, 7 });

            foreach (var item in arrCollection)
            {
                PrintArray(item, "Before Sorting.");
                InsertionSorting(item, item.Length);
                PrintArray(item, "Post Sorting.");
            }
        }

        private void InsertionSorting(int[] arr, int length)
        {
            for (int i = 1; i < length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] >= key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private void BubbleSortingDemo()
        {
            //int[] arr = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] arr = { 1, 2, 3, 4, 5, 6, 8, 7, 10, 9 };
            //kint[] arr = { 4, 1, 3, 9, 7 };
            PrintArray(arr, "Before Sorting.");
            BubbleSorting(arr, arr.Length);
            PrintArray(arr, "Post Sorting.");
        }

        private void BubbleSorting(int[] arr, int length)
        {
            bool isSorted = false;
            for (int i = 0; i < length; i++)
            {
                isSorted = false;
                for (int j = 0; j < length - 1; j++)
                {
                    Console.Write(arr[j] + " ");
                    if (arr[j] >= arr[j + 1])
                    {
                        Swapping(arr, j, j + 1);
                        isSorted = false;
                    }
                }
                if (isSorted)
                    break;
                Console.WriteLine();
            }
        }

        private void Swapping(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void PrintArray(int[] arr, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("----------------------");
        }
    }
}

