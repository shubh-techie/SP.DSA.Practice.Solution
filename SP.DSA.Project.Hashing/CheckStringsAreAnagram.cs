using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class CheckStringsAreAnagram
    {
        public static void CheckStringsAreAnagramDemo()
        {
            string s1 = "racecar";
            string s2 = "carrace";
            Console.WriteLine("string : {0} , string : {1} ,is Anagram :{2}", s1, s2, CheckStringsAreAnagramHelper(s1, s2));
            Console.WriteLine("string : {0} , IsPolidrome :{1}", s1, IsPolidrome(s1));
            Console.WriteLine("string : {0} , IsRearrangedPolidrome :{1}", s1, IsRearrangedPolidrome(s2));
        }

        private static bool IsRearrangedPolidrome(string s1)
        {
            Dictionary<char, int> polCheck = new Dictionary<char, int>();

            foreach (var _char in s1)
            {
                if (!polCheck.ContainsKey(_char))
                    polCheck.Add(_char, 1);
                else
                    polCheck[_char]++;
            }

            int odds = 0;
            foreach (var item in polCheck.Values)
            {
                if (item % 2 != 0) odds++;
            }

            return odds > 1 ? false : true;
        }

        public static bool IsPolidrome(string str)
        {
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                    return false;
                left++;
                right--;
            }

            return true;
        }
        private static bool CheckStringsAreAnagramHelper(string s1, string s2)
        {
            int[] chars = new int[26];

            foreach (var item in s1)
            {
                chars[item - 'a']++;
            }


            foreach (var item in s2)
            {
                chars[item - 'a']--;
                if (chars[item - 'a'] < 0)
                    return false;
            }

            return true;
        }
    }
}
