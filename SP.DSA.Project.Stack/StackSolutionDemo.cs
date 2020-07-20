using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class StackSolutionDemo
    {
        public static void StackSolutionMain()
        {
            //StackDemo();
            //LinkStackDemo();
            //RemoveDuplicates();
            //RemovePair();
            //IsValidParenthesisCheck();
            //TwoStackDemo();
            //GetMinStack();
            //DeleteMiddleOfStack();
            //MaxiMumOfMinimum();
            //StockSpan();
            LargestHistoGramDemo();
        }

        private static void LargestHistoGramDemo()
        {
            int[] arr = { 6, 2, 5, 4, 1, 5, 6 };
            int maxArea = GetMaxHistogramEfficient(arr, arr.Length);
            Console.WriteLine("Max :" + maxArea);
        }

        private static int GetMaxHistogramEfficient(int[] arr, int length)
        {
            int[] preMax = GetMax(arr, "pre");
            Console.WriteLine("preMax span :" + string.Join(", ", preMax));

            int[] postMax = GetMax(arr, "post");
            Console.WriteLine("postMax span :" + string.Join(", ", postMax));

            int maxArea = 0;
            for (int i = 0; i < length; i++)
            {
                int currMax = arr[i];
                currMax += (i - preMax[i] - 1) * arr[i];
                currMax += (postMax[i] - i - 1) * arr[i];
                maxArea = Math.Max(currMax, maxArea);
            }
            return maxArea;
        }

        private static int[] GetMax(int[] arr, string type)
        {
            int n = arr.Length;
            int[] output = new int[n];
            Stack<int> traxMin = new Stack<int>();

            if (type == "pre")
            {
                for (int i = 0; i < n; i++)
                {
                    while (traxMin.Count > 0 && arr[traxMin.Peek()] >= arr[i])
                    {
                        traxMin.Pop();
                    }
                    output[i] = traxMin.Count == 0 ? -1 : traxMin.Peek();
                    traxMin.Push(i);
                }
            }
            if (type == "post")
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    while (traxMin.Count > 0 && arr[traxMin.Peek()] >= arr[i])
                    {
                        traxMin.Pop();
                    }
                    output[i] = traxMin.Count == 0 ? n : traxMin.Peek();
                    traxMin.Push(i);
                }
            }

            return output;
        }

        private static int GetMaxHistogram(int[] arr, int length)
        {
            int uMax = 0, n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int currMax = arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] >= arr[i])
                        currMax += arr[i];
                    else
                        break;
                }
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] >= arr[i])
                        currMax += arr[i];
                    else
                        break;
                }

                uMax = Math.Max(uMax, currMax);
            }

            return uMax;
        }

        private static void StockSpan()
        {
            int[] arr = { 15, 13, 12, 14, 16, 8, 6, 4, 10, 30 };
            int[] output = GetStockSpanEfficient(arr, arr.Length);
            Console.WriteLine("Stock span :" + string.Join(", ", output));
        }

        private static int[] GetStockSpanEfficient(int[] arr, int n)
        {
            int[] output = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
                {
                    stack.Pop();
                }
                output[i] = stack.Count == 0 ? i + 1 : i - stack.Peek();
                stack.Push(i);
            }
            return output;
        }

        private static int[] GetStockSpan(int[] arr, int n)
        {
            int[] output = new int[n];

            for (int i = 0; i < n; i++)
            {
                int currItem = arr[i], count = 0;
                for (int j = i; j >= 0; j--)
                {
                    if (currItem >= arr[j])
                        count++;
                    else
                        break;
                }
                output[i] = count;
            }
            return output;
        }

        private static void MaxiMumOfMinimum()
        {
            int[] arr = { 10, 20, 30, 50, 10, 70, 30 };
            Stack<int> stack = new Stack<int>();
            int n = arr.Length;

            int[] previous = new int[n];
            previous[0] = -1;
            stack.Push(10);
            for (int i = 1; i < n; i++)
            {
                while (stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }
                previous[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(arr[i]);
            }
            Console.WriteLine("Previous greater :" + string.Join(", ", previous));

            int[] next = new int[n];
            next[n - 1] = -1;
            stack = new Stack<int>();
            stack.Push(arr[n - 1]);
            for (int i = n - 2; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }
                next[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(arr[i]);
            }
            Console.WriteLine("Next greater :" + string.Join(", ", next));
        }

        private static void DeleteMiddleOfStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine("Pre :" + string.Join(", ", stack));
            DeleteMiddleOfStack(stack, stack.Count, 0);
            Console.WriteLine("Post :" + string.Join(", ", stack));
        }

        private static void DeleteMiddleOfStack(Stack<int> stack, int n, int index)
        {
            if (stack.Count == 0 || index >= n)
                return;
            int temp = stack.Pop();
            DeleteMiddleOfStack(stack, n, index + 1);
            if (index != n / 2)
            {
                stack.Push(temp);
            }
        }

        private static void GetMinStack()
        {
            MyMinStackDemo minStack = new MyMinStackDemo();
            minStack.Push(100);
            Console.WriteLine("Min Stack :" + minStack.GetMin());
            minStack.Push(200);
            Console.WriteLine("Min Stack :" + minStack.GetMin());
            minStack.Push(65);
            Console.WriteLine("Min Stack :" + minStack.GetMin());
            minStack.Pop();
            Console.WriteLine("Min Stack :" + minStack.GetMin());
        }

        private static void TwoStackDemo()
        {
            TwoStackDemo stack = new TwoStackDemo(10);
            stack.Push1(100);
            stack.Push1(200);
            stack.Push1(200);
            stack.Push2(500);
            Console.WriteLine(stack.ToString());
        }

        private static void IsValidParenthesisCheck()
        {
            Console.WriteLine(IsValidParenthesisCheckSwicth("(((((((({}{}{}{}{}{}{}{}))))))))"));
        }

        private static bool IsValidParenthesisCheckSwicth(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{')
                    stack.Push('}');
                else if (str[i] == '[')
                    stack.Push(']');
                else if (str[i] == '(')
                    stack.Push(')');
                else if (stack.Count == 0 || stack.Pop() != str[i])
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }

        private static bool IsValidParenthesisCheck(string str)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add('}', '{');
            map.Add(']', '[');
            map.Add(')', '(');
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str[i]))
                {
                    char topKey = stack.Count > 0 ? stack.Pop() : '#';
                    if (topKey != map[str[i]])
                    {
                        return false;
                    }
                }
                else
                    stack.Push(str[i]);
            }
            return stack.Count == 0 ? true : false;
        }

        private static void RemovePair()
        {
            Console.WriteLine(RemovePairFromString("aaabbaaccdaaabbaaccd"));
        }

        private static string RemovePairFromString(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (stack.Count > 0 && stack.Peek() == str[i])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(str[i]);
                }
            }
            return string.Join("", stack.Reverse());
        }

        private static void RemoveDuplicates()
        {
            String str = "aaaaaabaabccccccc";
            Console.WriteLine(Remove(str));

        }

        private static string Remove(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            string sb = "";
            Stack<char> stack = new Stack<char>();
            foreach (var item in str)
            {
                if (stack.Count == 0 || stack.Peek() != item)
                {
                    stack.Push(item);
                    sb += item;
                }
            }
            return sb;
        }

        private static void LinkStackDemo()
        {
            LinkStack<int> ls = new LinkStack<int>();
            ls.Push(10);
            Console.WriteLine("Size :" + ls.size);
            ls.Push(20);
            Console.WriteLine("Size :" + ls.size);
            ls.Push(30);
            Console.WriteLine("Size :" + ls.size);


            Console.WriteLine("peek :" + ls.Peek());
            Console.WriteLine("Size :" + ls.size);

            Console.WriteLine("Pop :" + ls.Pop());
            Console.WriteLine("Size :" + ls.size);

            Console.WriteLine("Pop :" + ls.Peek());
            Console.WriteLine("Size :" + ls.size);

            Console.WriteLine();
        }

        private static void StackDemo()
        {
            DummyStack stack = new DummyStack();
            stack.Push(100);
            Console.WriteLine("Stack size :{0}", stack.Size);
            stack.Push(200);
            Console.WriteLine("Stack size :{0}", stack.Size);
            stack.Push(300);
            Console.WriteLine("Stack size :{0}", stack.Size);

            Console.WriteLine("Peek " + stack.Peek());
            Console.WriteLine("Stack size :{0}", stack.Size);

            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Stack size :{0}", stack.Size);

            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Stack size :{0}", stack.Size);

            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Stack size :{0}", stack.Size);

            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Stack size :{0}", stack.Size);
        }
    }

    public class MyMinStackDemo
    {
        Stack<int> St;
        Stack<int> Min;
        public MyMinStackDemo()
        {
            St = new Stack<int>();
            Min = new Stack<int>();
        }

        public void Push(int data)
        {
            if (St.Count == 0)
            {
                St.Push(data);
                Min.Push(data);
            }
            else
            {

                if (data < Min.Peek())
                {
                    Min.Push(data);
                }
                St.Push(data);
            }
        }

        public int Pop()
        {
            if (St.Count > 0)
            {
                int temp = St.Pop();
                if (temp <= Min.Peek())
                {
                    Min.Pop();
                }
                return temp;
            }
            else
            {
                throw new Exception("Stack is empty.");
            }
        }
        public int GetMin()
        {
            if (Min.Count > 0)
                return Min.Peek();
            else
                throw new Exception("There is item.");
        }

    }
    public class TwoStackDemo
    {
        int[] Arr;
        int Capacity;
        int Top1;
        int Top2;
        public TwoStackDemo(int capacity)
        {
            this.Capacity = capacity;
            Arr = new int[capacity];
            this.Top1 = -1;
            this.Top2 = this.Capacity;
        }

        public void Push1(int val)
        {
            if (this.Top1 + 1 < this.Top2)
            {
                this.Top1++;
                this.Arr[Top1] = val;
            }
            else
                throw new Exception();
        }
        public void Push2(int val)
        {
            if (this.Top1 + 1 < this.Top2)
            {
                this.Top2--;
                this.Arr[Top2] = val;
            }
            else
                throw new Exception();
        }


        public int Pop1()
        {
            if (this.Top1 != -1)
            {
                int temp = Arr[this.Top1];
                this.Top1--;
                return temp;
            }
            else
            {
                throw new Exception("stack one is empty.");
            }
        }
        public int Pop2()
        {
            if (this.Top2 != -1)
            {
                int temp = Arr[this.Top2];
                this.Top2--;
                return temp;
            }
            else
            {
                throw new Exception("stack one is empty.");
            }
        }

        public int Peek1()
        {
            if (this.Top1 != -1)
            {
                return Arr[this.Top1];
            }
            else
            {
                throw new Exception("stack one is empty.");
            }
        }
        public int Peek2()
        {
            if (this.Top2 != this.Capacity)
            {
                return Arr[this.Top2];
            }
            else
            {
                throw new Exception("stack one is empty.");
            }
        }

        public override string ToString()
        {
            return string.Join(",", this.Arr);
        }
    }

    class LinkNode<T>
    {
        public LinkNode<T> Next;
        public T Val;
        public LinkNode(T val)
        {
            this.Next = null;
            this.Val = val;
        }

    }
    public class LinkStack<T>
    {
        LinkNode<T> head;
        public int size { get; set; }
        public LinkStack()
        {
            this.head = null;
            this.size = 0;
        }

        public void Push(T val)
        {
            LinkNode<T> tempNode = new LinkNode<T>(val);
            this.size++;
            tempNode.Next = head;
            this.head = tempNode;
        }

        public T Pop()
        {
            if (this.head != null)
            {
                LinkNode<T> temp = head;
                head = temp.Next;
                this.size--;
                return temp.Val;
            }
            else
                throw new Exception("Stack is empty");
        }

        public T Peek()
        {
            if (this.head != null)
                return this.head.Val;
            else
                throw new Exception("Stack is empty");
        }
    }
    public class DummyStack
    {
        int[] Arr;
        int Top;
        public int Size { get; set; }
        public DummyStack()
        {
            Arr = new int[100];
            this.Top = -1;
        }

        public int Pop()
        {
            if (Top == -1)
                throw new Exception("Stack is empty");
            int temp = this.Arr[Top];
            Top--;
            this.Size--;
            return temp;
        }

        public void Push(int data)
        {
            if (Top == 100)
            {
                throw new Exception("Stack is full.");
            }

            Top++;
            Arr[Top] = data;
            this.Size++;
        }

        public int Peek()
        {
            if (Top == -1)
                throw new Exception("stack is empty");

            return this.Arr[this.Top];
        }

    }
}
