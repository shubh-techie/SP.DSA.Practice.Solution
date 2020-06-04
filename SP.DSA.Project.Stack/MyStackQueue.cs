using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class MyStackQueue
    {
        public static void MyStackQueueStart()
        {
            MyStack stack = new MyStack();

            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Top());   // returns 2
            Console.WriteLine(stack.Pop());   // returns 2
            Console.WriteLine(stack.Empty());// returns false
        }
    }
    public class MyStack
    {
        Queue<int> stack;

        public MyStack()
        {
            stack = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            stack.Enqueue(x);
            int qSize = stack.Count;
            while (qSize > 1)
            {
                stack.Enqueue(stack.Dequeue());
                qSize--;
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return stack.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return stack.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return stack.Count == 0;
        }
    }
}
