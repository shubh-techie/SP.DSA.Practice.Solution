using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class WordsCountInString
    {
        public static void WordsCountInStringDemo()
        {
            string input = "It's a man, it's a plane, it's superman!";
            Dictionary<string, int> output = WordsCountInStringHelper(input);
            Console.WriteLine(string.Join(",", output));
        }

        private static Dictionary<string, int> WordsCountInStringHelper(string input)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            HashSet<char> puch = new HashSet<char>() { ',', '.', '\'', '?', '!' };

            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (!puch.Contains(item))
                {
                    sb.Append(item);
                }
            }

            //input = Regex.Replace(input, "[^a-zA-Z]+", " ");
            string[] splitArray = sb.ToString().Split(' ');

            foreach (var word in splitArray)
            {
                if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                else
                    wordCounts.Add(word, 1);

            }
            return wordCounts;
        }
    }
}
