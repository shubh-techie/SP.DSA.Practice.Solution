using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques763PartitionLabels
    {
        public static void Ques763PartitionLabelsDemo()
        {
            string str = "ababcbacadefegdehijhklij";
            IList<int> result = PartitionLabels(str);

            Console.WriteLine(string.Join("  ", result));
        }

        public static IList<int> PartitionLabels(string S)
        {
            if (string.IsNullOrEmpty(S)) return null;

            IList<int> result = new List<int>();
            int[] map = new int[26];
            int len = S.Length;

            // Recording the last index of each char.
            for (int i = 0; i < len; i++)
            {
                map[S[i] - 'a'] = i;
            }
            Console.WriteLine("Last Index :" + string.Join(" ", map));

            int lastIndex = 0, startIndex = 0;
            //Maintain the max last index and once equal to the current index.
            for (int i = 0; i < len; i++)
            {
                lastIndex = Math.Max(lastIndex, map[S[i] - 'a']);
                if (lastIndex == i)
                {
                    result.Add(lastIndex - startIndex + 1);
                    startIndex = lastIndex + 1;
                }
            }
            return result;
        }
    }
}
