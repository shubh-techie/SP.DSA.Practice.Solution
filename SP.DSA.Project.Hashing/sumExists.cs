using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class SumExists
    {
        public static void SumExistsDemo()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = 14;
            int count = GetSumExistsPairs(arr, sum);
            Console.WriteLine("Total pair of sum :" + count);
        }

        private static int GetSumExistsPairs(int[] arr, int sum)
        {
            HashSet<int> pair = new HashSet<int>();
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int oPair = sum - arr[i];
                if (pair.Contains(oPair))
                {
                    count++;
                    Console.WriteLine("{0} ,{1}", arr[i], oPair);
                }
                else
                {
                    pair.Add(arr[i]);
                }
            }

            return count;
        }
    }
}
