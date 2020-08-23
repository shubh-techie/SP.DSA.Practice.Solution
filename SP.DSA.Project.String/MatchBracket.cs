using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.String
{
    public class MatchBracket
    {
        public static void MatchBracketDemo()
        {
            Console.WriteLine(GetExtraBracket("))))"));
            //Console.WriteLine(GetExtraBracket("(((())))"));
            //Console.WriteLine(GetExtraBracket("))))(("));
        }

        private static int GetExtraBracket(string str)
        {
            Stack<char> result = new Stack<char>();
            foreach (var item in str)
            {
                if (item == '(')
                    result.Push(')');
                else if (item == ')')
                {
                    if (result.Count == 0)
                        result.Push('(');
                    else
                        result.Pop();
                }
            }
            return result.Count;
        }

        private static int GetExtraBracketUsingStack(string str)
        {
            int open = 0, extra = 0;
            foreach (var item in str)
            {
                if (item == '(')
                    open++;
                else if (item == ')')
                    open--;

                if (open < 0)
                {
                    extra++;
                    open++;
                }
            }
            return open + extra;
        }
    }
}
