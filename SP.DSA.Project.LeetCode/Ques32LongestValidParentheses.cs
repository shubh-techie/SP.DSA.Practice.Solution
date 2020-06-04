using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques32LongestValidParentheses
    {
        public static void LongestValidParenthesesDemo()
        {
            string str = "(()";
            Console.WriteLine(longestValidParenthesesBruteForce(str));
        }

        public static int longestValidParenthesesBruteForce(string str)
        {
            int maxlen = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 2; j <= str.Length; j += 2)
                {
                    if (isValid(str.Substring(i, j-i)))
                    {
                        maxlen = Math.Max(maxlen, j - i);
                    }
                }
            }
            return maxlen;
        }

        private static int LongestValidParenthesesEfficient(string str)
        {
            Stack<int> track = new Stack<int>();
            int uMax = 0;
            track.Push(-1);

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    track.Push(i);
                else
                {
                    track.Pop();

                    if (track.Count > 0)
                        uMax = Math.Max(i - track.Peek(), uMax);
                    else
                        track.Push(i);
                }
            }


            return uMax;
        }

        public static int LongestValidParentheses(string s)
        {
            int uMax = 0;
            LongestValidParenthesesHelper(s, 0, ref uMax, "");
            return uMax;
        }

        private static void LongestValidParenthesesHelper(string str, int index, ref int uMax, string curr)
        {
            if (index == str.Length)
            {
                Console.WriteLine(curr);
                if (isValid(curr) && str.Contains(curr))
                    uMax = Math.Max(curr.Length, uMax);
                return;
            }

            LongestValidParenthesesHelper(str, index + 1, ref uMax, curr + str[index]);
            LongestValidParenthesesHelper(str, index + 1, ref uMax, curr);

        }

        private static bool isValid(string curr)
        {
            while (curr.Contains("()"))
            {
                curr = curr.Replace("()", "");
            }

            return curr.Length == 0 ? true : false;
        }
    }
}
