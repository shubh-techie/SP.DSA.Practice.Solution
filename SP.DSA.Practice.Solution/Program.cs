using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Practice.Solution
{
    class Program
    {
        static void Main(string[] args)
        {

            FindKthLargestDemo();
            //ProductOfSelf();
            //GroupAnagramDemo();
            //GetIndexOFDemo();

            Console.ReadLine();
            Console.WriteLine("Press <enter> to exit.");
        }

        private static void FindKthLargestDemo()
        {
            int[] nums = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            Console.WriteLine(FindKthLargest(nums, k));
        }

        public static int FindKthLargest(int[] nums, int k)
        {

            int left = 0, right = nums.Length - 1, index = nums.Length - k;
            while (left <= right)
            {
                int pivot = GetLomutoPartition(nums, left, right);

                if (pivot == index)
                    return k;
                else if (index > pivot)
                    right = pivot + 1;
                else
                    left = pivot - 1;

            }
            return -1;
        }

        public static int GetLomutoPartition(int[] arr, int left, int right)
        {
            int pNumber = arr[right], pIndex = left - 1;

            for (int i = left; i <= right; i++)
            {
                if (arr[i] <= pNumber)
                {
                    pIndex++;
                    int temp = arr[pIndex];
                    arr[pIndex] = arr[i];
                    arr[i] = temp;
                }
            }

            return pIndex;
        }
        private static void ProductOfSelf()
        {
            int[] nums = { 1, 2, 3, 4 };
            Console.WriteLine(String.Join(" ", productExceptSelf(nums)));
        }

        public static int[] productExceptSelf(int[] nums)
        {
            int length = nums.Length;
            int[] answer = new int[length];
            answer[0] = 1;
            for (int i = 1; i < length; i++)
            {
                answer[i] = nums[i - 1] * answer[i - 1];
            }
            Console.WriteLine(String.Join(" ", answer));
            int R = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                Console.WriteLine(String.Join(" ", answer));
                Console.WriteLine("R: {0}", R);
                answer[i] = answer[i] * R;
                R *= nums[i];
            }
            return answer;
        }

        private static void GroupAnagramDemo()
        {
            string[] strs = { "aaa", "aaa", "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> result = GroupAnagrams(strs);
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            if (strs.Length == 0) return result;

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (var ana in strs)
            {
                char[] key = new char[26];
                foreach (var ch in ana)
                {
                    key[ch - 'a']++;
                }
                string strKey = new string(key);
                if (!map.ContainsKey(strKey))
                    map.Add(strKey, new List<string>());

                map[strKey].Add(ana);
            }

            foreach (var val in map.Values)
            {
                result.Add(val);
            }

            return result;
        }

        private static void GetIndexOFDemo()
        {
            string str = "mississippi";
            string pattern = "mississippi";

            str = "a";
            pattern = "a";
            Console.WriteLine("index is :" + indexOf(str, pattern));
        }

        public static int indexOf(string Text, string pattern)
        {
            int sLen = Text.Length, pLen = pattern.Length;
            if (pLen == 0)
                return 0;
            if (pLen > sLen)
                return -1;

            for (int i = 0; i <= sLen - pLen; i++)
            {
                int j = 0;
                while (j < pLen && i < sLen)
                {
                    if (Text[i + j] != pattern[j])
                        break;
                    j++;
                }

                if (j == pLen)
                    return i;
            }
            return -1;
        }
    }
}
