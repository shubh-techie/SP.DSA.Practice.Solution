using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques139WordBreak
    {
        public static void Ques139WordBreakDemo()
        {
            IList<string> wordDict = new List<string> { "cats", "dog", "sand", "and", "cat" };
            string s = "catsandog";
            Console.WriteLine(WordBreak(s, wordDict));
        }
        public static bool WordBreak(string s, IList<string> wordDict)
        {

            foreach (var word in wordDict)
            {
                int[] key = new int[26];
                foreach (var ch in word)
                {
                    key[ch - 'a']++;
                }
                if (!IsVaild(key, s))
                    return false;
            }

            return true;
        }

        public static bool IsVaild(int[] key, string s)
        {
            foreach (var ch in s)
            {
                key[ch - 'a']--;
            }

            foreach (var item in key)
            {
                if (item > 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
