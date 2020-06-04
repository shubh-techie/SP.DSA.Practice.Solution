using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques1370IncreasingDecreasingString
    {
        public static void SortString()
        {
            string sort = "aaaabbbbcccc";
            Console.WriteLine(SortString(sort));
        }
        public static string SortString(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            StringBuilder sb = new StringBuilder();
            int[] chars = new int[26];
            foreach (char ch in s)
            {
                chars[ch - 'a']++;
            }

            int count = 0;
            while (count < s.Length)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (chars[i] > 0)
                    {
                        sb.Append((char)(i + 'a'));
                        chars[i]--;
                        count++;
                    }
                }

                for (int i = 25; i >= 0; i--)
                {
                    if (chars[i] > 0)
                    {
                        sb.Append((char)(i + 'a'));
                        chars[i]--;
                        count++;
                    }
                }
            }


            return sb.ToString();
        }
    }
}
