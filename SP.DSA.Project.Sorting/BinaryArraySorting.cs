using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class BinaryArraySorting
    {
        public static void BinaryArraySortingDemo()
        {
            int[] arr = { 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0 };

            int j = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 1)
                {
                    j++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            Console.WriteLine(string.Join(",", arr));
        }
    }
}
