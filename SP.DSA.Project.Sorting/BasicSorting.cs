using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Sorting
{
    public class BasicSorting
    {
        public static void BasicSortingDemo()
        {
            ArraySorting();
        }

        private static void ArraySorting()
        {
            int[] arr = { 2, 3, 1, 5, 9878, 2242, 323, 1, 1234, 32432 };
            Array.Sort(arr, (x, y) => y - x);
            Console.WriteLine(string.Join(",", arr));
        }

        
    }
}
