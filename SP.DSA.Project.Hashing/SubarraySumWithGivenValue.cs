using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Hashing
{
    public class SubarraySumWithGivenValue
    {
        public static void SubarraySumWithGivenValueDemo()
        {
            int[] arr = { 10, 2, -2, -20, 10 };
            int sum = -10;
            List<List<int>> result = GetSubarraySumWithGivenValue(arr, sum);
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        private static List<List<int>> GetSubarraySumWithGivenValue(int[] arr, int sum)
        {
            List<List<int>> result = new List<List<int>>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            int currSum = 0;
            int start = 0;
            List<int> ls = null;

            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];
                if (currSum == sum)
                {
                    ls = new List<int>();
                    for (int k = start; k <= i; k++)
                    {
                        ls.Add(arr[k]);
                    }
                    result.Add(ls);
                }
                if (map.ContainsKey(currSum - sum))
                {
                    start = map[currSum - sum] + 1;
                    ls = new List<int>();
                    for (int k = start; k <= i; k++)
                    {
                        ls.Add(arr[k]);
                    }
                    result.Add(ls);
                }
                map[currSum] = i;
            }

            return result;
        }
    }
}
