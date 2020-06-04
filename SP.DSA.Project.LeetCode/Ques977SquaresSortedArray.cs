using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques977SquaresSortedArray
    {
        public static void Ques977SquaresSortedArrayDemo()
        {
            int[] arr = { -4, -1, 0, 3, 10 };
            int[] result = GetQues977SquaresSortedArray(arr);
            Console.WriteLine(String.Join(", ", result));
        }

        private static int[] GetQues977SquaresSortedArray(int[] arr)
        {
            if (arr.Length == 0) return arr;
            int size = arr.Length, min = 0, max = size - 1;
            int[] sortedArr = new int[size];
            size = size - 1;
            while (size >= 0)
            {
                if (Math.Abs(arr[min]) >= Math.Abs(arr[max]))
                {
                    sortedArr[size] = arr[min] * arr[min];
                    min++;
                }
                else
                {
                    sortedArr[size] = arr[max] * arr[max];
                    max--;
                }
                size--;
            }

            return sortedArr;
        }
    }
}
