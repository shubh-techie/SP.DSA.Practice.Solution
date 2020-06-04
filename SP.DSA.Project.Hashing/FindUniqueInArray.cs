using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class FindUniqueInArray
    {

        public static void PrintUniqueDemo()
        {
            int[] arr = { 100, 100, 100, 200, 300, 300, 500, 400, 400, 100, 100, 100, 100, 100, 100 };
            PrintUniqueDemoHelper(arr);

        }

        private static void PrintUniqueDemoHelper(int[] arr)
        {
            Dictionary<int, int> TrackUnique = new Dictionary<int, int>();
            int size = arr.Length;

            for (int i = 0; i < size; i++)
            {
                if (!TrackUnique.ContainsKey(arr[i]))
                {
                    TrackUnique.Add(arr[i], 1);
                }
                else
                {
                    TrackUnique[arr[i]]++;
                }
            }

            foreach (var item in TrackUnique)
            {
                Console.WriteLine($"Here is unique {item.Key} and {item.Value}");
            }
        }
    }
}
