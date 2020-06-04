using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques202HappyNumber
    {
        public static void Ques202HappyNumberDemo()
        {
            Console.WriteLine(IsHappy(2));
        }

        public static bool IsHappy(int n)
        {
            HashSet<int> track = new HashSet<int>();
            while (n != 0 && !track.Contains(n))
            {
                track.Add(n);
                n = GetNext(n);
            }
            return n == 1;
        }

        private static int GetNext(int n)
        {
            int square = 0;
            int temp = n;
            while (n > 0)
            {
                square += (int)Math.Pow(n % 10, 2);
                n = n / 10;
            }
            Console.WriteLine($"{temp} , next {square}");
            return square;
        }
    }
}
