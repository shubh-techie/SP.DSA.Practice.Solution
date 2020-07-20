using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class GraphDemo
    {
        public static void GraphDemoStart()
        {
            MyGraph graphObj = new MyGraph(5);
            graphObj.AddEdges(0, 1);
            graphObj.AddEdges(0, 2);
            graphObj.AddEdges(0, 3);
            graphObj.AddEdges(2, 4);
            //graphObj.AddEdges(2, 0);
            //graphObj.AddEdges(2, 3);
            //graphObj.AddEdges(3, 3);

            graphObj.PrintGraph();

            PrintGraphAdj(graphObj.AdjacencyList, graphObj.Vertix_Count);
            Console.WriteLine("Printing DFS");
            DGSRec(graphObj);
            //Console.WriteLine();
            //graphObj.BFS(2);
            //graphObj.DFS(2);
            //graphObj.DFSReCursion(2);

            //Console.WriteLine();
            //Console.WriteLine();
            //graphObj.PrintGraphDemo(graphObj.AdjacencyList, graphObj.Vertix_Count);

            //List<int> output = graphObj.BFSDemo(graphObj.AdjacencyList, graphObj.Vertix_Count);
            //Console.WriteLine();
            //Console.WriteLine("DFS...");
            //List<int> outDFS = graphObj.DFSDemo(graphObj.AdjacencyList, graphObj.Vertix_Count);
            //Console.WriteLine(string.Join(",", outDFS));
        }

        private static void DGSRec(MyGraph graphObj)
        {
            if (graphObj == null) return;
            HashSet<int> vSet = new HashSet<int>();
            List<int> allNodes = new List<int>();
            DFSHelper(graphObj.AdjacencyList, 0, vSet, allNodes);
        }

        private static void DFSHelper(List<List<int>> adjacencyList, int parent, HashSet<int> vSet, List<int> allNodes)
        {
            vSet.Add(parent);
            allNodes.Add(parent);
            foreach (var neighbour in adjacencyList[parent])
            {
                if (!vSet.Contains(neighbour))
                {
                    DFSHelper(adjacencyList, neighbour, vSet, allNodes);
                }
            }
        }

        private static void PrintGraphAdj(List<List<int>> adjacencyList, int vertix_Count)
        {
            Console.WriteLine();
            for (int i = 0; i < vertix_Count; i++)
            {
                Console.Write(i);
                foreach (var item in adjacencyList[i])
                {
                    Console.Write("=>" + item);
                }
                Console.WriteLine();
            }
        }
    }

    public class MyGraph
    {
        public int Vertix_Count { get; set; }
        public List<List<int>> AdjacencyList;
        public MyGraph(int v)
        {
            this.Vertix_Count = v;
            AdjacencyList = new List<List<int>>();
            for (int i = 0; i < Vertix_Count; i++)
            {
                AdjacencyList.Add(new List<int>());
            }
        }

        public void AddEdges(int vNo, int vNode)
        {
            AdjacencyList[vNo].Add(vNode);
            //AdjacencyList[vNode].Add(vNo);
        }

        public void AddEdgesUnDirected(int vNo, int vNode)
        {
            AdjacencyList[vNo].Add(vNode);
            AdjacencyList[vNode].Add(vNo);
        }

        public List<int> DFSDemo(List<List<int>> adjacencyList, int vertix_Count)
        {
            List<int> result = new List<int>();
            bool[] visisted = new bool[vertix_Count];
            DFSDemoHelper(adjacencyList, 2, vertix_Count, result, visisted);
            return result;
        }

        private void DFSDemoHelper(List<List<int>> adjacencyList, int nVertex, int vertix_Count, List<int> result, bool[] visisted)
        {
            visisted[nVertex] = true;
            result.Add(nVertex);
            List<int> nNodes = adjacencyList[nVertex];
            for (int i = 0; i < nNodes.Count; i++)
            {
                if (visisted[nNodes[i]] == false)
                {
                    DFSDemoHelper(adjacencyList, nNodes[i], vertix_Count, result, visisted);
                }
            }
        }

        public List<int> BFSDemo(List<List<int>> adjacencyList, int vertix_Count)
        {
            List<int> allnodes = new List<int>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visisted = new HashSet<int>();

            queue.Enqueue(0);
            visisted.Add(0);

            while (queue.Count > 0)
            {
                int nVertex = queue.Dequeue();
                allnodes.Add(nVertex);

                List<int> allEdges = adjacencyList[nVertex];
                for (int i = 0; i < allEdges.Count; i++)
                {
                    if (!visisted.Contains(allEdges[i]))
                    {
                        queue.Enqueue(allEdges[i]);
                        visisted.Add(allEdges[i]);
                    }
                }
            }

            return allnodes;
        }

        public void PrintGraph()
        {
            List<List<int>> adj = this.AdjacencyList;
            for (int i = 0; i < adj.Count; i++)
            {
                List<int> nodes = this.AdjacencyList[i];
                Console.Write(i + " ");
                for (int j = 0; j < nodes.Count; j++)
                {
                    Console.Write("->" + nodes[j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// sVertix is the start node.
        /// </summary>
        /// <param name="sVertex"></param>
        public void BFS(int sVertex)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(sVertex);
            visited.Add(sVertex);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                List<int> allAdj = this.AdjacencyList[vertex];
                for (int i = 0; i < allAdj.Count; i++)
                {
                    if (!visited.Contains(allAdj[i]))
                    {
                        visited.Add(allAdj[i]);
                        queue.Enqueue(allAdj[i]);
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// sVertix is the start node.
        /// </summary>
        /// <param name="sVertex"></param>
        public void DFS(int sVertex)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> queue = new Stack<int>();
            queue.Push(sVertex);
            visited.Add(sVertex);

            while (queue.Count > 0)
            {
                int vertex = queue.Pop();
                Console.Write(vertex + " ");

                List<int> allAdj = this.AdjacencyList[vertex];
                for (int i = 0; i < allAdj.Count; i++)
                {
                    if (!visited.Contains(allAdj[i]))
                    {
                        visited.Add(allAdj[i]);
                        queue.Push(allAdj[i]);
                    }
                }
            }
            Console.WriteLine();
        }

        public void DFSReCursion(int sVertex)
        {
            HashSet<int> visited = new HashSet<int>();
            DFSHelper(sVertex, visited);
        }

        private void DFSHelper(int sVertex, HashSet<int> visited)
        {
            visited.Add(sVertex);
            Console.Write(sVertex + " ");

            List<int> allAdj = this.AdjacencyList[sVertex];
            for (int i = 0; i < allAdj.Count; i++)
            {
                if (!visited.Contains(allAdj[i]))
                {
                    DFSHelper(allAdj[i], visited);
                }
            }
        }

        public void PrintGraphDemo(List<List<int>> list, int v)
        {
            int size = list.Count;
            for (int i = 0; i < size; i++)
            {
                Console.Write(i);
                List<int> nodes = list[i];
                for (int j = 0; j < nodes.Count; j++)
                {
                    Console.Write("->" + nodes[j]);
                }
                Console.WriteLine();
            }
        }


    }
}
