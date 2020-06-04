using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques20Valid_Parentheses
    {
        public static void IsValiddemo()
        {
            string input = "()[]{}";
            Console.WriteLine("IsValid(input) " + IsValid(input));
        }
        public static bool IsValid(string s)
        {
            Stack<char> track = new Stack<char>();

            foreach (var ch in s)
            {
                if (ch == '{' || ch == '(' || ch == '[')
                    track.Push(ch);
                else
                {
                    if (track.Count > 0)
                    {
                        if (!IsMatching(ch, track.Peek()))
                        {
                            return false;
                        }
                        else
                        {
                            track.Pop();
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return track.Count == 0 ? true : false;
        }

        public static bool IsMatching(char close, char open)
        {
            return ((close == '}' && open == '{') || (close == ']' && open == '[') || (close == ')' && open == '('));
        }
    }
}
