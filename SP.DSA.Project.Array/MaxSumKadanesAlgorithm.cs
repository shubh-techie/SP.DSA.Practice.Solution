using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class MaxSumKadanesAlgorithm
    {
        public static void MaxSumKadanesAlgorithmDemo()
        {
            int[] arr = { 1, 2, 3, -2, 5 };
            Console.WriteLine(GetMaxSumKadanesAlgorithm(arr));
        }

        private static int GetMaxSumKadanesAlgorithm(int[] arr)
        {
            int uMax = arr[0], lMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (lMax + arr[i] > arr[i])
                {
                    lMax = lMax + arr[i];
                }
                else
                    lMax = arr[i];

                uMax = Math.Max(lMax, uMax);
            }

            return uMax;
        }
    }
}
