using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class SearchElementInAnArray
    {
        public static void SearchElementInAnArrayDemo()
        {
            int[] arr = { 16, 82, 58, 24, 37, 62, 24, 0, 36 };
            int key = 36;
            int searchIndex = GetIndex(arr, key);
            Console.WriteLine($"index of key :{key}, is :{searchIndex}");
        }

        private static int GetIndex(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            Array.Sort(arr);

            while (left <= right)
            {
                int mid = (left + right) / 2;
                //Console.WriteLine(arr[mid]);
                if (arr[mid] == key)
                {
                    return mid;
                }
                else if (key < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}
