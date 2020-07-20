using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class SortingPracticeOne
    {
        public static void SortingPracticeOneStart()
        {
            BubbleSortingDemoStart();
        }

        private static void BubbleSortingDemoStart()
        {
            int[] arr = { 4, 1, 3, 9, 7 };
            DisplayArray(arr);
            //BSort(arr, arr.Length);
            ISort(arr, arr.Length);
            DisplayArray(arr);
        }

        private static void ISort(int[] arr, int length)
        {
            for (int i = 1; i < length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private static void BSort(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void DisplayArray(int[] arr)
        {
            Console.WriteLine();
            Console.Write(string.Join(" ,", arr));
            Console.WriteLine();
        }
    }
}
