using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class IntersectionOfTwoArrays
    {
        public static void IntersectionOfTwoArraysDemo()
        {
            //int[] arr1 = { 89, 24, 75, 11, 23 };
            //int[] arr2 = { 89, 2, 4 };

            //int[] arr1 = { 1, 2 ,3 ,4 ,5, 6 };
            //int[] arr2 = { 3 ,4 ,5 ,6 ,7 };

            int[] arr1 = { 10, 10, 10 };
            int[] arr2 = { 10, 10, 10 };

            List<int> result = GetIntersectionOfTwoArrays(arr1, arr2);
            Console.WriteLine(string.Join(",", result));
        }

        private static List<int> GetIntersectionOfTwoArrays(int[] arr1, int[] arr2)
        {
            List<int> result = new List<int>();
            HashSet<int> set = new HashSet<int>();

            foreach (var item in arr1)
            {
                set.Add(item);
            }

            foreach (var item in arr2)
            {
                if (set.Contains(item))
                {
                    result.Add(item);
                    set.Remove(item);
                }
            }

            return result;
        }
    }
}
