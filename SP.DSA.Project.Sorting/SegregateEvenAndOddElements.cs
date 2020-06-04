using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class SegregateEvenAndOddElements
    {
        public static void SegregateEvenAndOddElementsDemo()
        {
            int[] arr = { 12, 34, 45, 9, 8, 90, 3 };
            int j = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
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
