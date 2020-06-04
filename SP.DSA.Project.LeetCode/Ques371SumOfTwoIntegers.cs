using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques371SumOfTwoIntegers
    {
        public static void Ques371SumOfTwoIntegersDemo()
        {
            Console.WriteLine(GetSum(2, 2));
        }
        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int carry = a & b;
                Console.WriteLine(carry);
                a = a ^ b;
                Console.WriteLine(a);
                b = carry << 1;
                Console.WriteLine(b);
            }
            return a;
        }
    }
}
