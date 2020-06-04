using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.ArrayDemo
{
    public class Ques239SlidingWindowMaximum
    {
        public static void MaxSlidingWindowDemo()
        {
            int[] nums = { 4, 3, 2, 1 };
            int k = 1;
            int[] output = MaxSlidingWindow(nums, k);
            Console.WriteLine(string.Join(",", output));
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            int size = nums.Length;
            int[] output = new int[nums.Length - k + 1];
            int i = 0;
            Queue<int> track = new Queue<int>();

            for (i = 0; i < k; i++)
            {
                track.Enqueue(nums[i]);
            }

            output[0] = track.Max();

            for (i = k; i < size; i++)
            {
                track.Dequeue();
                track.Enqueue(nums[i]);
                output[i - k + 1] = track.Max();
            }

            return output;
        }
    }
}
