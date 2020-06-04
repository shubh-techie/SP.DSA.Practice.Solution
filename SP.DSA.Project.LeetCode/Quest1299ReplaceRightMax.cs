using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Quest1299ReplaceRightMax
    {
        public static void Quest1299ReplaceRightMaxDemo()
        {
            int[] arr = { 17, 18, 5, 4, 6, 1 };
            int[] output = { 18, 6, 6, 6, 1, -1 };
            int[] result = GetModifiedRightMaxArray(arr);
            Console.WriteLine(string.Join(",", arr));
            Console.WriteLine("=========================");
            Console.WriteLine(string.Join(",", result));
        }

        private static int[] GetModifiedRightMaxArray(int[] arr)
        {
            int n = arr.Length;
            Stack<int> sMax = new Stack<int>();
            int[] output = new int[n];
            output[n - 1] = -1;
            sMax.Push(arr[n - 1]);
            for (int i = n - 2; i >= 0; i--)
            {
                while (sMax.Count > 0 && sMax.Peek() <= arr[i])
                {
                    sMax.Pop();
                }

                output[i] = sMax.Count == 0 ? -1 : sMax.Peek();
                sMax.Push(arr[i]);
            }

            return output;
        }
        private static void GetModifiedArray(int[] arr)
        {
            int n = arr.Length;
            arr[n - 1] = -1;
            int max = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                int temp = arr[i];
                arr[i] = max;
                max = Math.Max(max, temp);
            }
        }

        private static void GetModifiedArrayNaive(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int max = -1;
                for (int j = i + 1; j < n; j++)
                {
                    max = Math.Max(max, arr[j]);
                }
                arr[i] = max;
            }
        }
    }
}

