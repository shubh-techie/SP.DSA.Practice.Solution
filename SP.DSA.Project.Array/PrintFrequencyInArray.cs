using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class PrintFrequencyInArray
    {
        public static void PrintFrequencyInArrayDemo()
        {
            int[] arr = { 2, 3, 2, 3, 5 };
            int[] output = PrintFrequencyInArrayHelper(arr);
            for (int i = 1; i <= arr.Length; i++)
            {
                Console.WriteLine($"{i} occurring {output[i]} times.");
            }
        }

        private static int[] PrintFrequencyInArrayHelper(int[] arr)
        {
            int size = arr.Length;
            int[] freq = new int[size + 1];

            for (int i = 0; i < size; i++)
            {
                freq[arr[i]]++;
            }

            return freq;
        }
    }
}
