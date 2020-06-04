using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class OverlappingIntervals
    {
        public static void OverlappingIntervalsDemo()
        {
            int[] arr = { 1, 3, 2, 4, 6, 8, 9, 10 };
            List<List<int>> result = GetOverlappingIntervals(arr);
        }

        private static List<List<int>> GetOverlappingIntervals(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                set.Add(arr[i]);
            }


            return result;

        }
    }
}
