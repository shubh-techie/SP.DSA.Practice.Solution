using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class Quest438FindAllAnagramsString
    {
        public static void FindAnagramsDemo()
        {
            string s = "cbaebabacd";
            string p = "abc";
            IList<int> output = FindAnagramsHelper(s, p);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        public static IList<int> FindAnagramsHelper(string s, string p)
        {
            IList<int> output = new List<int>();
            int sLen = s.Length, pLen = p.Length, j = 0;
            int[] pCount = new int[26];

            foreach (var item in p)
            {
                pCount[item - 'a']++;
            }
            for (int i = 0; i < s.Length - pLen; i++)
            {
                j = 0;
                int[] sCount = new int[26];
                while (j < pLen)
                {
                    sCount[s[i + j] - 'a']++;
                    j++;
                }

                if (IsAnagramCheck(sCount, pCount))
                {
                    output.Add(i);
                }

            }
            return output;
        }
        public static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> output = new List<int>();
            int sLen = s.Length, pLen = p.Length;

            int[] sCount = new int[26];
            int[] pCount = new int[26];

            // pattern array 
            foreach (char ch in p)
            {
                pCount[ch - 'a']++;
            }


            for (int i = 0; i < s.Length; i++)
            {
                sCount[s[i] - 'a']++;
                if (i >= pLen)
                {
                    sCount[s[i - pLen] - 'a']--;
                }

                if (IsAnagramCheck(pCount, sCount))
                {
                    output.Add(i - pLen + 1);
                }
            }


            return output;
        }

        private static bool IsAnagramCheck(int[] pCount, int[] sCount)
        {
            for (int i = 0; i < 26; i++)
            {
                if (pCount[i] != sCount[i])
                    return false;
            }

            return true;
        }

        public static bool IsAnagram(string s1, string s2)
        {
            int[] arr = new int[26];

            foreach (var item in s1)
            {
                arr[item - 'a']++;
            }
            foreach (var item in s2)
            {
                arr[item - 'a']--;
            }

            foreach (var item in arr)
            {
                if (item != 0)
                    return false;
            }

            return true;
        }
    }
}
