using System;
using System.Collections.Generic;

namespace SP.DSA.Project.ArrayDemo
{
    public class UnionofTwoSortedArrays
    {
        public static void UnionofTwoSortedArraysDemo()
        {
            int[] arr1 = { 1 ,1 ,1, 1 ,1 };
            int[] arr2 = { 2, 2 ,2 ,2, 2 };
            List<int> result = GetUnionofTwoSortedArrays(arr1, arr2);
            Console.WriteLine(string.Join(",", result));
        }

        private static List<int> GetUnionofTwoSortedArrays(int[] arr1, int[] arr2)
        {
            List<int> result = new List<int>();

            HashSet<int> set = new HashSet<int>();
            foreach (var item in arr1)
            {
                if (!set.Contains(item))
                {
                    set.Add(item);
                    result.Add(item);
                }
            }


            foreach (var item in arr2)
            {
                if (!set.Contains(item))
                {
                    result.Add(item);
                    set.Add(item);
                }
            }

            return result;
        }
    }
}
