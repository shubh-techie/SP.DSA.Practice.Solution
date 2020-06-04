using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class Equilibrium
    {
        public static void equilibriumPointDemo()
        {
            long[] arr = { 1, 3, 5, 2, 2 };
            Console.WriteLine(equilibriumPoint(arr, arr.Length));
        }
        public static int equilibriumPoint(long[] arr, int n)
        {
            if (arr.Length == 1) return 1;
            // Your code here
            long sum = 0, leftSum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            for (int i = 0; i < n; ++i)
            {
                leftSum += arr[i];
                if (leftSum == sum)
                    return i;
                sum = sum - arr[i];
            }

            return -1;
        }
    }
}
