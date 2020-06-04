using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class FindMissingNumber
    {
        public static void FindMIssingNumberdemo()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int missingNumber = GetMissingNumberUsingHashSet(arr, arr.Length);
            Console.WriteLine($"MissingNumber :{missingNumber}");
        }

        private static int GetMissingNumber(int[] arr, int length)
        {
            int MissingNumber = 0;
            Array.Sort(arr);

            for (int i = 0; i < length; i++)
            {
                if (arr[i] >= 0)
                {

                }
            }

            return MissingNumber;
        }
        private static int GetMissingNumberUsingHashSet(int[] arr, int length)
        {
            int i = 0;
            HashSet<int> nos = new HashSet<int>();

            for (i = 0; i < length; i++)
            {
                nos.Add(arr[i]);
            }
            Array.Sort(arr);

            for (i = 1; i < length; i++)
            {
                if (!nos.Contains(i))
                {
                    return i;
                }
            }

            return i + 1;
        }
    }
}
