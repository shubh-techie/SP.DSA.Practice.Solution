using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class SubarrayWithGivenSum
    {
        public static void SubarrayWithGivenSumDemo()
        {
            //int[] arr = { 1, 2, 3, 7, 5 };
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] arr = { 5, 7, 1, 2 };
            int sum = 15;
            GetSubarrayWithGivenSum(arr, sum);
        }

        private static void GetSubarrayWithGivenSum(int[] arr, int sum)
        {
            int start = 0, cSum = 0, size = arr.Length;
            for (int end = 0; end < size; end++)
            {
                cSum = cSum + arr[end];

                while (cSum >= sum && start < end)
                {
                    if (cSum == sum)
                    {
                        int i = start + 1;
                        int j = end + 1;
                        Console.WriteLine("Position :{0} {1}", i, j);
                        return;
                    }

                    cSum = cSum - arr[start];
                    start++;
                }
            }
        }

        private static void GetSubarrayWithGivenSumNaive(int[] arr, int sum)
        {
            int size = arr.Length;
            int uMax = 0;
            int[] position = new int[2];

            for (int i = 0; i < size; i++)
            {
                int currSum = 0;
                for (int j = i; j < size; j++)
                {
                    currSum += arr[j];
                    if (currSum == sum)
                    {
                        Console.WriteLine("Position :{0} {1}", i + 1, j + 1);
                        if (j - i > uMax)
                        {
                            uMax = j - i;
                            position[0] = i + 1;
                            position[1] = j + 1;
                        }
                        break;
                    }
                }
            }

            Console.WriteLine("Max Length subarray: " + string.Join(",", position));
        }
    }
}
