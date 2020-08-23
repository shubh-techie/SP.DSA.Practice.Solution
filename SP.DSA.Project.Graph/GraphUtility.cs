using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class GraphUtility
    {
        public static List<List<int>> GetCriticalConnection(GNode graph)
        {
            HashSet<List<int>> criticalEdges = new HashSet<List<int>>();
            HashSet<int> visited = new HashSet<int>();
            int[] parent = new int[graph.vCount];
            int[] lowTime = new int[graph.vCount];
            int[] discoveryTime = new int[graph.vCount];

            for (int i = 0; i < graph.vCount; i++)
            {
                parent[i] = -1;
            }

            int time = 0;
            for (int i = 1; i < graph.vCount; i++)
            {
                if (!visited.Contains(i))
                {
                    GetCriticalConnectionHelper(i, graph.AdjacencyList, parent, visited, lowTime, discoveryTime, criticalEdges, ref time);
                }
            }
            return criticalEdges.ToList();
        }

        private static void GetCriticalConnectionHelper(int vertix, List<List<int>> adjacencyList, int[] parent, HashSet<int> visited, int[] lowTime, int[] discoveryTime, HashSet<List<int>> criticalEdges, ref int time)
        {
            visited.Add(vertix);
            lowTime[vertix] = discoveryTime[vertix] = ++time;
            int children = 0;
            foreach (var neighbour in adjacencyList[vertix])
            {
                if (!visited.Contains(neighbour))
                {
                    children++;
                    parent[neighbour] = vertix;
                    GetCriticalConnectionHelper(neighbour, adjacencyList, parent, visited, lowTime, discoveryTime, criticalEdges, ref time);

                    lowTime[vertix] = Math.Min(lowTime[neighbour], lowTime[vertix]);
                    //there are two condition to check the articulation points.
                    //1. (1) u is root of DFS tree and has two or more chilren. 
                    if (parent[vertix] == -1 && children >= 1 && lowTime[neighbour] > discoveryTime[vertix])
                    {
                        List<int> temp = new List<int>() { vertix, neighbour };
                        temp.Sort();
                        criticalEdges.Add(temp);
                    }

                    // (2) If u is not root and low value of one of its child 
                    // is more than discovery value of u. u[lowValue] > v[discovery] 
                    if (parent[vertix] != -1 && lowTime[neighbour] > discoveryTime[vertix])
                    {
                        List<int> temp = new List<int>() { vertix, neighbour };
                        temp.Sort();
                        criticalEdges.Add(temp);
                    }

                }
                // update the low value of u for the parent function calls
                else if (neighbour != parent[vertix])
                {
                    lowTime[vertix] = Math.Min(lowTime[vertix], discoveryTime[neighbour]);
                }
            }
        }

        public static List<int> GetArticulationPoints(GNode graph)
        {
            HashSet<int> ap = new HashSet<int>();
            bool[] visited = new bool[graph.vCount];
            int[] parent = new int[graph.vCount];
            int[] discoveryTime = new int[graph.vCount];
            int[] LowTime = new int[graph.vCount];
            int time = 0;
            for (int i = 0; i < graph.vCount; i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            for (int i = 0; i < graph.vCount; i++)
            {
                if (visited[i] == false)
                {
                    GetArticulationPointsHelper(graph.AdjacencyList, i, visited, discoveryTime, LowTime, parent, ap, ref time);
                }
            }
            return ap.ToList();
        }

        private static void GetArticulationPointsHelper(List<List<int>> adjacencyList, int vertix, bool[] visited, int[] discoveryTime, int[] lowTime, int[] parent, HashSet<int> ap, ref int time)
        {
            visited[vertix] = true;
            int children = 0;

            discoveryTime[vertix] = lowTime[vertix] = ++time;
            foreach (var neigh in adjacencyList[vertix])
            {
                if (!visited[neigh])
                {
                    children++;
                    parent[neigh] = vertix;
                    GetArticulationPointsHelper(adjacencyList, neigh, visited, discoveryTime, lowTime, parent, ap, ref time);

                    lowTime[vertix] = Math.Min(lowTime[neigh], lowTime[vertix]);
                    //there are two condition to check the articulation points.
                    //1. (1) u is root of DFS tree and has two or more chilren. 
                    if (parent[vertix] == -1 && children > 1)
                        ap.Add(vertix);

                    // (2) If u is not root and low value of one of its child 
                    // is more than discovery value of u. u[lowValue] > v[discovery] 
                    if (parent[vertix] != -1 && lowTime[neigh] >= discoveryTime[vertix])
                        ap.Add(vertix);
                }
                // update the low value of u for the parent function calls
                else if (neigh != parent[vertix])
                {
                    lowTime[vertix] = Math.Min(lowTime[vertix], discoveryTime[neigh]);
                }
            }
        }

        public List<int> DFSTopologySort(GNode graph)
        {
            Stack<int> topOrder = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < graph.vCount; i++)
            {
                if (!visited.Contains(i))
                    DFSTopologySortHelper(graph.AdjacencyList, visited, i, topOrder);
            }
            return topOrder.ToList();
        }

        private void DFSTopologySortHelper(List<List<int>> adjacencyList, HashSet<int> visited, int vertix, Stack<int> topOrder)
        {
            visited.Add(vertix);
            foreach (var neigh in adjacencyList[vertix])
            {
                if (visited.Contains(neigh))
                    DFSTopologySortHelper(adjacencyList, visited, neigh, topOrder);
            }
            topOrder.Push(vertix);
        }

        public List<int> GetTopologicalSort(GNode graph)
        {
            List<int> topSets = new List<int>();
            List<int> inDegree = new List<int>(graph.vCount);

            for (int i = 0; i < graph.vCount; i++)
            {
                foreach (var item in graph.AdjacencyList[i])
                {
                    if (item == i)
                        inDegree[i]++;
                }
            }
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < graph.vCount; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(inDegree[i]);
            }

            int nCount = 0;
            while (queue.Count > 0)
            {
                int verTix = queue.Dequeue();
                topSets.Add(verTix);

                foreach (int neigh in graph.AdjacencyList[verTix])
                {
                    if (inDegree[neigh]-- == 0)
                        queue.Enqueue(neigh);
                }
                nCount++;
            }

            if (nCount != graph.vCount)
                Console.WriteLine("There is cycle.");

            return topSets;
        }

        public bool HasCycleInDirectedGraph(GNode graph)
        {
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> trackPath = new HashSet<int>();

            for (int i = 0; i < graph.vCount; i++)
            {
                if (visited.Contains(i) && HasCycleDFS(graph.AdjacencyList, i, trackPath, visited))
                {
                    return true;
                }
                else if (trackPath.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasCycleDFS(List<List<int>> adjacencyList, int parent, HashSet<int> trackPath, HashSet<int> visited)
        {
            visited.Add(parent);
            trackPath.Add(parent);
            foreach (var neighbour in adjacencyList[parent])
            {
                if (!visited.Contains(neighbour) && HasCycleDFS(adjacencyList, neighbour, trackPath, visited))
                {
                    return true;
                }
                else if (trackPath.Contains(neighbour))
                {
                    return true;
                }
            }
            trackPath.Remove(parent);
            return false;
        }

        public bool HasCycle(GNode graph, int startVertix)
        {
            HashSet<int> visitedSet = new HashSet<int>();

            for (int i = 0; i < graph.vCount; i++)
            {
                if (!visitedSet.Contains(i))
                {
                    if (HasCycleHelper(graph.AdjacencyList, visitedSet, i, -1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasCycleHelper(List<List<int>> adjacencyList, HashSet<int> visitedSet, int vertix, int pVertix)
        {
            visitedSet.Add(vertix);

            foreach (var neigbour in adjacencyList[vertix])
            {
                if (!visitedSet.Contains(neigbour))
                {
                    if (HasCycleHelper(adjacencyList, visitedSet, neigbour, vertix))
                        return true;
                }
                else if (neigbour != pVertix)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<int> GetShortestPath(GNode graph, int startVertix)
        {
            List<int> paths = new List<int>();
            for (int i = 0; i < graph.vCount; i++)
            {
                paths.Add(0);
            }
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();


            queue.Enqueue(startVertix);
            visited.Add(startVertix);

            while (queue.Count > 0)
            {
                int cVertix = queue.Dequeue();

                foreach (var nVertix in graph.AdjacencyList[cVertix])
                {
                    if (!visited.Contains(nVertix))
                    {
                        paths[nVertix] = paths[cVertix] + 1;
                        visited.Add(nVertix);
                        queue.Enqueue(nVertix);
                    }
                }
            }
            return paths;
        }

        public static void BFS(List<List<int>> vertices, int vertixCount)
        {
            List<int> allnodes = new List<int>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            //Starting from 0
            queue.Enqueue(0);
            visited.Add(0);

            Console.WriteLine();
            while (queue.Count > 0)
            {
                int nVertix = queue.Dequeue();
                //store in nodes.
                Console.Write(nVertix + " ");
                List<int> neighbours = vertices[nVertix];
                foreach (var edge in neighbours)
                {
                    if (!visited.Contains(edge))
                    {
                        queue.Enqueue(edge);
                        visited.Add(edge);
                    }
                }
            }
            Console.WriteLine();
        }


        public static void DFS(List<List<int>> vertices, int vertixCount)
        {
            List<int> allnodes = new List<int>();
            Stack<int> stack = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();

            //Starting from 0
            stack.Push(0);
            visited.Add(0);

            Console.WriteLine();
            while (stack.Count > 0)
            {
                int nVertix = stack.Pop();

                //store in nodes.
                Console.Write(nVertix + " ");
                List<int> neighbours = vertices[nVertix];
                foreach (var edge in neighbours)
                {
                    if (!visited.Contains(edge))
                    {
                        stack.Push(edge);
                        visited.Add(edge);
                    }
                }
            }
            Console.WriteLine();
        }


        public static void DFSRecursion(List<List<int>> vertices, int vertixCount)
        {
            HashSet<int> visited = new HashSet<int>();
            Console.WriteLine("DFS Recursion startd.");
            DFSHelper(vertices, visited, vertixCount, 0);
            Console.WriteLine();
            Console.WriteLine("DFS Recursion end");
        }

        private static void DFSHelper(List<List<int>> vertices, HashSet<int> visited, int vertixCount, int sVertix)
        {
            visited.Add(sVertix);
            Console.Write(sVertix + " ");
            List<int> neighbours = vertices[sVertix];
            for (int i = 0; i < neighbours.Count; i++)
            {
                if (!visited.Contains(neighbours[i]))
                {
                    DFSHelper(vertices, visited, vertixCount, neighbours[i]);
                }
            }
        }
    }
}
