using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class TripletsSumZero
    {
        public static void TripletsSumZeroDemo()
        {
            // int[] arr = { 0, -1, 2, -3, 1 };
            int[] arr = { 1, 2, 3 };
            int size = arr.Length;
            bool isTriplate = CheckTriplate(arr, arr.Length);
            Console.WriteLine("isTriplate   :" + isTriplate);
        }

        private static bool CheckTriplate(int[] arr, int length)
        {
            Array.Sort(arr);
            for (int i = 0; i < length - 2; i++)
            {
                if (isTriplateFoundWithSumOfTwo(arr, i, length))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isTriplateFoundWithSumOfTwo(int[] arr, int i, int length)
        {
            int low = i + 1, right = length - 1;
            while (low <= right)
            {
                int sum = arr[i] + arr[low] + arr[right];
                if (sum == 0)
                {
                    low++; right++;
                    return true;
                }
                if (sum < 0)
                    low++;
                else
                    right--;
            }
            return false;
        }
    }
}
