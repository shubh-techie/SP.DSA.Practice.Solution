using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques973KClosestPointsOrigin
    {
        public static void Demo()
        {
            int[][] points = new int[3][];
            points[0] = new int[] { 3, 3 };
            points[1] = new int[] { 5, -1 };
            points[2] = new int[] { -2, 4 };
            List<int[]> result = KClosest(points, 2).ToList();


        }

        public static int[][] KClosest(int[][] points, int K)
        {
            int N = points.Length;
            int[] dists = new int[N];
            for (int i = 0; i < N; ++i)
                dists[i] = GetDistance(points[i]);

            Array.Sort(dists);
            int distK = dists[K - 1];

            int[][] ans = new int[K][];
            int t = 0;
            for (int i = 0; i < N; ++i)
                if (GetDistance(points[i]) <= distK)
                    ans[t++] = points[i];
            return ans;
        }

        public static int GetDistance(int[] point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }

    }
}
