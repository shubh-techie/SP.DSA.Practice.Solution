using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class FirstRepeatingElement
    {
        public static void FirstRepeatingElementDemo()
        {
            int[] arr = { 1, 5, 3, 4, 3, 5, 6 };
            //int[] arr = { 1, 2, 2, 1, 3 };
            int index = GetFirstRepeatingElement(arr);
            Console.WriteLine("index :" + index);
        }

        private static int GetFirstRepeatingElement(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            SortedDictionary<int, int> sorted = new SortedDictionary<int, int>();

            foreach (var item in arr)
            {
                if (map.ContainsKey(item))
                {
                    map[item]++;
                    sorted[item]++;
                }
                else
                {
                    map.Add(item, 1);
                    sorted.Add(item, 1);
                }
            }

            int index = 0;
            foreach (var item in map)
            {
                index++;
                if (item.Value > 1)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}
