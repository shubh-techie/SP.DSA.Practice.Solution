using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class NextGreaterElement
    {
        public static void NextGreaterElementDemo()
        {
            int[] arr = { 5, 15, 10, 8, 6, 12, 9, 18 };
            List<int> nextGreaters = GetNextGreaterElement(arr);
            Console.WriteLine("Next greaters :" + string.Join(",", nextGreaters));
        }

        private static List<int> GetNextGreaterElement(int[] arr)
        {
            List<int> nextGreaters = new List<int>();
            Stack<int> track = new Stack<int>();
            int size = arr.Length;
            nextGreaters.Add(-1);
            track.Push(arr[size - 1]);

            for (int i = size - 2; i >= 0; i--)
            {
                while (track.Count > 0 && track.Peek() <= arr[i])
                {
                    track.Pop();
                }
                nextGreaters.Add(track.Count == 0 ? -1 : track.Peek());
                track.Push(arr[i]);
            }
            nextGreaters.Reverse();
            return nextGreaters;
        }

        private static List<int> GetNextGreaterElementNaive(int[] arr)
        {
            List<int> nextGreaters = new List<int>();
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                int res = -1;
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        res = arr[j];
                        break;
                    }
                }
                nextGreaters.Add(res);
            }
            return nextGreaters;
        }
    }
}
