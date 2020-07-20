using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class LongestCommonSubsequence
    {
        public static void LongestCommonSubsequenceDemo()
        {
            string str1 = "AGGTAB";
            string str2 = "GXTXAYB";

            int count = GetCommonStringEfficient(str1, str2, str1.Length, str2.Length, "");
            Console.WriteLine("Common String :" + count);
        }

        private static int GetCommonStringEfficient(string str1, string str2, int m, int n, string v)
        {
            int[,] local = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write(local[i, j] + " ");

                    if (i == 0 || j == 0)
                    {
                        local[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        local[i, j] += local[i - 1, j - 1] + 1;
                    }
                    else
                        local[i, j] = Math.Max(local[i - 1, j], local[i, j - 1]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write(local[i, j] + " ");
                }
                Console.WriteLine();
            }

            return local[m, n];
        }

        private static int GetCommonString(string str1, string str2, int length1, int length2, string output)
        {
            if (length1 == 0 || length2 == 0)
                return 0;

            if (str1[length1 - 1] == str2[length2 - 1])
            {
                output += str1[length1 - 1];
                Console.WriteLine(output);
                return 1 + GetCommonString(str1, str2, length1 - 1, length2 - 1, output);
            }
            {
                return Math.Max(GetCommonString(str1, str2, length1 - 1, length2, output), GetCommonString(str1, str2, length1, length2 - 1, output));
            }
        }

        public int LCS(int m, int n, string s1, string s2)
        {
            if (m == 0 || n == 0) return 0;
            int[,] table = new int[m + 1, n + 1];
            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        table[i, j] = 0;
                    }
                    if (s1[i - 1] == s2[j - 1])
                    {
                        table[i, j] = 1 + table[i - 1, j - 1];
                    }
                    else
                        table[i, j] = Math.Max(table[i, j - 1], table[i - 1, j]);
                }
            }
            return table[m, n];
        }
    }
}
