using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques1295FindEvenNumberDigits
    {
        public static void Ques1295FindEvenNumberDigitsDemo()
        {
            int[] arr = { 12, 345, 2, 6, 7896 };
            Console.WriteLine("Even nos of count :" + FindNumbers(arr));
        }

        public static int FindNumbers(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int no = arr[i];
                if ((no > 9 && no < 100) || (no > 999 && no < 10000) || no == 100000)
                    count++;
            }
            return count;
        }

        private static int GetLength(int no)
        {
            return no.ToString().Length;
        }
    }
}
