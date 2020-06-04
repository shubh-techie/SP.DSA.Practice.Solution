using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class CheckTwoArrayEqual
    {
        public static void CheckTwoArrayEqualDemo()
        {
            //int[] arr1 = { 1, 2, 5, 4, 0 };
            //int[] arr2 = { 2, 4, 5, 0, 1 };
            int[] arr1 = { 7, 7, 1 };
            int[] arr2 = { 1, 7, 6 };
            bool isEqual = isEqualArray(arr1, arr2);
            Console.WriteLine("is equal :" + isEqual);
        }

        private static bool isEqualArray(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (var item in arr1)
            {
                if (map.ContainsKey(item))
                    map[item]++;
                else
                    map.Add(item, 1);
            }

            foreach (var item in arr2)
            {
                if (map.ContainsKey(item))
                {
                    map[item]--;
                    if (map[item] < 0)
                        return false;
                }
                else
                    return false;
            }

            return true;
        }
    }
}

