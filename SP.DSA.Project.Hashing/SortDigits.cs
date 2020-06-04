using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class SortDigits
    {
        public static void SortDigitsDemo()
        {
            int input = 10101;
            int shored = GetShortedDigites(input);
            Console.WriteLine("shored :" + shored);
        }

        private static int GetShortedDigites(int digit)
        {
            int output = 0;
            int[] digits = new int[10];
            while (digit > 0)
            {
                if (digit % 10 != 0)
                    digits[digit % 10]++;
                digit = digit / 10;
            }

            for (int i = 0; i < 10; i++)
            {
                int count = digits[i];
                while (count > 0)
                {
                    output = output * 10 + i;
                    count--;
                }
            }

            return output;
        }
    }
}
