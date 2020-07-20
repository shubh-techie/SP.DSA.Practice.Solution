using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.String
{
    public class StringPracticeSolutionOne
    {
        public static void StringPracticeSolutionOneDemo()
        {
            //SearchPattern();
            //BinarySubstringDemo();
            //StrstrDemo();
            //IsAnagramDemo();
            //IsRotateString();
            //IsomorphicStrings();
            //KeypadTypingDemo();
            //RepeatedCharacter();
            //FindSum();
            //SmallestWindow();
            SearchString();
        }

        private static void SearchString()
        {
            Console.WriteLine(Search("aabaacaadaabaaba", "aaba"));
        }

        private static bool Search(string str, string pattern)
        {
            int pLen = pattern.Length, sLen = str.Length;
            //int[] charIndex = new int[26];
            //int[] strIndex = new int[26];
            Queue<char> qPattern = new Queue<char>();
            Queue<char> qString = new Queue<char>();

            foreach (var item in pattern)
            {
                qPattern.Enqueue(item);
            }

            int start = 0;
            for (int i = 0; i < sLen; i++)
            {
                qString.Enqueue(str[i]);
                if (i >= pLen)
                {
                    qString.Dequeue();
                    start++;
                }

                if (i >= pLen - 1 && string.Join("", qPattern) == string.Join("", qString))
                {
                    Console.WriteLine("Match found :{0}, {1}", start, i);
                }
            }
            return false;
        }

        private static bool IsEquals(int[] charIndex, int[] strIndex)
        {
            for (int i = 0; i < 26; i++)
            {
                if (charIndex[i] != strIndex[i])
                    return false;
            }
            return true;
        }

        private static void SmallestWindow()
        {
            // bool subString = SmallestWindow("ADOBECODEBANC", "ABC");
            bool subString = SmallestWindow("ABAACBAB", "ABC");
            Console.WriteLine(subString);
        }

        private static bool SmallestWindow(string str, string pattern)
        {
            int strLen = str.Length, pLen = pattern.Length;
            if (pLen > strLen) return false;

            Dictionary<char, int> charMap = new Dictionary<char, int>();
            foreach (var item in pattern)
            {
                if (charMap.ContainsKey(item))
                    charMap[item]++;
                else
                    charMap.Add(item, 1);
            }

            int count = pLen, start = 0, len = strLen + 1;
            for (int i = 0; i < strLen; i++)
            {
                Console.Write(str[i].ToString());
                if (charMap.ContainsKey(str[i]))
                {
                    if (charMap[str[i]]-- > 0)
                    {
                        count--;
                    }
                }

                while (count == 0)
                {
                    // maximize or minimize calculater

                    if (len > i - start + 1)
                    {
                        len = i - start + 1;
                        string res = str.Substring(start, len);
                        Console.WriteLine("res   :" + res);
                    }
                    else
                        Console.WriteLine("res   :" + str.Substring(start, i - start + 1));

                    //Console.WriteLine(str.Substring(start, i - start + 1));

                    if (charMap.ContainsKey(str[start]))
                    {
                        if (charMap[str[start]]++ >= 0)
                        {
                            count++;
                        }
                    }
                    start++;
                }

                Console.WriteLine();
            }
            return false;
        }

        private static void FindSum()
        {
            int sum = GetSum("1abc2x30yz67");
            Console.WriteLine("Sum :" + sum);
        }

        private static int GetSum(string str)
        {
            if (str.Length == 0) return 0;

            string result = "";
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    result += str[i].ToString();
                    if (i == str.Length - 1 || !char.IsDigit(str[i + 1]))
                    {
                        sum += Convert.ToInt32(result);
                        result = "";
                    }
                }
            }
            return sum;
        }

        private static void RepeatedCharacter()
        {
            string noRepeat = RepeatedChar("aacdb", "gafd");
            Console.WriteLine("unique :" + noRepeat);
        }

        private static string RepeatedChar(string str1, string str2)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<char, int> set = new Dictionary<char, int>();

            foreach (var item in str1)
            {
                if (set.ContainsKey(item))
                    set[item]++;
                else
                    set.Add(item, 1);
            }

            foreach (var item in str2)
            {
                if (set.ContainsKey(item))
                    set[item]++;
                else
                    set.Add(item, 1);
            }

            foreach (var item in set)
            {
                if (item.Value == 1)
                {
                    sb.Append(item.Key);
                }
            }

            return sb.ToString();
        }

        private static void KeypadTypingDemo()
        {
            string digits = GetKeyPadTyping("geeksquiz");
            Console.WriteLine("digits :" + digits);
        }

        private static string GetKeyPadTyping(string str)
        {
            string result = "";
            string[] num = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (num[j].IndexOf(str[i]) != -1)
                    {
                        result += j + 2;
                    }
                }
            }
            return result;
        }

        private static void IsomorphicStrings()
        {
            Console.WriteLine(IsIsomorphicStrings("aab", "xxy"));
        }

        private static bool IsIsomorphicStrings(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            Dictionary<char, char> isoMap = new Dictionary<char, char>();
            for (int i = 0; i < str1.Length; i++)
            {
                if (!isoMap.ContainsKey(str1[i]))
                {
                    isoMap.Add(str1[i], str2[i]);
                }
                else
                {
                    if (isoMap[str1[i]] != str2[i])
                        return false;
                }
            }
            return true;
        }

        private static void IsRotateString()
        {
            Console.WriteLine("IsRotateStringCheck :" + IsRotateStringCheck("mushroomkingdom", "itsamemario"));
        }

        private static bool IsRotateStringCheck(string v1, string v2)
        {
            return (v1.Length == v2.Length) && (v1 + v1).IndexOf(v2) != -1;
        }

        private static void IsAnagramDemo()
        {
            Console.WriteLine(IsAnagram("geeksforgeeks", "forgeeksgeeks"));
        }

        private static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            int[] anaSet = new int[26];

            foreach (var item in str1)
            {
                anaSet[item - 'a']++;
            }


            foreach (var item in str2)
            {
                anaSet[item - 'a']--;
                if (anaSet[item - 'a'] < 0)
                    return false;
            }

            return true;
        }

        private static void StrstrDemo()
        {
            string str = "GeeksForGeeks";
            string x = "For";
            Console.WriteLine("index :" + GetstrIndex(str, x));
        }

        private static int GetstrIndex(string str, string x)
        {
            int j = 0;
            for (int i = 0; i <= str.Length - x.Length; i++)
            {
                j = 0;
                while (j < x.Length)
                {
                    if (str[i + j] != x[j])
                        break;
                    j++;
                }

                if (j == x.Length)
                    return i;
            }

            return -1;
        }

        private static void BinarySubstringDemo()
        {
            List<string> lists = new List<string>();
            lists.Add("1111");
            lists.Add("01101");
            foreach (var item in lists)
            {
                Console.WriteLine("count : " + BinarySubstringEfficient(item));
            }
        }

        private static int BinarySubstringEfficient(string item)
        {
            int count = 0;
            foreach (char ch in item)
            {
                if (ch == '1')
                {
                    count++;
                }
            }
            return count * (count - 1) / 2;
        }

        private static int BinarySubstringNaive(string strBinary)
        {
            int count = 0, n = strBinary.Length; ;
            for (int i = 0; i < n; i++)
            {
                if (strBinary[i] == '1')
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (strBinary[j] == '1')
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private static void SearchPattern()
        {
            //string pattern = "aaba";
            //string text = "aabaacaadaabaaabaa";

            string pattern = "ABCD";
            string text = "ABCABCD";
            IsPatternFound(pattern, text);
        }

        private static void IsPatternFound(string pattern, string text)
        {
            int m = text.Length;
            int n = pattern.Length;
            int j = 0;
            for (int i = 0; i < m; i++)
            {
                j = 0;
                while (j < n)
                {
                    if (text[j + i] != pattern[j])
                        break;
                    j++;
                }

                if (j == n)
                    Console.WriteLine("pattern found " + i);
            }
        }
    }
}
