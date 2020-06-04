using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.String
{
    class Program
    {
        static void Main(string[] args)
        {

            NaiveSolutionPatternChange.NaiveSolutionPatternChangeDemo();



            //string reversedString = SwappingOfString("geeks for geeks");
            //Console.WriteLine("reversedString  :" + reversedString);

            Console.WriteLine("Press <enter> to exit.");
            Console.ReadLine();
        }

        private static string SwappingOfString(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            int low = 0, right = str.Length - 1;
            char[] arr = str.ToCharArray();
            while (low < right)
            {
                var item = arr[low];
                arr[low] = arr[right];
                arr[right] = item;
                low++;
                right--;
            }

            return new string(arr);
        }
    }
}
