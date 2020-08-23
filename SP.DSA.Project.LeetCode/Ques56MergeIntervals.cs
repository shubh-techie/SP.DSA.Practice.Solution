using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Merge
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Merge(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }

    public class SortByEnd : IComparer<Merge>
    {
        public int Compare(Merge x, Merge y)
        {
            return x.End - y.End;
        }
    }

    public class Ques56MergeIntervals
    {
        public static void Ques56MergeIntervalsDemo()
        {
            int[][] intervals = new int[4][];
            intervals[0] = new int[] { 1, 3 };
            intervals[1] = new int[] { 2, 6 };
            intervals[2] = new int[] { 8, 10 };
            intervals[3] = new int[] { 15, 18 };
            List<int[]> result = Merge(intervals).ToList();

            Console.WriteLine("Post solution.");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        public static int[][] Merge(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            if (intervals == null || intervals.Length == 0) return result.ToArray();

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            int start = intervals[0][0];
            int end = intervals[0][1];

            foreach (var item in intervals)
            {
                if (item[0] <= end)
                {
                    end = Math.Max(end, item[1]);
                }
                else
                {
                    result.Add(new int[] { start, end });
                    start = item[0];
                    end = item[1];
                }
            }

            result.Add(new int[] { start, end });

            return result.ToArray();
        }
    }
}
