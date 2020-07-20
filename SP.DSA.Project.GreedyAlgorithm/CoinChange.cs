using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.GreedyAlgorithm
{
    public class CoinChange
    {
        public static void CoinChangeDemo()
        {
            // int[] arr = { 1, 2, 5, 10, 50, 100, 500, 2000 };
            int[] arr = { 5, 10, 2, 1 };
            int amount = 51;
            Console.WriteLine("Input array.");
            Console.WriteLine(string.Join(", ", arr));

            List<List<int>> optimalCoinChnage = GetOptimalCoinChange(arr, amount);

            Console.WriteLine("Here is optimal solution.");
            foreach (var item in optimalCoinChnage)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        private static List<List<int>> GetOptimalCoinChange(int[] arr, int amount)
        {
            List<List<int>> result = new List<List<int>>();
            //Sort the array.
            Array.Sort(arr, (a, b) => (b - a));
            Console.WriteLine("Sorted Array");
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine();
            int index = 0;
            while (index < arr.Length)
            {
                int coinValue = arr[index];
                if (coinValue <= amount)
                {
                    int count = amount / coinValue;
                    Console.WriteLine("coins: {0}, count :{1}", coinValue, count);
                    result.Add(new List<int>() { coinValue, count });
                    amount = amount - count * coinValue;
                }
                index++;
            }

            return result;
        }
    }
}
