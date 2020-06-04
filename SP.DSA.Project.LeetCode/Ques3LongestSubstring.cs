using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques3LongestSubstring
    {
        public static void LengthOfLongestSubstring()
        {
            string str = "abcabcbb";
            int maxLength = LengthOfLongestSubstringEfficent(str);
            Console.WriteLine(maxLength);
        }

        public static int LengthOfLongestSubstringEfficent(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (s.Length == 1) return 1;
            int uMaxLen = 0, len = s.Length, j = 0;
            HashSet<char> track = new HashSet<char>();

            for (int i = 0; i < len; i++)
            {
                while (j < len && !track.Contains(s[j]))
                {
                    track.Add(s[j]);
                    j++;
                    uMaxLen = Math.Max(uMaxLen, track.Count);
                }
                track.Remove(s[i]);
            }

            return uMaxLen;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (s.Length == 1) return 1;
            int uMaxLen = 0, len = s.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j <= len; j++)
                {
                    if (isUnique(s, i, j))
                        uMaxLen = Math.Max(uMaxLen, j - i);
                    else
                        break;
                }
            }

            return uMaxLen;
        }

        private static bool isUnique(string str, int start, int end)
        {
            HashSet<char> track = new HashSet<char>();

            for (int i = start; i < end; i++)
            {
                if (track.Contains(str[i])) return false;
                else
                    track.Add(str[i]);
            }

            return true;
        }
    }
}
