using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class LongestPalindromicSubsequence
    {
        public void LongestPalindromicSubsequenceDemo()
        {
            //GetLongestPalindromicSubsequence();
            //MinimumNoDeletionsPalindrome();
            //MinimumInsertionsForPalindrome();
        }

        private void MinimumInsertionsForPalindrome()
        {
            string str1 = "abcd";
            int minInsertion = str1.Length - GetLongestPalindromicSubsequence(str1);
            Console.WriteLine("MinimumInsertionsForPalindrome   :" + minInsertion);

            str1 = "abcda";
            minInsertion = str1.Length - GetLongestPalindromicSubsequence(str1);
            Console.WriteLine("MinimumInsertionsForPalindrome   :" + minInsertion);


            str1 = "abcde";
            minInsertion = str1.Length - GetLongestPalindromicSubsequence(str1);
            Console.WriteLine("MinimumInsertionsForPalindrome   :" + minInsertion);
        }

        private void MinimumNoDeletionsPalindrome()
        {
            string str1 = "agb";
            int minDelection = str1.Length - GetLongestPalindromicSubsequence(str1);
            Console.WriteLine("MinimumNoDeletionsPalindrome   :" + minDelection);
        }

        private int GetLongestPalindromicSubsequence(string strInput)
        {
            string str1 = "GEEKSFORGEEKS";
            if (!string.IsNullOrEmpty(strInput))
                str1 = strInput;

            char[] strChar = str1.ToCharArray();
            Array.Reverse(strChar);
            string str2 = new string(strChar);
            int lpsLength = GetLCSLengthDP(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("longestPalindromics Length :{0}", lpsLength);
            return lpsLength;
        }

        private int GetLCSLengthDP(string str1, string str2, int m, int n)
        {
            int[,] cache = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        cache[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                        cache[i, j] = 1 + cache[i - 1, j - 1];
                    else
                        cache[i, j] = Math.Max(cache[i - 1, j], cache[i, j - 1]);
                }
            }
            return cache[m, n];
        }

        private int GetLCSLength(string str1, string str2, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            if (str1[m - 1] == str2[n - 1])
                return 1 + GetLCSLength(str1, str2, m - 1, n - 1);
            else
                return Math.Max(GetLCSLength(str1, str2, m - 1, n), GetLCSLength(str1, str2, m, n - 1));
        }
    }
}
