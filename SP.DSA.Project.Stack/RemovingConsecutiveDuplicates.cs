using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class RemovingConsecutiveDuplicates
    {
        public static void RemovingConsecutiveDuplicatesDemo()
        {
            string[] dupStrings = { "aaaaaabaabccccccc", "abbccbcd" };

            foreach (var str in dupStrings)
            {
                string output = GetRemovingConsecutiveDuplicates(str);
                Console.WriteLine(output);
            }
        }

        private static string GetRemovingConsecutiveDuplicates(string str)
        {
            Stack<char> track = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            foreach (var item in str)
            {
                if (track.Count == 0 || track.Peek() != item)
                {
                    sb.Append(item);
                    track.Push(item);
                }
            }
            return sb.ToString();
        }
    }
}
