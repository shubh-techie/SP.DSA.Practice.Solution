using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class MajorityElement
    {
        public static void MajorityElementDemo()
        {
            int[] arr = { 2, 2, 1, 1, 1, 2, 2 };
            int result = GetMajorityElement(arr);
            Console.WriteLine("majority element " + result);
        }

        private static int GetMajorityElement(int[] arr)
        {
            int major = arr[0], count = 1, size = arr.Length;
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine("i={0}  val={1}", i, arr[i]);
                if (count == 0)
                {
                    major = arr[i];
                    count = 1;
                }
                else if (major == arr[i])
                    count++;
                else
                    count--;
            }

            return major;
        }

        private static int GetMajorityElementSolution1(int[] arr)
        {
            int count = 1, res = 0, size = arr.Length;
            for (int i = 1; i < size; i++)
            {
                if (arr[res] == arr[i])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    res = i;
                    count = 1;
                }
            }
            count = 0;

            for (int i = 0; i < size; i++)
            {
                if (arr[res] == arr[i])
                    count++;
            }

            if (count <= size / 2)
                return -1;

            return arr[res];
        }
    }
}
