using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques204CountPrimes
    {
        public static void Ques204CountPrimesDemo()
        {
            Console.WriteLine("Total no of Prime : " + CountPrimes(10));
        }
        public static int CountPrimes(int n)
        {
            if (n < 1) return 0;

            bool[] noPrime = new bool[n];
            noPrime[0] = true;
            noPrime[1] = true;

            for (int i = 0; i <n; i++)
            {
                if (noPrime[i] == false)
                {
                    for (int j = 2; j * i < n; j++)
                    {
                        noPrime[j * i] = true;
                    }
                }
            }
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (noPrime[i] == false) count++;
            }
            return count;
        }

        private static bool isPrime(int n)
        {
            if (n <= 2) return false;
            int no = n;
            for (int i = 2; i * i <= n; i++)
            {
                if (no % i == 0)
                    return false;
            }

            return true;
        }
    }
}
