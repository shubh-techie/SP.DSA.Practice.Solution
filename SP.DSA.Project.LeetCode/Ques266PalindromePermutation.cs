using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques266PalindromePermutation
    {
        public static void Ques266PalindromePermutationDemo()
        {
            string[] strs = { "code", "aab", "carerac" };
            foreach (var str in strs)
            {
                Console.WriteLine("is Polindrome :" + CanPermutePalindrome(str));

            }
        }
        public static bool CanPermutePalindrome(string str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (var item in str)
            {
                if (map.ContainsKey(item))
                    map[item]++;
                else
                    map[item] = 1;
            }

            int odds = 0;
            foreach (var item in map)
            {
                if (item.Value % 2 != 0)
                    odds++;
            }

            return odds == 1;
        }
    }
}
