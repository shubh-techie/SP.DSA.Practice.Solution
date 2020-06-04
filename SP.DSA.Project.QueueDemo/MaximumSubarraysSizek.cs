using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.QueueDemo
{
    public class MaximumSubarraysSizek
    {
        public static void MaximumSubarraysSizekDemo()
        {
            int[] arr = { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };
            int k = 4;
            List<int> maxArray = GetMaximumSubarraysSizek(arr, k);
            Console.WriteLine("Maxsum is :" + string.Join(", ", maxArray));
        }

        private static List<int> GetMaximumSubarraysSizek(int[] arr, int k)
        {
            List<int> maxArray = new List<int>();
            Queue<int> trackSum = new Queue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                trackSum.Enqueue(arr[i]);
                if (i >= k)
                {
                    trackSum.Dequeue();
                    maxArray.Add(trackSum.Max());
                }

                if (i == k - 1)
                    maxArray.Add(trackSum.Max());

            }

            return maxArray;
        }
    }
}
