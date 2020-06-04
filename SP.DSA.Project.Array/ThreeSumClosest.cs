using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class ThreeSumClosest
    {
        public static void ThreeSumClosestDemo()
        {
            //int[] arr = { -7, 9, 8, 3, 1, 1 };
            int[] arr = { 5, 2, 7, 5 };
            int target = 13;
            int triplateSum = GetThreeSumClosest(arr, target);
            Console.WriteLine("triplateSum max:" + triplateSum);
        }

        private static int GetThreeSumClosest(int[] arr, int target)
        {
            //Sorting the array
            int diff = int.MaxValue, maxSum = 0;
            Array.Sort(arr);
            int size = arr.Length;

            for (int i = 0; i < size - 3; i++)
            {
                int left = i + 1, right = arr.Length - 1;

                while (left < right)
                {
                    int sum = arr[i] + arr[left] + arr[right];

                    if (Math.Abs(target - sum) <= Math.Abs(diff))
                    {
                        Console.WriteLine("{0},{1},{2}", arr[i], arr[left], arr[right]);
                        Console.WriteLine("sum =" + sum);
                        diff = Math.Abs(target - sum);
                        maxSum = Math.Max(sum, maxSum);
                    }
                    if (sum < target)
                        left++;
                    else
                        right--;

                }

                if (diff == 0 || target < arr[i]) break;
            }

            return maxSum;
        }

    }
}
