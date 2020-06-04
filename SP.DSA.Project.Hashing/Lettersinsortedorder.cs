using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class Lettersinsortedorder
    {

        public static void GerShortedStringDemo()
        {
            string str = "whiteboard";
            string shorted = GerShortedString(str);
            Console.WriteLine(shorted);
        }

        public static string GerShortedString(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            string shorted = "";

            int[] chars = new int[26];

            foreach (var item in str)
            {
                chars[item - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                int count = chars[i];
                while (count > 0)
                {
                    shorted += Convert.ToChar(i + 'a').ToString();
                    count--;
                }
            }

            return shorted;
        }
    }
}
