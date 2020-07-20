using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class NoOfIsLand
    {
        public static void GetNoOfIsLandStart()
        {
            List<List<int>> adj = new List<List<int>>();
            adj.Add(new List<int>() { 1, 1, 0 });
            adj.Add(new List<int>() { 0, 0, 1 });
            adj.Add(new List<int>() { 1, 0, 1 });
            //adj.Add(new List<int>() { 1, 1, 0, 0 });
            //adj.Add(new List<int>() { 0, 0, 1, 0 });
            //adj.Add(new List<int>() { 0, 0, 0, 1 });
            //adj.Add(new List<int>() { 0, 1, 0, 0 });
            int nos = GetNoOfIsLand(adj);
            Console.WriteLine("nos :" + nos);
        }

        public static int GetNoOfIsLand(List<List<int>> adj)
        {
            int rows = adj.Count;
            int count = 0;
            int cols = adj[0].Count;
            //bool[,] visisted = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (adj[i][j] == 1)//&& visisted[i, j] != true)
                    {
                        Console.WriteLine("{0} , {1}", i, j);
                        GetNoOfIsLandHelper(adj, i, j, rows, cols);//, visisted);
                        count += 1;
                    }
                    PrintGraph(adj);
                }
                Console.WriteLine();
            }

            return count;
        }

        public static void PrintGraph(List<List<int>> adj)
        {
            for (int i = 0; i < adj.Count; i++)
            {
                List<int> nodes = adj[i];
                for (int j = 0; j < nodes.Count; j++)
                {
                    Console.Write(nodes[j] + "  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void GetNoOfIsLandHelper(List<List<int>> adj, int i, int j, int rows, int cols)//, bool[,] visisted)
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols || adj[i][j] != 1)// || visisted[i, j] == true)
                return;
            adj[i][j] = 2;

            int[] rN0 = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] cNo = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int k = 0; k < 8; k++)
            {
                GetNoOfIsLandHelper(adj, i + rN0[k], j + cNo[k], rows, cols);//, visisted);
            }
        }
    }
}
