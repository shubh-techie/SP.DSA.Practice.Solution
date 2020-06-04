using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class RemoveDuplicateFromArray
    {
        public static void RemoveDuplicateFromArrayDemo()
        {
            int[] arr = { 100, 100, 100, 200, 300, 300, 500, 400, 400, 100, 100, 100, 100, 100, 100 };
            List<int> output = GetUniqueArray(arr);

            Console.WriteLine(string.Join(",", output));
        }

        private static List<int> GetUniqueArray(int[] arr)
        {
            if (arr == null) throw new Exception("Please provide a valid array");
            if (arr.Length == 1) return arr.ToList();

            List<int> output = new List<int>();
            HashSet<int> track = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!track.Contains(arr[i]))
                {
                    track.Add(arr[i]);
                    output.Add(arr[i]);
                }
            }

            return output;
        }
    }
}
