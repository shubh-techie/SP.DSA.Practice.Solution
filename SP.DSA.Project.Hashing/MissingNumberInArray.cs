using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public static class MissingNumberInArray
    {
        public static void MissingNumberInArrayDemo()
        {
            int[] arr = { 4, 7, 1, 6 };
            int n = 8;
            List<int> missingNumbers = GetMissingNumber(arr, 8);
            Console.WriteLine(string.Join(",", missingNumbers));
        }

        private static List<int> GetMissingNumber(int[] arr, int n)
        {
            List<int> output = new List<int>();
            HashSet<int> arrSet = new HashSet<int>();
            foreach (var item in arr)
            {
                arrSet.Add(item);
            }

            for (int i = 1; i <= n; i++)
            {
                if (!arrSet.Contains(i))
                    output.Add(i);
            }
            return output;
        }
    }
}
