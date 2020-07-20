using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class UnionTwoSortedArrays
    {
        public static void UnionTwoSortedArraysDemo()
        {
            int[] arr1 = { 2, 2, 3, 4, 5 };
            int[] arr2 = { 1, 1, 2, 2, 2, 3, 4 };

            //int[] arr1 = { 1, 1, 1, 1, 1 };
            //int[] arr2 = { 2, 2, 2, 2, 2 };
            //List<int> union = GetFindUnionHashSet(arr1, arr2, arr1.Length, arr2.Length);
            List<int> union = GetFindIntersectionHashSet(arr1, arr2, arr1.Length, arr2.Length);
            Console.WriteLine(string.Join(", ", union));
        }

        private static List<int> GetFindIntersectionHashSet(int[] arr1, int[] arr2, int m, int n)
        {
            List<int> output = new List<int>();
            int i = 0, j = 0;
            while (i < m && j < n)
            {
                if (arr1[i] == arr2[j])
                {
                    if ((i == 0 || arr1[i] != arr1[i - 1]) && (j == 0 || arr2[j] != arr2[j - 1]))
                        output.Add(arr1[i]);
                    i++;
                    j++;
                }
                else if (arr1[i] < arr2[j])
                {
                    i++;
                }
                else
                    j++;
            }
            if (output.Count == 0)
                output.Add(-1);
            return output;
        }

        private static List<int> GetFindUnionHashSet(int[] arr1, int[] arr2, int m, int n)
        {
            SortedSet<int> setCollection = new SortedSet<int>();

            foreach (int item in arr1)
            {
                setCollection.Add(item);
            }

            foreach (int item in arr2)
            {
                setCollection.Add(item);
            }

            List<int> output = new List<int>();
            foreach (int item in setCollection)
            {
                output.Add(item);
            }
            return output;
        }

        private static List<int> GetFindUnion(int[] arr1, int[] arr2, int m, int n)
        {
            List<int> unionCollection = new List<int>();
            int i = 0, j = 0;
            while (i < m && j < n)
            {
                if (arr1[i] < arr2[j])
                {
                    if (!unionCollection.Contains(arr1[i]))
                        unionCollection.Add(arr1[i]);
                    i++;
                }
                else
                {
                    if (!unionCollection.Contains(arr2[j]))
                        unionCollection.Add(arr2[j]);
                    j++;
                }
            }

            while (i < m)
            {
                if (!unionCollection.Contains(arr1[i]))
                    unionCollection.Add(arr1[i]);
                i++;
            }

            while (j < n)
            {
                if (!unionCollection.Contains(arr2[j]))
                    unionCollection.Add(arr2[j]);
                j++;
            }

            return unionCollection;
        }
    }
}
