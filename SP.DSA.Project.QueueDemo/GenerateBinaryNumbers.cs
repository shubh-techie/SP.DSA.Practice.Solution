using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.QueueDemo
{
    public class GenerateBinaryNumbers
    {
        public static void GenerateBinaryNumbersDemo()
        {
            int n = 5;
            List<string> output = GetGenerateBinaryNumbers(n);
            Console.WriteLine("Binaries Are : " + string.Join(", ", output));
        }

        private static List<string> GetGenerateBinaryNumbers(int n)
        {
            List<string> binaries = new List<string>();
            StringBuilder sb = new StringBuilder();

            Queue<string> track = new Queue<string>();
            track.Enqueue("1");

            for (int i = 1; i <= n; i++)
            {
                string prevString = track.Dequeue();
                track.Enqueue(prevString + "0");
                track.Enqueue(prevString + "1");
                binaries.Add(prevString);
            }
            return binaries;
        }
    }
}
