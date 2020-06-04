using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class FindDuplicatesInArray
    {
        public static void FindDuplicatesDemo()
        {
            int[] arr = { 3, 2, 3, 2, 3, 3, 4 };
            List<int> duplicate = GetDuplicates(arr);
            Console.WriteLine(string.Join(",", duplicate));
        }

        private static List<int> GetDuplicates(int[] arr)
        {
            List<int> duplicates = new List<int>();
            HashSet<int> track = new HashSet<int>();
            HashSet<int> seen = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!seen.Contains(arr[i]))
                    seen.Add(arr[i]);
                else
                    track.Add(arr[i]);
            }


            return track.ToList();
        }
    }
}
