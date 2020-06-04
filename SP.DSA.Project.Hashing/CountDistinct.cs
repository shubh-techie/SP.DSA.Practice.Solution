using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class CountDistinct
    {
        public static void CountDistinctDemo()
        {
            int[] arr = { 1, 1, 2, 2, 3, 3, 4, 5, 6, 7 };
            int count = GetCountDistinct(arr);
            Console.WriteLine("Count :" + count);
        }

        private static int GetCountDistinct(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
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
                    count++;
            }

            return count;
        }
    }
}
