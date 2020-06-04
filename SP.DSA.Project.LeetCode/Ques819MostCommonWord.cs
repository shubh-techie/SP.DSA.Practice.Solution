using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques819MostCommonWord
    {
        public static void MostCommonWord()
        {
            string paragraph =  "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            Console.WriteLine("most common :" + MostCommonWord(paragraph, banned));
        }
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<char> puch = new HashSet<char>() { '.', ',', '!' };

            string[] arr = paragraph.ToLower().Split("[!? ',;.]+".ToCharArray());

            Dictionary<string, int> trackCount = new Dictionary<string, int>();

            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (trackCount.ContainsKey(item))
                        trackCount[item]++;
                    else
                        trackCount.Add(item, 1);
                }
            }


            foreach (var item in banned)
            {
                trackCount.Remove(item);
            }

            string output = "";
            int uMax = int.MinValue;
            foreach (var item in trackCount)
            {
                if (item.Value > uMax)
                {
                    uMax = item.Value;
                    output = item.Key;
                }
            }

            return output;

        }
    }
}
