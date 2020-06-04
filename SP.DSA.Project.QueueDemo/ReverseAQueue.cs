using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.QueueDemo
{
    public class ReverseAQueue
    {
        public static void ReverseAQueueDemo()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine(string.Join(",", queue));
            ReverseAQueueGetReverse(queue);
            Console.WriteLine("After reverse ........");
            Console.WriteLine(string.Join(",", queue));

            ReverseAQueueGetReverseRecursion(queue);
            Console.WriteLine("After second reverse ........");
            Console.WriteLine(string.Join(",", queue));
        }

        private static void ReverseAQueueGetReverse(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        private static void ReverseAQueueGetReverseRecursion(Queue<int> queue)
        {
            if (queue.Count == 0)
                return;
            int x = queue.Dequeue();
            ReverseAQueueGetReverseRecursion(queue);
            queue.Enqueue(x);
        }
    }
}
