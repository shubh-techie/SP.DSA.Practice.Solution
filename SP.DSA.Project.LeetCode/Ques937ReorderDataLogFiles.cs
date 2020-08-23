using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    class Ques937ReorderDataLogFiles
    {
        public static void ReorderLogFilesDemo()
        {
            string[] logs = { "dig1 8 1 5 1", "let4 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero", "let1 art can" };
            ReorderLogFiles(logs);
        }
        public static string[] ReorderLogFiles(string[] logs)
        {
            int len = logs.Length;
            if (len == 0) return logs;

            string[] result = new string[logs.Length];
            List<string> alphaLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            foreach (var item in logs)
            {
                bool isDigit = char.IsDigit(item.Split(' ')[1][0]);
                if (isDigit)
                {
                    digitLogs.Add(item);
                }
                else
                {
                    alphaLogs.Add(item);
                }
            }


            Console.WriteLine("Sorting letter logs");
            alphaLogs.Sort((log1, log2) =>
            {
                string word1 = log1.Substring(log1.IndexOf(" "));
                string word2 = log2.Substring(log1.IndexOf(" "));
                //Console.WriteLine(string.Format("{0} {1}", word1, word2));
                if (word1.Equals(word2))
                {
                    Console.WriteLine(string.Format("{0} {1}", word1, word2));
                    return log1.CompareTo(log2);
                }
                return word1.CompareTo(word2);
            });

            //foreach (var item in alphaLogs)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in digitLogs)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine();
            Console.WriteLine("updating logs.");

            for (int i = 0; i < len; i++)
            {
                if (i < alphaLogs.Count)
                    logs[i] = alphaLogs[i];
                else
                    logs[i] = digitLogs[i - alphaLogs.Count];
            }

            foreach (var item in logs)
            {
                Console.WriteLine(item);
            }

            return result;
        }
    }
}
