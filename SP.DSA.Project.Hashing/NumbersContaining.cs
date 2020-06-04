using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class NumbersContaining
    {
        public static void NumbersContainingDemo()
        {
            // int[] arr = { 12, 111, 34, 13, 55 };
            int[] arr = { 1, 2, 3, 4 };
            HashSet<int> set = new HashSet<int>() { 1, 2, 3 };
            List<int> setResult = GetNumbersContaining(arr, set);
            Console.WriteLine(string.Join(",  ", setResult));

        }

        private static List<int> GetNumbersContaining(int[] arr, HashSet<int> set)
        {
            List<int> result = new List<int>();
            foreach (var item in arr)
            {
                if (set.Contains(item % 10))
                    result.Add(item);
            }
            if (result.Count == 0)
                result.Add(-1);
            return result;
        }
    }
}
