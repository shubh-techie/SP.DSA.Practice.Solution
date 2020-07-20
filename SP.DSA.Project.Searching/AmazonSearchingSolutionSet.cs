using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Searching
{
    public class AmazonSearchingSolutionSet
    {
        public static void AmazonSearchingSolutionSetStart()
        {
            //SquareRoot();
            //MajorityElement();
            FindTransitionPoint();
        }

        private static void FindTransitionPoint()
        {
            int[] arr = { 0, 0, 0, 0, 0, 1 };
            int point = GetTPoint(arr, arr.Length);
            Console.WriteLine("Point :" + point);
        }

        private static int GetTPoint(int[] arr, int n)
        {
            if (n < 2)
                return -1;
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == 0)
                {
                    left = mid + 1;
                }

                if (arr[mid] == 1)
                {
                    if (mid != 0 && arr[mid - 1] == 0)
                    {
                        return mid;
                    }
                    right = mid - 1;
                }
            }

            return -1;
        }

        private static void MajorityElement()
        {
            int[] arr = { 3, 1, 3, 3, 2 };
            int major = GetMajorElement(arr, arr.Length);
            Console.WriteLine("major :" + major);
        }

        private static int GetMajorElement(int[] arr, int n)
        {
            if (n == 0) return -1;
            if (n == 1) return arr[0];

            int count = 1, major = arr[0];

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == major)
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    count = 1;
                    major = arr[i];
                }
            }
            count = 0;

            for (int i = 0; i < n; i++)
            {
                if (major == arr[i])
                {
                    count++;
                    if (count > n / 2)
                    {
                        return major;
                    }
                }
            }

            return -1;
        }

        private static void SquareRoot()
        {
            int no = 8;
            int sq = GetSqureRoot(no);
            Console.WriteLine("Square root :{0} ", sq);
        }

        private static int GetSqureRoot(int no)
        {
            if (no == 0 || no == 1) return no;

            int left = 1, right = no, result = -1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                int square = mid * mid;
                if (square == no)
                {
                    return mid;
                }
                if (square < no)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
