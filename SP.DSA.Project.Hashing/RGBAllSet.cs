using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class RGBAllSet
    {
        public static void RGBSetDemo()
        {
            string str = "rbgrbrgrgbgrrggbbbbrgrgrgrg";
            int outut = GetAllRGBSetCount(str);
            Console.WriteLine(outut);
        }

        private static int GetAllRGBSetCount(string str)
        {

            Dictionary<char, int> rgbCount = new Dictionary<char, int>();

            foreach (char item in str)
            {
                if (rgbCount.ContainsKey(item))
                {
                    rgbCount[item]++;
                }
                else
                    rgbCount.Add(item, 1);
            }

            if (rgbCount.Count < 3) return 0;

            int count = int.MaxValue;
            foreach (var item in rgbCount)
            {
                count = Math.Min(item.Value, count);
            }

            return count;
        }
    }
}
