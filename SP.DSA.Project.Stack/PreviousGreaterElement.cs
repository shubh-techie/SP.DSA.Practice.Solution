using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class PreviousGreaterElement
    {
        public static void PreviousGreaterElementDemo()
        {
            //int[] arr = { 15, 10, 18, 12, 4, 6, 2, 8 };
            int[] arr = { 20, 30, 10, 5, 15 };
            List<int> previous = GetPreviousGreaterElement(arr);
            Console.WriteLine("previous > : " + string.Join(",", previous));
        }

        private static List<int> GetPreviousGreaterElement(int[] arr)
        {
            List<int> previous = new List<int>();
            Stack<int> track = new Stack<int>();

            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                while (track.Count > 0 && track.Peek() <= arr[i])
                {
                    track.Pop();
                }
                previous.Add(track.Count == 0 ? -1 : track.Peek());
                track.Push(arr[i]);
            }
            return previous;
        }

        private static List<int> GetPreviousGreaterElementNaive(int[] arr)
        {
            List<int> previous = new List<int>();
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                int res = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] >= arr[i])
                    {
                        res = arr[j];
                        break;
                    }
                }
                previous.Add(res);
            }


            return previous;
        }
    }
}
