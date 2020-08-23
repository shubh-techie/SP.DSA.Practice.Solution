using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques692TopKFrequentWords
    {
        public static void Demo()
        {
            string[] words = { "i", "love", "leetcode", "i", "love", "coding", "coding", "coding" };
            int k = 2;

            IList<string> result = TopKFrequent(words, k);
            Console.WriteLine(string.Join(" ", result));
        }

        public static void DemoInteger()
        {
            int[] nums = { 3, 0, 1, 0 };
            int k = 2;

            int[] result = TopKFrequentInterger(nums, 1);
            Console.WriteLine(string.Join(" ", result));
        }

        public static int[] TopKFrequentInterger(int[] nums, int k)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int item in nums)
            {
                if (freq.ContainsKey(item))
                    freq[item] = freq[item] + 1;
                else
                    freq[item] = 1;
            }
            List<int> numsCollection = new List<int>(freq.Keys);
            numsCollection.Sort((a, b) => a == b ? a - b : freq[b] - freq[a]);
            return numsCollection.GetRange(0, k).ToArray();
        }

        public static IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            map.Keys.ToList().GetRange(0, k);

            foreach (var item in words)
            {
                if (map.ContainsKey(item))
                    map[item] = map[item] + 1;
                else
                    map[item] = 1;
            }
            List<string> result = new List<string>(map.Keys);
            result.Sort((w1, w2) =>
                                (map[w1] == map[w2]) ?
                                w1.CompareTo(w2) :
                                map[w2] - map[w1]);
            return result.GetRange(0, k);
        }
    }
}
