using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.String
{
    public class NaiveSolutionPatternChange
    {
        public static void NaiveSolutionPatternChangeDemo()
        {
            string str = "THIS IS A TEST TEXT";
            string pattern = "TEXT";
            List<int> indices = GeSearchPattern(str, pattern);

            Console.WriteLine(string.Join(",", indices));
        }

        private static List<int> GeSearchPattern(string str, string pattern)
        {
            List<int> output = new List<int>();
            int sLen = str.Length, pLen = pattern.Length;

            for (int i = 0; i <= sLen - pLen; i++)
            {
                int j = 0;
                while (j < pattern.Length)
                {
                    Console.WriteLine("for i " + i + " " + pattern[j] + "" + str[i + j]);
                    if (pattern[j] != str[i + j])
                        break;
                    j++;
                }
                Console.WriteLine();
                if (j == pLen)
                    output.Add(i);
            }
            return output;
        }
    }
}
