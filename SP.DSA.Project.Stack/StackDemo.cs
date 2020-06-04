using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class MyStackDemo
    {
        public static void MyStackDemoHelper()
        {
            try
            {
                StackDemo _stack = new StackDemo();
                _stack.Push(100);
                _stack.Push(200);
                _stack.Push(300);
                _stack.Push(400);

                //peeking element
                Console.WriteLine(_stack.Peek());
                Console.WriteLine("count item :" + _stack.Count);

                Console.WriteLine(_stack.Pop());
                Console.WriteLine("count item after pop:" + _stack.Count);

                _stack.Push(600);

                Console.WriteLine(_stack.Peek());
                Console.WriteLine("count item :" + _stack.Count);

                Console.WriteLine(_stack.Pop());
                Console.WriteLine("count item after pop:" + _stack.Count);

                Console.WriteLine(_stack.Pop());
                Console.WriteLine("count item after pop:" + _stack.Count);

                Console.WriteLine(_stack.Pop());
                Console.WriteLine("count item after pop:" + _stack.Count);

                Console.WriteLine(_stack.Pop());
                Console.WriteLine("count item after pop:" + _stack.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class StackDemo
    {
        int[] stack;
        int Top;
        public int Count
        {
            get { return Top + 1; }
        }

        public StackDemo()
        {
            stack = new int[99];
            Top = -1;
        }

        public int Pop()
        {
            if (Top == 0)
            {
                throw new Exception("stack is empty");
            }
            else
            {
                int popVal = stack[Top];
                this.Top--;
                return popVal;
            }
        }

        public int Peek()
        {
            if (Top == -1)
            {
                throw new Exception("stack is empty");
            }
            else
            {
                return stack[Top];
            }
        }

        public void Push(int val)
        {
            this.Top++;
            if (Top == 99)
            {
                throw new Exception("stack is full.");
            }
            else
            {
                stack[Top] = val;
            }
        }
    }
}
