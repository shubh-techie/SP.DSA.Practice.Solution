using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques227BasicCalculatorII
    {
        public static void Ques227BasicCalculatorIIDemo()
        {
            string str = "42";
            Console.WriteLine(Calculate(str));
        }
        public static int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int result = 0;

            Stack<int> stack = new Stack<int>();
            int num = 0, index = 0;
            char lastSign = '+';
            s = s.Trim();
            foreach (var ch in s)
            {
                if (ch != ' ')
                {
                    if (char.IsDigit(ch))
                    {
                        num = num * 10 + ch - '0';
                    }
                    if (!char.IsDigit(ch) || index == s.Length - 1)
                    {
                        switch (lastSign)
                        {
                            case '+':
                                stack.Push(num);
                                break;
                            case '-':
                                stack.Push(num);
                                break;
                            case '*':
                                stack.Push(stack.Pop() * num);
                                break;
                            case '/':
                                stack.Push(stack.Pop() / num);
                                break;
                            default:
                                break;
                        }
                        lastSign = ch;
                        num = 0;
                    }
                }
                index++;
            }

            foreach (var item in stack)
            {
                result += item;
            }
            return result;
        }
    }
}
