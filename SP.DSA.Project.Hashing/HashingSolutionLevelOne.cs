using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{


    public class HashingSolutionLevelOne
    {
        public static void HashingSolutionLevelOneStart()
        {
            //DirectAddressTableForHashing();
            //SeparateChaining();
            //CountNonReapeated();
            //Intersaction();
            //UnionOfArray();
            //TwoSum();
            //IsArrayEqual();
            //PrintSet();
            //FindSumSubSet();
            //FindZeroSumSubArray();
            LongestSubsequence();
        }

        private static void LongestSubsequence()
        {
            List<int[]> collection = new List<int[]>();
            collection.Add(new int[] { 2, 6, 1, 9, 4, 5, 3 });
            collection.Add(new int[] { 1, 9, 3, 10, 4, 20, 2 });

            foreach (var item in collection)
            {
                int n = item.Length;
                int lcsLength = GetlCS(item, n);
                Console.WriteLine("LCS :" + lcsLength);
            }
        }


        private static int GetlCS(int[] arr, int n)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var item in arr)
            {
                set.Add(item);
            }


            int result = 0, count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!set.Contains(arr[i] - 1))
                {
                    count = 1;
                    while (set.Contains(arr[i] + count))
                    {
                        count++;
                    }
                    result = Math.Max(result, count);
                }
            }


            return result;
        }

        private static void FindZeroSumSubArray()
        {
            // int[] arr = { 0, 0, 5, 5, 0, 0 };
            int[] arr = { 6, -1, -3, 4, -2, 2, 4, 6, -12, -7 };
            int sum = 0;
            List<List<int>> output = GetFindZeroSubArray(arr, sum);
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }


        private static List<List<int>> GetFindZeroSubArray(int[] arr, int sum)
        {
            List<List<int>> result = new List<List<int>>();
            SortedDictionary<int, List<int>> map = new SortedDictionary<int, List<int>>();
            List<int> ls = null;
            int currSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];

                if (currSum == sum)
                    result.Add(new List<int>() { 0, i });


                if (map.ContainsKey(currSum - sum))
                {
                    ls = map[currSum - sum];

                    for (int it = 0; it < ls.Count; it++)
                    {
                        result.Add(new List<int>() { ls[it] + 1, i });
                    }
                }

                if (map.ContainsKey(currSum))
                {
                    map[currSum].Add(i);
                }
                else
                {
                    ls = new List<int>() { i };
                    map.Add(currSum, ls);
                }
            }
            return result;
        }

        private static void FindSumSubSet()
        {
            // int[] arr = { 4, 2, -3, 1, 6 };
            int[] arr = { 10, 2, -2, -20, 10 };
            int sum = -10;
            Console.WriteLine(IsSumPresent(arr, sum));
        }

        private static int IsSumPresent(int[] arr, int sum)
        {
            int currSum = 0;
            Dictionary<int, int> set = new Dictionary<int, int>();

            int count = 0;

            foreach (var item in arr)
            {
                currSum += item;

                if (currSum == sum)
                {
                    count++;
                }
                int otherPair = currSum - sum;
                if (set.ContainsKey(otherPair))
                {
                    count += set[otherPair];
                }

                if (set.ContainsKey(currSum))
                    set[currSum]++;
                else
                    set.Add(currSum, 1);
            }
            return count;
        }

        private static void PrintSet()
        {
            int[] arr = { 12, 111, 34, 13, 55 };
            HashSet<int> set = new HashSet<int>() { 1, 2, 3 };
            List<int> resultSet = GetSetResult(arr, set);
            Console.WriteLine(string.Join(", ", resultSet));
        }

        private static List<int> GetSetResult(int[] arr, HashSet<int> set)
        {
            List<int> result = new List<int>();

            foreach (var item in arr)
            {
                if (IsValid(item, set))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static bool IsValid(int item, HashSet<int> set)
        {
            while (item > 0)
            {
                if (set.Contains(item % 10))
                {
                    return true; ;
                }
                item = item / 10;
            }

            return false;
        }

        private static void IsArrayEqual()
        {
            int[] arr = { 1, 2, 5 };
            int[] arr2 = { 1, 4, 15 };
            Console.WriteLine(IsSame(arr, arr2));

        }

        private static bool IsSame(int[] arr, int[] arr2)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (var item in arr)
            {
                seen.Add(item);
            }

            foreach (var item in arr2)
            {
                if (!seen.Contains(item))
                {
                    return false;
                }

            }
            return true;
        }

        private static void TwoSum()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = 14;
            Console.WriteLine(IsSum(arr, sum));
        }

        private static bool IsSum(int[] arr, int sum)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int otherPair = sum - arr[i];
                if (set.Contains(otherPair))
                    return true;
                else
                    set.Add(arr[i]);
            }
            return false;
        }

        private static void UnionOfArray()
        {
            int[] arr1 = { 85, 25, 1, 32, 54, 6 };
            int[] arr2 = { 85, 2 };
            List<int> output = GetUnion(arr1, arr2);
            Console.WriteLine(string.Join(", ", output));
        }

        private static List<int> GetUnion(int[] arr1, int[] arr2)
        {
            HashSet<int> set = new HashSet<int>();
            List<int> output = new List<int>();
            foreach (var item in arr1)
            {
                if (!set.Contains(item))
                {
                    output.Add(item);
                    set.Add(item);
                }
                else
                    set.Add(item);
            }

            foreach (var item in arr2)
            {
                if (!set.Contains(item))
                {
                    output.Add(item);
                    set.Add(item);
                }
                else
                    set.Add(item);
            }

            return output;
        }

        private static void Intersaction()
        {
            int[] arr1 = { 10, 10, 10, 10 };
            int[] arr2 = { 20, 20, 20, 20 };
            List<int> output = GetIntersaction(arr1, arr2);
            Console.WriteLine(string.Join(", ", output));
        }

        private static List<int> GetIntersaction(int[] arr1, int[] arr2)
        {
            HashSet<int> seen = new HashSet<int>();
            List<int> result = new List<int>();
            foreach (var item in arr1)
            {
                seen.Add(item);
            }

            foreach (var item in arr2)
            {
                if (seen.Contains(item))
                {
                    result.Add(item);
                    seen.Remove(item);
                }
            }

            return result;
        }

        private static void CountNonReapeated()
        {
            int[] arr = { 0, 9, 2, 3, 4, 8, 7 };
            List<int> result = GetItem(arr);
            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> GetItem(int[] arr)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach (var item in arr)
            {
                if (seen.ContainsKey(item))
                {
                    seen[item]++;
                }
                else
                    seen[item] = 1;
            }
            foreach (var item in seen)
            {
                if (item.Value == 1)
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }

        private static void SeparateChaining()
        {
            int[] arr = { 92, 4, 14, 24, 44, 91, 12, 45, 36, 87, 11 };
            int n = arr.Length;
            int hashSize = 10;
            List<List<int>> output = GetSeparateChaining(arr, n, hashSize);
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        private static List<List<int>> GetSeparateChaining(int[] arr, int n, int hashSize)
        {
            List<List<int>> output = new List<List<int>>();
            for (int i = 0; i < hashSize; i++)
            {
                output.Add(new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                int chainIndex = arr[i] % 10;
                output[chainIndex].Add(arr[i]);
            }
            return output;
        }

        private static void DirectAddressTableForHashing()
        {
            MyHash hashSet = new MyHash(1000);
            Console.WriteLine(hashSet.Search(100));
            hashSet.Insert(100);
            Console.WriteLine(hashSet.Search(100));
            hashSet.Delete(100);
            Console.WriteLine(hashSet.Search(100));
        }

        public class MyHash
        {
            private readonly bool[] Hashtable;
            private int Size;
            public MyHash(int size)
            {
                this.Size = size;
                Hashtable = new bool[size];
            }

            public void Insert(int val)
            {
                if (Hashtable[val] == false)
                    Hashtable[val] = true;
            }

            public bool Search(int val)
            {
                if (Hashtable[val] == true)
                    return true;
                else
                    return false;
            }

            public void Delete(int val)
            {
                if (Hashtable[val] == true)
                    Hashtable[val] = false;
            }
        }
    }
}
