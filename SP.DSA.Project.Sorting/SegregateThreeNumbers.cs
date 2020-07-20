using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class SegregateThreeNumbers
    {
        public static void SegregateThreeNumbersDemo()
        {
            int[] arr = { 0, 2, 1, 2, 0 };
            Console.WriteLine(string.Join(", ", arr));
            DoIT(arr);
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void DoIT(int[] arr)
        {
            int left = 0, middle = 0, right = arr.Length - 1;

            while (middle < right)
            {
                switch (arr[middle])
                {
                    case 0:
                        swapping(arr, left, middle);
                        left++;
                        middle++;
                        break;
                    case 1:
                        middle++;
                        break;
                    case 2:
                        swapping(arr, middle, right);
                        right--;
                        break;
                }
            }
        }

        private static void swapping(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
