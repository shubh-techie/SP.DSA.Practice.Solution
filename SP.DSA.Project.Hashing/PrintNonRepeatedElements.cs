using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class PrintNonRepeatedElements
    {
        public static void PrintNonRepeatedElementsDemo()
        {
            int[] arr = { 10, 20, 40, 30, 10 };
            List<int> result = GetCountDistinct(arr);
            Console.WriteLine(string.Join(",", result));
        }

        private static List<int> GetCountDistinct(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach (int item in arr)
            {
                if (map.ContainsKey(item))
                    map[item]++;
                else
                    map.Add(item, 1);
            }
            int count = 0;
            foreach (var item in map)
            {
                if (item.Value == 1)
                {
                    result.Add(item.Key); count++;
                }
            }

            return result;
        }

        private static List<int> GetNonRepeatedElements(int[] arr)
        {
            HashSet<int> unique = new HashSet<int>();
            foreach (var item in arr)
            {
                if (!unique.Contains(item))
                    unique.Add(item);
            }
            return unique.ToList();
        }
    }
}
