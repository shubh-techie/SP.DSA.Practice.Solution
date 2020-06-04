using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.String
{
    public class NaivePatternSearching
    {
        public static void NaivePatternSearchingDemo()
        {
            string str = "THIS IS A TEST TEXT";
            string pattern = "TEST";
            NaivePatternSearchingHelper(str, pattern);
        }

        private static void NaivePatternSearchingHelper(string str, string pattern)
        {
            int strLength = str.Length;
            int patLength = pattern.Length;



        }
    }
}
