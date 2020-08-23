using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.DynamicProgramming
{
    public class MatrixChainMultiplicationSolution
    {
        public void MatrixChainMultiplicationDemo()
        {
            //MatrixChainMultiplication();
            //PalindromePartitioning();
            EggDropingProblem();
        }

        private void EggDropingProblem()
        {
            int eggs = 2;
            int floors = 10;
            int critiaCalFloor = GetCritialFoorNumber(eggs, floors);
            Console.WriteLine("critiaCalFloor : " + critiaCalFloor);


            critiaCalFloor = GetCritialFoorNumberBottomUP(eggs, floors);
            Console.WriteLine("critiaCalFloor : " + critiaCalFloor);
        }

        private int GetCritialFoorNumberBottomUP(int eggs, int floors)
        {
            int[,] cache = new int[eggs + 1, floors + 1];

            // fill trials for floor one and zeros
            int i, j, k;
            for (i = 0; i <= eggs; i++)
            {
                cache[i, 0] = 0;
                cache[i, 1] = 1;
            }

            for (j = 1; j <= floors; j++)
            {
                cache[1, j] = j;
            }

            for (i = 2; i <= eggs; i++)
            {
                for (j = 2; j <= floors; j++)
                {
                    cache[i, j] = int.MaxValue;
                    for (k = 1; k <= j; k++)
                    {
                        int tempMin = 1 + Math.Max(cache[i - 1, k - 1], cache[i, j - k]);
                        cache[i, j] = Math.Min(cache[i, j], tempMin);
                    }
                }
            }
            Common.PrintMatrix(cache);
            return cache[eggs, floors];
        }

        private int GetCritialFoorNumber(int eggs, int floors)
        {
            if (floors == 1 || floors == 0) return floors;
            if (eggs == 1) return floors;

            int uMin = int.MaxValue;
            for (int k = 1; k <= floors; k++)
            {
                int res = 1 + Math.Max(GetCritialFoorNumber(eggs - 1, k - 1), GetCritialFoorNumber(eggs, floors - k));
                uMin = Math.Min(uMin, res);
            }
            return uMin;
        }

        private void PalindromePartitioning()
        {
            string str = "ababbbabbababa";
            int n = str.Length;
            int parCount = GetPalindromePartitioningCount(str, 0, n - 1);
            Console.WriteLine("min cut :" + parCount);

            int[,] cache = new int[n, n];
            Common.FillMatrixWithNegative(cache);
            parCount = GetPalindromePartitioningCountMemo(str, 0, n - 1, cache);
            Console.WriteLine("min cut :" + parCount);
        }

        private int GetPalindromePartitioningCountMemo(string str, int i, int j, int[,] cache)
        {
            if (i >= j) return 0;
            if (cache[i, j] != -1)
                return cache[i, j];

            if (isPolidrom(str, i, j))
                return 0;

            int uMinCut = int.MaxValue;
            int left = 0, right = 0;
            for (int k = i; k <= j - 1; k++)
            {
                if (cache[i, k] != -1)
                    left = cache[i, k];
                else
                {
                    left = GetPalindromePartitioningCount(str, i, k);
                    cache[i, k] = left;
                }

                if (cache[k + 1, j] != -1)
                    right = cache[k + 1, j];
                else
                {
                    right = GetPalindromePartitioningCount(str, k + 1, j);
                    cache[k + 1, j] = right;
                }
                int cutCounts = 1 + left + right;
                uMinCut = Math.Min(uMinCut, cutCounts);
                cache[i, j] = uMinCut;
            }
            return cache[i, j];
        }

        private int GetPalindromePartitioningCount(string str, int i, int j)
        {
            if (i >= j) return 0;
            if (isPolidrom(str, i, j))
                return 0;

            int uMinCut = int.MaxValue;
            for (int k = i; k <= j - 1; k++)
            {
                int cutCounts = 1 + GetPalindromePartitioningCount(str, i, k) + GetPalindromePartitioningCount(str, k + 1, j);
                uMinCut = Math.Min(uMinCut, cutCounts);
            }
            return uMinCut;
        }

        private bool isPolidrom(string str, int i, int j)
        {
            while (i < j)
            {
                if (str[i] != str[j]) return false;
                i++;
                j--;
            }
            return true;
        }

        private void MatrixChainMultiplication()
        {

            int[] arr = { 40, 20, 30, 10, 30 };
            int n = arr.Length;
            int minProfit = GetMCMMinMax(arr, 1, arr.Length - 1);
            Console.WriteLine("MinProfit :" + minProfit);

            int[,] cache = new int[n, n];
            Common.FillMatrixWithNegative(cache);
            minProfit = GetMCMMinMaxTopDown(arr, 1, arr.Length - 1, cache);
            Console.WriteLine("MinProfit :" + minProfit);


            arr = new int[] { 1, 2, 3, 4, 3 };
            minProfit = GetMCMMinMax(arr, 1, arr.Length - 1);
            Console.WriteLine("MinProfit :" + minProfit);
            n = arr.Length;
            cache = new int[n, n];
            Common.FillMatrixWithNegative(cache);
            minProfit = GetMCMMinMaxTopDown(arr, 1, arr.Length - 1, cache);
            Console.WriteLine("MinProfit :" + minProfit);

        }

        private int GetMCMMinMaxTopDown(int[] arr, int i, int j, int[,] cache)
        {
            if (i >= j) return 0;
            if (cache[i, j] != -1)
            {
                return cache[i, j];
            }
            int result = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                int profit = arr[i - 1] * arr[k] * arr[j] + GetMCMMinMaxTopDown(arr, i, k, cache) + GetMCMMinMaxTopDown(arr, k + 1, j, cache);
                result = Math.Min(result, profit);
                cache[i, j] = result;
            }
            Common.PrintMatrix(cache);
            return cache[i, j];
        }

        private int GetMCMMinMax(int[] arr, int i, int j)
        {
            if (i >= j) return 0;
            int result = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                int profit = arr[i - 1] * arr[k] * arr[j] + GetMCMMinMax(arr, i, k) + GetMCMMinMax(arr, k + 1, j);
                result = Math.Min(result, profit);
            }
            return result;
        }
    }
}
