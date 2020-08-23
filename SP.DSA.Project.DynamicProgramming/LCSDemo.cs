using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class LCSDemo
    {
        public void LCSDemoSolution()
        {
            //LongestCommonSebsequenceLength();
            //LongestCommonSubstringLength();
            //PrintLCSequence();
            //ShortestCommonSupersequence();
            //MinimumNoDeletionsInsertions();
            //PrintShortetCommonSuperSwquence();
            //SequencePatternMatching();


        }

        private void SequencePatternMatching()
        {
            //throw new NotImplementedException();
            return;
        }

        private void PrintShortetCommonSuperSwquence()
        {
            string str1 = "AGGTAB";
            string str2 = "GXTXAYB";
            string result = GetShortetCommonSuperSwquence(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("GetShortetCommonSuperSwquence    :" + result);


            str1 = "HELLO";
            str2 = "GEEK";
            result = GetShortetCommonSuperSwquence(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("GetShortetCommonSuperSwquence    :" + result);
        }

        private string GetShortetCommonSuperSwquence(string str1, string str2, int m, int n)
        {
            int[,] cache = new int[m + 1, n + 1];
            int i = 0, j = 0;
            for (i = 0; i <= m; i++)
            {
                for (j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        cache[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                        cache[i, j] = 1 + cache[i - 1, j - 1];
                    else
                        cache[i, j] = Math.Max(cache[i - 1, j], cache[i, j - 1]);
                }
            }

            Common.PrintMatrix(cache);

            i = m;
            j = n;
            string result = "";

            while (i > 0 && j > 0)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    result = str1[i - 1].ToString() + result;
                    i--; j--;
                }
                else
                {
                    if (cache[i - 1, j] > cache[i, j - 1])
                    {
                        result = str1[i - 1].ToString() + result;
                        i--;
                    }
                    else
                    {
                        result = str2[j - 1].ToString() + result;
                        j--;
                    }
                }
            }
            while (i > 0)
            {
                result = str1[i - 1].ToString() + result;
                i--;
            }
            while (j > 0)
            {
                result = str2[j - 1].ToString() + result;
                j--;
            }
            return result;
        }

        private void MinimumNoDeletionsInsertions()
        {
            string str1 = "heap";
            string str2 = "pea";
            int m = str1.Length;
            int n = str2.Length;
            int lcsLength = GetLCSLengthBottomUP(str1, str2, str1.Length, str2.Length);

            Console.WriteLine("Deletion :" + (m - lcsLength));
            Console.WriteLine("Insertion :" + (n - lcsLength));
        }


        /// <summary>
        /// Input:   str1 = "geek",  str2 = "eke"
        /// Output: "geeke"
        /// Input:   str1 = "AGGTAB",  str2 = "GXTXAYB"
        /// Output:  "AGXGTXAYB"
        /// Length of two string and longest common subsequence.
        /// </summary>
        private void ShortestCommonSupersequence()
        {
            String str1 = "AGGTAB";
            String str2 = "GXTXAYB";
            int lcs = (str1.Length + str2.Length) - GetLCSLengthBottomUP(str1, str2, str1.Length, str2.Length); // PrintLCSequence(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("Supersequence Length :" + lcs);
        }

        private void PrintLCSequence()
        {
            String str1 = "AGGTAB";
            String str2 = "GXTXAYB";
            String lcs = PrintLCSequence(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("pring PrintLCSequence :" + lcs);
        }

        private string PrintLCSequence(string str1, string str2, int m, int n)
        {
            int[,] cache = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        cache[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                        cache[i, j] = 1 + cache[i - 1, j - 1];
                    else
                        cache[i, j] = Math.Max(cache[i - 1, j], cache[i, j - 1]);
                }
            }

            Common.PrintMatrix(cache);
            int p = m, q = n;
            string result = string.Empty;

            while (p > 0 && q > 0)
            {
                if (str1[p - 1] == str2[q - 1])
                {
                    result = result.Insert(0, str1[p - 1].ToString());
                    p--;
                    q--;
                }
                else
                {
                    if (cache[p - 1, q] > cache[p, q] - 1)
                        p--;
                    else
                        q--;
                }
            }

            return result;
        }

        private void LongestCommonSubstringLength()
        {
            string str1 = "GeeksforGeeks";
            string str2 = "GeeksQuiz";
            Console.WriteLine("LCSubString length  GeeksforGeeks:" + GetLCSubStringLengthRecursion(str1, str2, str1.Length, str2.Length));

            str1 = "abcdxyz";
            str2 = "xyzabcd";
            Console.WriteLine("LCSubString length abcdxyz:" + GetLCSubStringLengthRecursion(str1, str2, str1.Length, str2.Length));

            str1 = "zxabcdezy";
            str2 = "yzabcdezx";
            Console.WriteLine("LCSubString length zxabcdezy:" + GetLCSubStringLengthRecursion(str1, str2, str1.Length, str2.Length));
        }

        private int GetLCSubStringLengthRecursion(string str1, string str2, int m, int n)
        {
            int[,] cache = new int[m + 1, n + 1];
            int result = 0; // if second substring length is bigger

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        cache[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        cache[i, j] = 1 + cache[i - 1, j - 1];

                        result = Math.Max(result, cache[i, j]);
                    }
                    else
                        cache[i, j] = 0;
                }
            }

            return result;
        }

        private int GetLCSubStringLength(string str1, string str2, int m, int n, int count)
        {
            if (m == 0 || n == 0)
                return count;

            if (str1[m - 1] == str2[n - 1])
                count = GetLCSubStringLength(str1, str2, m - 1, n - 1, count + 1);
            else
                count = Math.Max(count,
                                 Math.Max(GetLCSubStringLength(str1, str2, m - 1, n, 0), GetLCSubStringLength(str1, str2, m, n - 1, 0)));

            return count;
        }

        /// <summary>
        /// Get Length of longest common sequence.
        /// https://www.geeksforgeeks.org/longest-common-subsequence-dp-4/
        /// Input : X = “GeeksforGeeks”, y = “GeeksQuiz”
        /// Output : 5
        /// </summary>
        public void LongestCommonSebsequenceLength()
        {
            string str1 = "AGGTAB";
            string str2 = "GXTXAYB";
            Console.WriteLine("LCS length :" + GetLCSLengthBottomUP(str1, str2, str1.Length, str2.Length));

            str1 = "abcdxyz";
            str2 = "xyzabcd";
            Console.WriteLine("LCS length :" + GetLCSLengthBottomUP(str1, str2, str1.Length, str2.Length));

            str1 = "zxabcdezy";
            str2 = "yzabcdezx";
            Console.WriteLine("LCS length :" + GetLCSLengthBottomUP(str1, str2, str1.Length, str2.Length));

            str1 = "GeeksforGeeks";
            str2 = "GeeksQuiz";
            Console.WriteLine("LCS length :" + GetLCSLengthBottomUP(str1, str2, str1.Length, str2.Length));
        }

        private int GetLCSLengthBottomUP(string str1, string str2, int m, int n)
        {
            int[,] cache = new int[m + 1, n + 1];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        cache[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        sb.Append(str1[i - 1]);
                        cache[i, j] = 1 + cache[i - 1, j - 1];
                    }
                    else
                        cache[i, j] = Math.Max(cache[i - 1, j], cache[i, j - 1]);
                }
            }
            Console.WriteLine(sb.ToString());
            return cache[m, n];
        }

        private int GetLCSLength(string str1, string str2, int n1, int n2)
        {
            if (n1 == 0 || n2 == 0)
                return 0;

            if (str1[n1 - 1] == str2[n2 - 1])
                return 1 + GetLCSLength(str1, str2, n1 - 1, n2 - 1);
            else
                return Math.Max(GetLCSLength(str1, str2, n1 - 1, n2), GetLCSLength(str1, str2, n1, n2 - 1));
        }
    }
}
