using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.QueueDemo
{
    public class PracticeSetDemoOne
    {
        public static void PracticeSetDemoOneStart()
        {

            MaximumSubArrSizeK();
            // ModifyAQueue();
            //GenerareBinaryDemo();
            //QueueUsingTwoStack();
            //QueueReversal();
            //MyQueueDemoUsingLinkedList();
            //MyQueueDemoSolution();
        }

        private static void MaximumSubArrSizeK()
        {
            int[] arr = { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };
            int k = 4;
            List<int> result = GetSizeResult(arr, arr.Length, k);
            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> GetSizeResult(int[] arr, int length, int k)
        {
            List<int> outputSet = new List<int>();

            LinkedList<int> maxTracker = new LinkedList<int>();

            for (int i = 0; i < length; i++)
            {
                while (maxTracker.Count > 0 && arr[i] >= maxTracker.Last())
                {
                    maxTracker.RemoveLast();
                }
                maxTracker.AddLast(arr[i]);

                if (i >= k - 1)
                {
                    outputSet.Add(maxTracker.First());
                }
            }

            return outputSet;
        }

        private static void ModifyAQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine(string.Join(",", queue));
            ModifyAQueueFromK(queue, 4);
            Console.WriteLine(string.Join(",", queue));

        }

        private static void ModifyAQueueFromK(Queue<int> queue, int k)
        {
            int size = queue.Count;
            Stack<int> stack = new Stack<int>();

            while (k > 0)
            {
                stack.Push(queue.Dequeue());
                k--;
            }

            while (stack.Count > 0)
            {
                k++;
                queue.Enqueue(stack.Pop());
            }

            while (k < size)
            {
                queue.Enqueue(queue.Dequeue());
                k++;
            }
        }

        private static void GenerareBinaryDemo()
        {
            List<string> output = Generate(5);
            foreach (var item in output)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static List<string> Generate(int number)
        {
            Queue<string> queue = new Queue<string>();
            List<string> result = new List<string>();
            queue.Enqueue("1");

            while (number > 0)
            {
                string previousString = queue.Dequeue();
                queue.Enqueue(previousString + "0");
                queue.Enqueue(previousString + "1");
                result.Add(previousString);
                number--;
            }

            return result;
        }

        private static string GetString(Queue<int> queue)
        {
            string output = "";
            int count = queue.Count;
            while (count > 0)
            {
                output += queue.Peek();
                count--;
            }
            return output;
        }

        private static void QueueUsingTwoStack()
        {

        }

        private static void QueueReversal()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);
            queue.Enqueue(400);
            queue.Enqueue(500);
            Console.WriteLine(string.Join(", ", queue));
            ReverseAQueue(queue);
            Console.WriteLine(string.Join(", ", queue));
        }

        private static void ReverseAQueue(Queue<int> queue)
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

        private static void MyQueueDemoUsingLinkedList()
        {
            QueueLS queue = new QueueLS();
            Console.WriteLine(queue.Size);
            queue.Enqueue(100);
            Console.WriteLine(queue.Size);
            queue.Enqueue(200);
            Console.WriteLine(queue.Size);
            queue.Enqueue(300);
            Console.WriteLine(queue.Size);
            queue.Enqueue(400);
            Console.WriteLine(queue.Size);


            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Size);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Size);
        }

        private static void MyQueueDemoSolution()
        {
            QueueDesigned myQueue = new QueueDesigned(4);
            myQueue.Enqueue(100);
            Console.WriteLine(myQueue.Size);
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Size);
            myQueue.Enqueue(200);
            Console.WriteLine(myQueue.Size);
            myQueue.Enqueue(300);
            Console.WriteLine(myQueue.Size);
            myQueue.Enqueue(400);
            Console.WriteLine(myQueue.Size);
            myQueue.Enqueue(500);
            Console.WriteLine(myQueue.Size);

            Console.WriteLine(myQueue.ToString());
            myQueue.Enqueue(600);
            Console.WriteLine(myQueue.Size);
        }
    }

    class QueueTwoStack
    {
        Stack<int> One;
        Stack<int> Two;


        public int Size { get; set; }
        public QueueTwoStack()
        {
            this.Size = 0;
            One = new Stack<int>();
            Two = new Stack<int>();
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Enqueue(int val)
        {
            if (One.Count > 0)
            {
                Two.Push(One.Pop());
            }
            this.Size++;
            One.Push(val);
            while (Two.Count > 0)
            {
                One.Push(Two.Pop());
            }
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new Exception("Queue is empty.");
            this.Size--;
            return One.Pop();
        }

        public int Peek()
        {
            if (IsEmpty()) throw new Exception("Queue is empty.");
            return One.Peek();
        }
    }

    class ListNode
    {
        public int Val;
        public ListNode Next;
        public ListNode(int val)
        {
            Next = null;
            this.Val = val;
        }
    }

    public class QueueLS
    {
        ListNode Head;
        public int Size { get; set; }
        public QueueLS()
        {
            this.Size = 0;
            this.Head = null;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }


        public void Enqueue(int val)
        {
            this.Size++;
            ListNode tempNode = new ListNode(val);
            if (this.Head == null)
            {
                tempNode.Next = Head;
                Head = tempNode;
            }
            else
            {
                ListNode currNode = this.Head;
                while (currNode.Next != null)
                {
                    currNode = currNode.Next;
                }
                currNode.Next = tempNode;
            }
        }


        public int Dequeue()
        {
            if (this.IsEmpty()) throw new Exception("Queue is empty.");

            this.Size--;
            ListNode tempNode = this.Head;
            this.Head = this.Head.Next;
            return tempNode.Val;
        }

    }



    public class QueueDesigned
    {
        int Front, Rear, Capcity;
        int[] Arr;
        public int Size { get; set; }

        public QueueDesigned(int capacity)
        {
            this.Front = this.Size = 0;
            this.Rear = capacity - 1;
            this.Capcity = capacity;
            this.Arr = new int[this.Capcity];
        }


        public bool IsFull()
        {
            return this.Capcity == this.Size;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Enqueue(int val)
        {
            if (IsFull()) throw new Exception("queue is full");

            this.Rear = (this.Rear + 1) % this.Capcity;
            this.Arr[this.Rear] = val;
            this.Size++;
        }


        public int Dequeue()
        {
            if (IsEmpty()) throw new Exception("Queue is Empty");
            int temp = this.Arr[this.Front];
            this.Front = (this.Front + 1) % this.Capcity;
            this.Size--;
            return temp;
        }


        public override string ToString()
        {
            return string.Join(",", this.Arr);
        }
    }
}
