using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class LeadersinAnArray
    {
        public static void LeadersinAnArrayDemo()
        {
            int[] arr = { 16, 17, 4, 3, 5, 2 };
            int size = arr.Length;
            List<int> leaders = GetLeadersinAnArrayEfficient(arr, size);

            Console.WriteLine(string.Join(",", leaders));
        }

        private static List<int> GetLeadersinAnArrayEfficient(int[] arr, int size)
        {
            List<int> leaders = new List<int>();
            int rMax = arr[size - 1];
            leaders.Add(arr[size - 1]);
            for (int i = size - 2; i >= 0; i--)
            {
                rMax = Math.Max(rMax, arr[i]);
                if (arr[i] >= rMax)
                {
                    leaders.Add(arr[i]);
                }
            }
            leaders.Reverse();
            return leaders;
        }

        private static List<int> GetLeadersinAnArray(int[] arr, int size)
        {
            List<int> leadres = new List<int>();

            for (int i = 0; i < size; i++)
            {
                bool isleader = false;
                for (int j = i; j < size; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        isleader = false;
                        break;
                    }
                    else
                        isleader = true;
                }
                if (isleader)
                    leadres.Add(arr[i]);
            }

            return leadres;
        }
    }
}
