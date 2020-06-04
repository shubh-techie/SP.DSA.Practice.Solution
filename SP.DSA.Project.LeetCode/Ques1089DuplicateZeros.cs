using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques1089DuplicateZeros
    {
        public static void Ques1089DuplicateZerosDemo()
        {
            int[] arr = { 1, 0, 2, 3, 0,0, 4, 5, 0 };
            Console.WriteLine("Printing before array :   [" + string.Join(",", arr));
            InsertQues1089DuplicateZeros(arr);
            Console.WriteLine("Printing after array :  [" + string.Join(",", arr));
        }

        private static void InsertQues1089DuplicateZeros(int[] arr)
        {
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == 0)
                {
                    ShiftRightByOne(arr, i, size);
                    arr[i] = 0;
                    i++;
                }
            }
        }

        public static void ShiftRightByOne(int[] arr, int start, int end)
        {
            for (int i = end - 1; i > start; i--)
            {
                arr[i] = arr[i - 1];
            }
        }
    }
}
