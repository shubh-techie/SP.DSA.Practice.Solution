using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class SegregateNegAndPosNumbers
    {
        public static void SegregateNegAndPosNumbersDemo()
        {
            int[] arr = { 12, 11, -13, -5, 6, -7, 5, -3, -6 };

            int j = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
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
