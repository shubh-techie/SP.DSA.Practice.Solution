using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class MostOccurringLetterinString
    {
        public static void MostOccurringLetterinStringDemo()
        {
            string input = "noon";
            string output = MostOccurring(input);
            Console.WriteLine(output);
        }

        private static string MostOccurring(string str)
        {
            string output = "";
            str = str.ToLower().Replace(" ", "");

            int[] chars = new int[26];
            foreach (var item in str)
            {
                chars[item - 'a']++;
            }

            //Read Most 
            int mostCount = 0;
            for (int i = 0; i < 26; i++)
            {
                mostCount = Math.Max(mostCount, chars[i]);
            }

            //
            for (int i = 0; i < 26; i++)
            {
                if (chars[i] == mostCount)
                {
                    output += Convert.ToChar(i + 'a').ToString();
                }
            }

            return output;
        }
    }
}
