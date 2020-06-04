using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class RearrangeArrayAlternately
    {
        public static void RearrangeArrayAlternatelyDemo()
        {
            //int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            rearrange(arr, arr.Length);
            Console.WriteLine(string.Join(",", arr));
        }

        public static void rearrange(int[] arr, int n)
        {
            // initialize index of first minimum and first 
            // maximum element 
            int max_idx = n - 1, min_idx = 0;

            // store maximum element of array 
            int max_elem = arr[n - 1] + 1;

            // traverse array elements 
            for (int i = 0; i < n; i++)
            {
                // at even index : we have to put maximum element 
                if (i % 2 == 0)
                {
                    arr[i] += (arr[max_idx] % max_elem) * max_elem;
                    max_idx--;
                }

                // at odd index : we have to put minimum element 
                else
                {
                    arr[i] += (arr[min_idx] % max_elem) * max_elem;
                    min_idx++;
                }
            }

            Console.WriteLine(string.Join(",", arr));

            // array elements back to it's original form 
            for (int i = 0; i < n; i++)
                arr[i] = arr[i] / max_elem;

        }

        private static void RearrangeArrayAlternatelyDemoHelper(int[] arr)
        {
            List<int> result = new List<int>();
            int size = arr.Length - 1;
            for (int i = 0; i < arr.Length; i += 2)
            {
                //
                int temp = arr[size];
                ShiftByOne(i, arr, 1);
                arr[i] = temp;
            }
        }
        private static void ShiftByOne(int start, int[] arr, int k)
        {
            for (int i = arr.Length - 1; i >= start + 1; i--)
            {
                arr[i] = arr[i - 1];
            }
        }
    }
}
