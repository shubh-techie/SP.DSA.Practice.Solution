using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.QueueDemo
{
    public class ReverseFirstKQueue
    {
        public static void ReverseFirstKQueueDemo()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 3;
            Queue<int> input = new Queue<int>();
            foreach (var item in arr)
            {
                input.Enqueue(item);
            }
            Console.WriteLine(string.Join(", ", input));

            Queue<int> revOutput = GetReverseFirstKQueue(input, k);
            Console.WriteLine(string.Join(", ", input));
            Console.WriteLine(string.Join(", ", revOutput));
        }

        private static Queue<int> GetReverseFirstKQueue(Queue<int> input, int k)
        {
            Stack<int> output = new Stack<int>();
            Queue<int> result = new Queue<int>();

            while (k-- > 0)
            {
                output.Push(input.Dequeue());
            }

            while (output.Count > 0)
            {
                result.Enqueue(output.Pop());
            }

            while (input.Count > 0)
            {
                result.Enqueue(input.Dequeue());
            }

            return result;
        }
    }
}
