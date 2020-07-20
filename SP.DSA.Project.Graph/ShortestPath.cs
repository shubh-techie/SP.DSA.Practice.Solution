using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class ShortestPath
    {
        public static void ShortestPathDemo()
        {
            MyGraph graphObj = new MyGraph(4);
            graphObj.AddEdges(0, 1);
            graphObj.AddEdges(0, 2);
            graphObj.AddEdges(1, 2);
            graphObj.AddEdges(1, 3);
            graphObj.AddEdges(2, 3);

            List<int> shortPath = GetShortedPath(graphObj, 0);
            Console.WriteLine(string.Join(", ", shortPath));
        }

        private static List<int> GetShortedPath(MyGraph graphObj, int source)
        {
            List<int> path = new List<int>() { 0, 0, 0, 0 };
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            visited.Add(source);
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                int pVertex = queue.Dequeue();
                foreach (var nVertex in graphObj.AdjacencyList[pVertex])
                {
                    if (!visited.Contains(nVertex))
                    {
                        path[nVertex] = path[pVertex] + 1;
                        visited.Add(nVertex);
                        queue.Enqueue(nVertex);
                    }
                }
            }
            return path;
        }
    }
}
