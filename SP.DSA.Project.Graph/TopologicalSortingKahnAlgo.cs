using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class TopologicalSortingKahnAlgo
    {
        public static void TopologicalSortingKahnAlgoDemo()
        {
            MyGraph graphObj = new MyGraph(6);
            graphObj.AddEdges(5, 2);
            graphObj.AddEdges(5, 0);
            graphObj.AddEdges(4, 0);
            graphObj.AddEdges(4, 1);
            graphObj.AddEdges(2, 3);
            graphObj.AddEdges(3, 1);

            TopologicalSortingKahnAlgoStart(graphObj);
            TopologicalSortDFS(graphObj);
        }

        private static void TopologicalSortDFS(MyGraph graphObj)
        {
            Stack<int> topOrder = new Stack<int>();
            HashSet<int> visitedSet = new HashSet<int>();
            for (int i = 0; i < graphObj.Vertix_Count; i++)
            {
                if (!visitedSet.Contains(i))
                {
                    DFSHelper(graphObj.AdjacencyList, i, topOrder, visitedSet);
                }
            }
            // here is top order.
            Console.WriteLine(string.Join(", ", topOrder));
        }

        private static void DFSHelper(List<List<int>> adjacencyList, int Source, Stack<int> topOrder, HashSet<int> visitedSet)
        {
            visitedSet.Add(Source);
            foreach (var nVertex in adjacencyList[Source])
            {
                if (!visitedSet.Contains(nVertex))
                {
                    DFSHelper(adjacencyList, nVertex, topOrder, visitedSet);
                }
            }
            topOrder.Push(Source);
        }

        private static void TopologicalSortingKahnAlgoStart(MyGraph graphObj)
        {
            List<List<int>> adjList = graphObj.AdjacencyList;
            int[] degree = new int[graphObj.Vertix_Count];
            for (int i = 0; i < adjList.Count; i++)
            {
                foreach (var item in adjList[i])
                {
                    degree[item]++;
                }
            }
            Console.WriteLine(string.Join(", ", degree));
            Console.WriteLine();
            Queue<int> queue = new Queue<int>();
            List<int> topOrder = new List<int>();
            for (int i = 0; i < graphObj.Vertix_Count; i++)
            {
                if (degree[i] == 0)
                    queue.Enqueue(i);
            }

            int nodeCounter = 0;
            while (queue.Count > 0)
            {
                int pVertex = queue.Dequeue();
                //Console.Write(pVertex + "->");
                topOrder.Add(pVertex);

                foreach (var nVertex in adjList[pVertex])
                {
                    degree[nVertex]--;
                    if (degree[nVertex] == 0)
                        queue.Enqueue(nVertex);
                }
                nodeCounter++;
            }

            if (nodeCounter != graphObj.Vertix_Count)
            {
                Console.WriteLine("There is cycle in this graph.");
            }

            Console.WriteLine("TopologicalSortingKahnAlgoStart :");
            Console.WriteLine(string.Join(", ", topOrder));

        }
    }
}
