using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    class SearchTrie
    {
        public SearchTrie[] sub = new SearchTrie[26];
        public List<string> suggestion = new List<string>();
    }

    public class Ques1268SearchSuggestionsSystem
    {

        public static void Demo()
        {
            string[] product = { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mouse";
            IList<IList<string>> resultSet = SuggestedProducts(product, searchWord);
        }

        public static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            SearchTrie root = new SearchTrie();
            foreach (var product in products)
            {
                InsertToRoot(product, root);
            }
            IList<IList<string>> resultSet = SearchResult(searchWord, root);
            return resultSet;
        }

        private static void InsertToRoot(string product, SearchTrie root)
        {
            SearchTrie trie = root;
            foreach (char ch in product)
            {
                if (trie.sub[ch - 'a'] == null)
                    trie.sub[ch - 'a'] = new SearchTrie();
                trie = trie.sub[ch - 'a'];
                if (trie.suggestion.Count < 3)
                    trie.suggestion.Add(product);
            }
        }

        private static IList<IList<string>> SearchResult(string searchWord, SearchTrie root)
        {
            IList<IList<string>> result = new List<IList<string>>();

            foreach (char ch in searchWord)
            {
                if (root != null)
                    root = root.sub[ch - 'a'];
                result.Add(root == null ? new List<string>() : root.suggestion);
            }
            return result;
        }
    }
}
