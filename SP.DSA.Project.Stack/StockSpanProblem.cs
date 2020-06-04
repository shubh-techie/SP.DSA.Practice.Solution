using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class StockSpanProblem
    {
        public static void StockSpanProblemDemo()
        {
            int[] arr = { 15, 13, 12, 14, 16, 8, 6, 4, 10, 30 };
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            //int[] arr = { 7, 6, 5, 4, 3, 2, 1 };
            List<int> spanArr = GetStockSpanProblem(arr);
            Console.WriteLine(string.Join(",", spanArr));
        }

        private static List<int> GetStockSpanProblem(int[] arr)
        {
            int size = arr.Length;
            List<int> span = new List<int>();
            Stack<int> track = new Stack<int>();
            for (int i = 0; i < size; i++)
            {
                while (track.Count > 0 && arr[i] >= arr[track.Peek()])
                {
                    track.Pop();
                }
                int _span = track.Count == 0 ? i + 1 : i - track.Peek();
                span.Add(_span);
                track.Push(i);
            }

            return span;
        }

        private static List<int> GetStockSpanProblemNaive(int[] arr)
        {
            int size = arr.Length;
            List<int> span = new List<int>();
            for (int i = 0; i < size; i++)
            {
                int count = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (arr[i] >= arr[j])
                        count++;
                }
                span.Add(count);
            }

            return span;
        }
    }
}
