using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class OperationsOnStack
    {
        public static void OperationsOnStackDemo()
        {
            Stack<int> stack = new Stack<int>();
            Insert(stack, 2);
            Insert(stack, 4);
            Insert(stack, 3);
            Insert(stack, 5);

            Remove(stack);
            HeadOfStack(stack);
            Console.WriteLine(Find(stack, 8));
        }

        private static bool Find(Stack<int> stack, int v)
        {
            if (stack.Contains(v))
                return true;
            else
                return false;
        }

        private static void HeadOfStack(Stack<int> stack)
        {
            Console.WriteLine(stack.Peek());
        }

        private static void Remove(Stack<int> stack)
        {
            Console.WriteLine("removed :" + stack.Pop());
        }

        private static void Insert(Stack<int> stack, int v)
        {
            stack.Push(v);
        }
    }
}
