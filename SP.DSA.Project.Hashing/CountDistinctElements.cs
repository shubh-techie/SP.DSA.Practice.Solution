using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class CountDistinctElements
    {
        public static void CountDistinctElementsDemo()
        {
            //int[] arr = { 1, 2, 1, 3, 4, 2, 3 };
            int[] arr = { 1, 2, 4, 4 };
            List<int> result = GetCountDistinctElements(arr, 2);
            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> GetCountDistinctElements(int[] arr, int k)
        {
            List<int> counts = new List<int>();
            Dictionary<int, int> fre = new Dictionary<int, int>();
            int start = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (fre.ContainsKey(arr[i]))
                    fre[arr[i]]++;
                else
                    fre[arr[i]] = 1;

                if (i >= k - 1)
                {
                    counts.Add(fre.Count);

                    if (fre[arr[start]] == 1)
                    {
                        fre.Remove(arr[start]);
                    }
                    else
                    {
                        fre[arr[start]]--;
                    }
                    start++;
                }
            }

            return counts;
        }


    }
}
