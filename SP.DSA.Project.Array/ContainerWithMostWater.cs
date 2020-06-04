using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class ContainerWithMostWater
    {

        public static void ContainerWithMostWaterDemo()
        {
            int[] arr = { 3, 1, 2, 4, 5 };
            int max = GetContainerWithMostWater(arr);
            Console.WriteLine("Max water :" + max);
        }

        private static int GetContainerWithMostWater(int[] arr)
        {
            int left = 0, right = arr.Length - 1, uMax = 0;
            while (left < right)
            {
                uMax = Math.Max(uMax, (right - left) * Math.Min(arr[left], arr[right]));
                if (arr[left] < arr[right])
                    left++;
                else
                    right--;
            }
            return uMax;
        }
    }
}
