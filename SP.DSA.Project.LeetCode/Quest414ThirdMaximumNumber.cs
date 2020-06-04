using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Quest414ThirdMaximumNumber
    {
        public static void Quest414ThirdMaximumNumberDemo()
        {
            int[] arr = { 2 };
            largestAndSecondLargest(arr);
            //Console.WriteLine($" third max number {output}");
        }

        public static void largestAndSecondLargest(int[] arr)
        {
            HashSet<int> thirdNumber = new HashSet<int>();
            int size = arr.Length;

            for (int i = 0; i < size; i++)
            {
                thirdNumber.Add(arr[i]);
                if (thirdNumber.Count > 2)
                {
                    thirdNumber.Remove(thirdNumber.Min());
                }
            }
            if (thirdNumber.Count == 2)
            {
                Console.WriteLine($"{thirdNumber.Max()} {thirdNumber.Min()}");
            }
            else
            {
                Console.WriteLine($"{thirdNumber.Max()} {-1}");
            }
        }

        private static int Quest414ThirdMaximumNumberHelper(int[] arr)
        {
            HashSet<int> thirdNumber = new HashSet<int>();
            int size = arr.Length;

            for (int i = 0; i < size; i++)
            {
                thirdNumber.Add(arr[i]);
                Console.WriteLine(string.Join(",", thirdNumber));
                if (thirdNumber.Count > 3)
                {
                    thirdNumber.Remove(thirdNumber.Min());
                }
            }

            if (thirdNumber.Count == 3)
            {
                return thirdNumber.Min();
            }

            return thirdNumber.Max();
        }
    }
}
