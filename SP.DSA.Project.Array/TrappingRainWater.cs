using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class TrappingRainWater
    {
        public static void TrappingRainWaterDemo()
        {
            int[] arr = { 3, 0, 0, 2, 0, 4 };
            int totalWater = GetTrappingRainWater(arr);
            Console.WriteLine("Total Water :" + totalWater);
        }

        private static int GetTrappingRainWater(int[] arr)
        {
            int MaxWater = 0;
            int left = 0, right = arr.Length - 1, lMax = 0, rMax = 0;

            while (left < right)
            {
                if (arr[left] < arr[right])
                {
                    if (arr[left] > lMax)
                        lMax = arr[left];
                    else
                        MaxWater += lMax - arr[left];
                    
                    left++;
                }
                else
                {
                    if (arr[right] > rMax)
                        rMax = arr[right];
                    else
                        MaxWater += rMax - arr[right];

                    right--;
                }

            }

            return MaxWater;
        }
    }
}
