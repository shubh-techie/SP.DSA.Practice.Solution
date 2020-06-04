using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class TripletSumInArray
    {
        public static void TripletSumInArrayDemo()
        {
            int[] arr = { 1, 4, 45, 6, 10, 8 };
            int sum = 13;
            Console.WriteLine(TripletSumInArrayDemoHelper(arr, arr.Length, sum));
        }

        public static bool TripletSumInArrayDemoHelper(int[] arr, int len, int sum)
        {
            Array.Sort(arr);
            bool result = false;
            for (int i = 0; i < len - 2; i++)
            {
                result = SumTwo(arr, arr[i], sum, i + 1, len);
                if (result == true) break;
            }
            return result;
        }

        private static bool SumTwo(int[] arr, int one, int sum, int left, int right)
        {
            int low = left, high = right - 1;

            while (low < high)
            {
                int currSum = one + arr[low] + arr[high];
                if (currSum == sum)
                {
                    Console.WriteLine(@"The triplet {0}, {1}, {2} in the array sums up to 13.", one, arr[low++], arr[high--]);
                    return true;
                }
                else if (currSum < sum)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }
            return false;
        }
    }
}
