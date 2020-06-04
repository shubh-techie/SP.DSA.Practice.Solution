using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class FindSquerRoot
    {
        public static void FindSquerRootDemo()
        {
            long x = 5;
            long sqRoot = floorSqrt(x);
            Console.WriteLine("Square root of {0} is {1}", x, sqRoot);
        }

        private static long floorSqrt(long x)
        {
            if (x == 0 || x == 1)
                return x;

            long lo = 1, hi = x, ans = 0;

            while (lo <= hi)
            {
                long mid = (lo + hi) / 2;

                if (mid * mid == x)
                {
                    return mid;
                }
                else if (x < mid * mid)
                {
                    hi = mid - 1;
                    ans = mid;
                }
                else
                {
                    lo = mid + 1;
                    ans = mid;
                }
            }

            return ans;
        }
    }
}
