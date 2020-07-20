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
            GetPermutation(str, 0, str.Length);
        }

        private static void GetPermutation(string str, int index, int length)
        {
            if (index == length)
            {
                //if (!str.Contains("AB"))
                Console.WriteLine(str);
                return;
            }
            for (int i = index; i < length; i++)
            {
                str = Swapping(str, index, i);
                if (isSafe(str, i, index))
                    GetPermutation(str, index + 1, length);
                str = Swapping(str, index, i);
            }
        }

        private static bool isSafe(string str, int i, object j)
        {
            throw new NotImplementedException();
        }

        private static string Swapping(string str, int i, int j)
        {
            char[] charArray = str.ToCharArray();
            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return new string(charArray);
        }
    }
}
