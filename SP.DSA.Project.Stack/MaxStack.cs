using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class MaxStackDemo
    {
        public static void MaxStackDemoStart()
        {
            MaxStack stack = new MaxStack();
            stack.Push(5);
            stack.Push(1);
            //stack.Push(5);
            Console.WriteLine(stack.Top()); // -> 5
            Console.WriteLine(stack.PopMax()); //-> 5
            Console.WriteLine(stack.Top()); //-> 1
            Console.WriteLine(stack.PeekMax()); //-> 5
            Console.WriteLine(stack.Pop());//-> 1
            Console.WriteLine(stack.Pop()); //-> 5
        }
    }

    public class MaxStack
    {
        Stack<int> MainStack;
        Stack<int> MaxAusStack;

        /** initialize your data structure here. */
        public MaxStack()
        {
            MainStack = new Stack<int>();
            MaxAusStack = new Stack<int>();
        }

        public void Push(int x)
        {
            if (MainStack.Count == 0)
            {
                MainStack.Push(x);
                MaxAusStack.Push(x);
            }
            else
            {
                MainStack.Push(x);
                if (MainStack.Peek() >= MaxAusStack.Peek())
                    MaxAusStack.Push(x);
            }
        }

        public int Pop()
        {
            if (MaxAusStack.Count == 0)
                return -1;

            if (MainStack.Peek() == MaxAusStack.Peek())
            {
                MaxAusStack.Pop();
            }
            return MainStack.Pop();
        }

        public int Top()
        {
            return MainStack.Count == 0 ? -1 : MainStack.Peek();
        }

        public int PeekMax()
        {
            return MaxAusStack.Count == 0 ? -1 : MaxAusStack.Peek();
        }

        public int PopMax()
        {
            int max = PeekMax();
            Stack<int> buffer = new Stack<int>();
            while (Top() != max)
            {
                buffer.Push(Pop());
            }
            while (buffer.Count > 0)
            {
                Push(buffer.Pop());
            }
            return max;
        }

    }
}
