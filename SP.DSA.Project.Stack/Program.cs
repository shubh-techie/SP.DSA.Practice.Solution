using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            StackSolutionDemo.StackSolutionMain();
            //RemovingConsecutiveDuplicates.RemovingConsecutiveDuplicatesDemo();
            //OperationsOnStack.OperationsOnStackDemo();
            //MyStackQueue.MyStackQueueStart();
            //MaxStackDemo.MaxStackDemoStart();
            //MinStackDemo.MinStackStart();
            //LargestHistogram.LargestHistogramDemo();
            //NextGreaterElement.NextGreaterElementDemo();
            //PreviousGreaterElement.PreviousGreaterElementDemo();
            //StockSpanProblem.StockSpanProblemDemo();
            //BalancedParentheses.BalancedParenthesesDemo();
            //MyStackDemo.MyStackDemoHelper();
            //BasicOperation();

            Console.WriteLine("Press <enter> to exit.");
            Console.ReadLine();
        }

        private static void BasicOperation()
        {
            Stack<int> funDemo = new Stack<int>();
            funDemo.Push(100);
            funDemo.Push(200);
            funDemo.Push(300);
            //funDemo.Clear();

            funDemo.Peek();
            Console.WriteLine(string.Join(",", funDemo));
        }
    }
}
