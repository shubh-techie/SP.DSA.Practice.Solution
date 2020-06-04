using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques242ValidAnagram
    {
        public static void Ques242ValidAnagramDemo()
        {
            string str = "rat";
            string tar = "car";
            Console.WriteLine("is Anagram :{0}", IsAnagram(str, tar));
        }
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] track = new int[26];

            foreach (var item in s)
            {
                track[item - 'a']++;
            }

            foreach (var item in t)
            {
                track[item - 'a']--;
                if (track[item - 'a'] < 0)
                    return false;
            }
            return true;
        }
    }
}
