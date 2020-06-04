using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques205IsomorphicStrings
    {
        public static void Ques205IsomorphicStringsDemo()
        {
            string s = "paper", t = "title";
            Console.WriteLine(IsIsomorphic(s, t));
        }

        public static bool IsIsomorphic(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;
            if (m != n) return false;
            Dictionary<char, char> mapping = new Dictionary<char, char>();

            for (int i = 0; i < m; i++)
            {
                if (mapping.ContainsKey(s[i]))
                {
                    if (mapping[s[i]] != t[i])
                        return false;
                }
                else
                {
                    if (mapping.ContainsValue(t[i])) return false;
                    mapping.Add(s[i], t[i]);
                }
            }

            return true;
        }
    }
}
