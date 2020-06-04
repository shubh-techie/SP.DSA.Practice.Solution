using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class BalancedParentheses
    {
        public static void BalancedParenthesesDemo()
        {
            string str = "[()]{}{[()()]()}";
            //string str = "[(])";
            bool isValid = IsValidBalancedParentheses(str);
            Console.WriteLine("is Valid :" + isValid);
        }

        private static bool IsValidBalancedParentheses(string str)
        {
            Stack<char> track = new Stack<char>();
            foreach (var currChar in str)
            {
                if (currChar == '(')
                    track.Push(')');
                else if (currChar == '[')
                    track.Push(']');
                else if (currChar == '{')
                    track.Push('}');
                else if (track.Count == 0 && track.Peek() != currChar)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsValidBalancedParenthesesSolution2(string str)
        {
            Stack<char> track = new Stack<char>();

            foreach (var item in str)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    track.Push(item);
                }
                else if (track.Count > 0)
                {
                    char prevChar = track.Pop();
                    if (!IsValidParan(item, prevChar))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }



        private static bool IsValidParan(char currChar, char prevChar)
        {
            return (currChar == ')' && prevChar == '(') || (currChar == '}' && prevChar == '{') || (currChar == ']' && prevChar == '[');
        }

        private static bool IsValidBalancedParenthesesSolution1(string str)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add(')', '(');
            map.Add(']', '[');
            map.Add('}', '{');

            Stack<char> track = new Stack<char>();

            foreach (var item in str)
            {
                if (map.ContainsKey(item))
                {
                    char TopChar = track.Count > 0 ? track.Pop() : '#';
                    if (map[item] != TopChar)
                        return false;
                }
                else
                {
                    track.Push(item);
                }
            }

            return true;
        }
    }
}
