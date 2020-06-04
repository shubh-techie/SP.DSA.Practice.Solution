using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class MinStackDemo
    {
        public static void MinStackStart()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine(minStack.GetMin()); // return -3
            minStack.Pop();
            minStack.Top();    // return 0
            Console.WriteLine(minStack.GetMin()); // return -2
        }
    }
    public class MinStack
    {
        Stack<int> MS;
        Stack<int> AS;

        /** initialize your data structure here. */
        public MinStack()
        {
            MS = new Stack<int>();
            AS = new Stack<int>();
        }

        public void Push(int x)
        {
            if (MS.Count == 0)
            {
                AS.Push(x);
                MS.Push(x);
            }
            else
            {
                MS.Push(x);
                if (MS.Peek() <= AS.Peek())
                    AS.Push(x);
            }
        }

        public void Pop()
        {

            if (MS.Count == 0)
                return;

            if (AS.Peek() == MS.Peek())
            {
                AS.Pop();
            }
            MS.Pop();
        }

        public int Top()
        {
            return MS.Count == 0 ? -1 : MS.Peek();
        }

        public int GetMin()
        {
            return AS.Count == 0 ? -1 : AS.Peek();
        }

    }
}
