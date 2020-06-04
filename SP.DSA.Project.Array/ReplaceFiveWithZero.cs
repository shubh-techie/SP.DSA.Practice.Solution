using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class ReplaceFiveWithZero
    {
        public static void convertfiveDemo()
        {
            string input = "101111100000000000000000000000011111111111111111111111111111111111111117111111111111111111111111111111111000000000000000000000000000000000000000000000111111111111111";
            Console.WriteLine("isBinary(input) " + isBinary(input));
            long[] arr = { 2, 4, 1, 3, 5 };
            //Console.WriteLine(thirdLargest(arr));
            //Console.WriteLine(convertfive(1004));
        }
        public static bool isBinary(String str)
        {
            if (str.Length == 0) return false;
            int left = 0, right = str.Length - 1;
            HashSet<char> binary = new HashSet<char>() { '1', '0' };
            while (left <= right)
            {
                if (!binary.Contains(str[left]) || !binary.Contains(str[right]))
                    return false;
                left++;
                right--;
            }
            return true;
        }

        public static long thirdLargest(long[] a)
        {
            if (a.Length < 3)
            {
                return -1;
            }
            int len = a.Length;
            for (int i = 0; i < len - 1; i++)
            {
                if (a[i + 1] > a[i])
                {
                    long item = a[i];
                    a[i] = a[i + 1];
                    a[i + 1] = item;
                }
            }
            //Arrays.sort(a);
            return a[len - 3];
            // Your code here
        }

        public static int convertfive(int num)
        {
            // Your code here
            int output = 0, count = 0;
            while (num > 0)
            {
                int mod = num % 10;
                if (mod == 0)
                    output += (int)Math.Pow(10, count) * 5;
                else
                    output += (int)Math.Pow(10, count) * mod;
                num = num / 10;
                count++;
            }

            return output;
        }
    }
}
