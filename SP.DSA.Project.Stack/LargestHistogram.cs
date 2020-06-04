using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Stack
{
    public class LargestHistogram
    {
        public static void LargestHistogramDemo()
        {
            int[] arr = { 6, 2, 5, 4, 1, 5, 6 };
            int maxArea = GetLargestHistogramEfficient(arr);
            Console.WriteLine("Max Area : " + maxArea);
        }

        private static int GetLargestHistogramEfficient(int[] arr)
        {
            return 0;
        }

        private static int GetLargestHistogram(int[] arr)
        {
            int[] ps = GetPreviousSmallerNumber(arr, arr.Length);
            int[] ns = GetNextSmallerNumber(arr, arr.Length);

            int uMax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currMax = arr[i];
                currMax += (i - ps[i] - 1) * arr[i];
                currMax += (ns[i] - i - 1) * arr[i];

                uMax = Math.Max(uMax, currMax);
            }

            return uMax;
        }

        private static int[] GetPreviousSmallerNumber(int[] arr, int size)
        {
            int[] output = new int[size];
            Stack<int> smallStack = new Stack<int>();
            for (int i = 0; i < size; i++)
            {
                while (smallStack.Count > 0 && arr[smallStack.Peek()] >= arr[i])
                {
                    smallStack.Pop();
                }
                output[i] = smallStack.Count == 0 ? -1 : smallStack.Peek();
                smallStack.Push(i);
            }
            return output;
        }

        private static int[] GetNextSmallerNumber(int[] arr, int size)
        {
            int[] output = new int[size];
            Stack<int> smallStack = new Stack<int>();
            output[size - 1] = 7;
            for (int i = size - 1; i >= 0; i--)
            {
                while (smallStack.Count > 0 && arr[smallStack.Peek()] >= arr[i])
                {
                    smallStack.Pop();
                }
                output[i] = smallStack.Count == 0 ? 7 : smallStack.Peek();
                smallStack.Push(i);
            }
            return output;
        }

        private static int GetLargestHistogramNaive(int[] arr)
        {
            int uMax = 0, size = arr.Length;

            for (int i = 0; i < size; i++)
            {
                int area = arr[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] >= arr[i])
                        area += arr[i];
                    else
                        break;
                }

                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] >= arr[i])
                        area += arr[i];
                    else
                        break;
                }

                Console.WriteLine($"for :{i} area :" + area);
                uMax = Math.Max(uMax, area);
            }

            return uMax;
        }
    }
}
