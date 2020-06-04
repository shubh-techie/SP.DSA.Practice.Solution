using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class FrequenciesArrayElements
    {
        public static void FrequenciesArrayElementsDemo()
        {
            //int[] arr = { 2, 3, 2, 3, 5 };
            int[] arr = { 3, 3, 3, 3, 3 };
            PrintFrequency(arr);
        }

        private static void PrintFrequency(int[] arr)
        {
            int[] result = new int[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(i);
                result[arr[i]]++;
            }

            for (int i = 1; i < result.Length; i++)
            {
                Console.WriteLine($"{i} occurring {result[i]} times.");
            }
        }
    }
}
