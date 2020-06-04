using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class MergeTwoSortedLists
    {
        public static void MergerTwoSortedListDemo()
        {
            List<int> A = new List<int>() { 1, 5, 8, 0, 0 };
            List<int> B = new List<int>() { 6, 9 };
            merge(A, B);
            Console.WriteLine(string.Join(",", A));

        }

        public static void merge(List<int> A, List<int> B)
        {
            int k = A.Count - 1;
            int j = B.Count - 1;
            int i = (A.Count - B.Count) - 1;

            while (i >= 0 && j >= 0)
            {
                if (A[i] >= B[j])
                {
                    A[k] = A[i];
                    i--;
                }
                else
                {
                    A[k] = B[j];
                    j--;
                }
                k--;
            }

            while (j >= 0)
            {
                A[k] = B[j];
                j--; k--;
            }

        }

    }
}
