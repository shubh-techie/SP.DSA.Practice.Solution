using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques189RotateArray
    {
        public static void Ques189RotateArrayDemo()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("Before Rotate" + string.Join(",", arr));
            int k = 3;
            Rotate(arr, k);
            Console.WriteLine("After Rotate" + string.Join(",", arr));
        }
        public static void Rotate(int[] arr, int k)
        {
            k = k % arr.Length;
            Console.WriteLine("k :" + k);
            ReverseAnArray(arr, 0, arr.Length - k);
            ReverseAnArray(arr, arr.Length - k, arr.Length);
            ReverseAnArray(arr, 0, arr.Length);
        }

        private static void ReverseAnArray(int[] arr, int start, int end)
        {
            end = end - 1;
            while (start <= end)
            {
                int temp = arr[end];
                arr[end] = arr[start];
                arr[start] = temp;
                start++;
                end--;
            }
        }
    }
}
