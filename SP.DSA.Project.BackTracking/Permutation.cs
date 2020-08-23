using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BackTracking
{
    public class Permutation
    {
        public static void PermutationDemo()
        {
            string str = "ABC";
            GetPermutation(str, 0, str.Length - 1);
        }

        private static void GetPermutation(string str, int index, int length)
        {
            if (index == length)
            {
                Console.WriteLine(str);
            }
            else
            {
                for (int i = index; i <= length; i++)
                {
                    if (IsSafe(str, i, index, length))
                    {
                        str = Swapping(str, index, i);
                        GetPermutation(str, index + 1, length);
                        str = Swapping(str, index, i);
                    }
                }
            }
        }

        private static bool IsSafe(string str, int i, int index, int length)
        {
            if (index != 0 && str[i - 1] == 'A' && str[i] == 'B')
                return false;

            if (index != length && str[i] == 'A' && str[i + 1] == 'B')
                return false;

            return true;
        }

        private static string Swapping(string str, int i, int j)
        {
            char[] charArray = str.ToCharArray();
            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            return new string(charArray);
        }
    }
}
