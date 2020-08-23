using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques675CutOffTreesforGolfEvent
    {
        public static void Ques675CutOffTreesforGolfEventDemo()
        {
            IList<IList<int>> forest = new List<IList<int>>();
            forest.Add(new List<int>() { 1, 2, 3 });
            forest.Add(new List<int>() { 0, 0, 4 });
            forest.Add(new List<int>() { 7, 6, 5 });

            Console.WriteLine(CutOffTree(forest));
        }

        private static int CutOffTree(IList<IList<int>> forest)
        {
            int[][] dirs = new[] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
            List<int[]> TreeInfo = new List<int[]>();
            int rows = forest.Count, cols = forest[0].Count;
            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[i].Count; j++)
                {
                    if (forest[i][j] > 1)
                        TreeInfo.Add(new int[] { forest[i][j], i, j });
                }
            }
            TreeInfo.Sort((a, b) => a[0] - b[0]);
            int result = 0, x = 0, y = 0;
            foreach (var tree in TreeInfo)
            {
                int tx = tree[1], ty = tree[2];
                int path = FindCutOff(forest, x, y, tx, ty, rows, cols, dirs);
                if (path < 0)
                    return -1;
                result += path;
                forest[tx][ty] = 1;
                x = tx; y = ty;
            }
            return result;
        }

        private static int FindCutOff(IList<IList<int>> forest, int sr, int sc, int tx, int ty, int rows, int cols, int[][] dirs)
        {
            bool[,] seen = new bool[rows, cols];
            Queue<Cordinate> treeQueue = new Queue<Cordinate>();
            treeQueue.Enqueue(new Cordinate(sr, sc));
            int step = 0;
            while (treeQueue.Count > 0)
            {
                step++;
                int qsize = treeQueue.Count;
                for (int i = 0; i < qsize; i++)
                {
                    Cordinate cor = treeQueue.Dequeue();
                    int x = cor.x;
                    int y = cor.y;

                    foreach (var dir in dirs)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];
                        if (x == newX && y == newY) return step;
                        if (newX >= 0 && newY >= 0 && newX < rows && newY < cols && forest[newX][newY] > 1 && seen[newX, newY] == false)
                        {
                            seen[newX, newY] = true;
                            treeQueue.Enqueue(new Cordinate(newX, newY));
                        }
                    }
                }
            }
            return -1;
        }
    }
}
