using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class MissingNumber
    {
        public static void MissingNumberDemo()
        {
            int[] arr = { 8, 7, 1, 2, 8, 4, 4, 4, 3 };
            int n = arr.Length;

            // int output = MissingNumberHelper(arr, n);
            // Console.WriteLine("output" + output);

            List<int> duplicates = GetDuplicates(arr, n);
            Console.WriteLine(string.Join(", ", duplicates));
        }

        private static List<int> GetDuplicates(int[] arr, int n)
        {
            HashSet<int> set = new HashSet<int>();
            List<int> arl = new List<int>();
            //Arrays.sort(arr);
            int left = 0, right = n - 1;
            while (left <= right)
            {
                Console.WriteLine(string.Join(", ", set));
                Console.WriteLine(string.Join(", ", arl));

                if (set.Contains(arr[left]) && !arl.Contains(arr[left]))
                {
                    arl.Add(arr[left]);
                }
                else
                    set.Add(arr[left]);


                if (set.Contains(arr[right]) && !arl.Contains(arr[right]))
                {
                    arl.Add(arr[right]);
                }
                else
                    set.Add(arr[right]);


                left++;
                right--;
            }

            if (arl.Count == 0)
                arl.Add(-1);
            arl.Sort();
            return arl;
        }

        private static int MissingNumberHelper(int[] arr, int n)
        {
            HashSet<int> set = new HashSet<int>();
            int output = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                set.Add(arr[i]);
            }

            for (int i = 1; i < n; i++)
            {
                if (!set.Contains(i))
                {
                    output = 1;
                    break;
                }
            }

            return output;
        }
    }
}
