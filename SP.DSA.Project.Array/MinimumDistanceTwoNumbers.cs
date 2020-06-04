using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class MinimumDistanceTwoNumbers
    {
        public static void MinimumDistanceDemo()
        {
            string input = "94 36 35 59 48 12 50 86 43 95 4 5 36 28 61 82 75 13 54 58 24 9 59 88 64 74 80 18 42 41 64 87 76 99 45 75 10 46 61 4 92 16 60 28 96 20 61 70 84 14 79 8 75 37 47 90 10 26 8 3 18 71 89 94 21 85 20 82 82 32 86 73 48 45 52 43 17 64 12 100 78 42 59 52 30 6 41 91 83 100 93 1 23 33 94";
            int x = 42; int y = 68;
            int[] arr = { };
            int output = GetMinimumDistance(arr, arr.Length, 1, 2);
            Console.WriteLine("output" + output);
        }

        private static int GetMinimumDistance(int[] arr, int length, int x, int y)
        {
            int xIndex = 0, yIndex = 0, min = int.MaxValue;

            for (int i = 0; i < length; i++)
            {
                if (arr[i] == x)
                    xIndex = arr[i];
                if (arr[i] == x)
                    yIndex = arr[i];

                if (xIndex != 0 && yIndex != 0)
                {
                    min = Math.Min(min, Math.Abs(x - y));
                }
            }

            if (min != int.MaxValue)
                return min;

            return -1;
        }
    }
}
