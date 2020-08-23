using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class TrieNode
    {
        public TrieNode[] next = new TrieNode[26];
        public string word;
    }

    public class Ques212WordSearchII
    {
        public static void Ques212WordSearchIIDemo()
        {
            string[] words = { "oath", "pea", "eat", "rain" };
            FindWords(words);
        }

        public static IList<string> FindWords(string[] words)
        {
            IList<string> output = new List<string>();
            TrieNode root = buildTrie(words);
            return output;
        }

        private static TrieNode buildTrie(string[] words)
        {
            TrieNode root = new TrieNode();

            foreach (var word in words)
            {
                TrieNode tempTrie = root;
                foreach (var ch in word.ToCharArray())
                {
                    int index = ch - 'a';
                    if (tempTrie.next[index] == null)
                        tempTrie.next[index] = new TrieNode();
                    tempTrie = tempTrie.next[index];
                }
                tempTrie.word = word;
            }

            return root;
        }
    }
}
