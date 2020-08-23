using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class DeductCycleInGraph
    {
        public static void DeductCycleInGraphDemo()
        {
            MyGraph graph = new MyGraph(6);
            graph.AddEdgesUnDirected(0, 1);
            graph.AddEdgesUnDirected(1, 2);
            //graph.AddEdgesUnDirected(1, 3);
            //graph.AddEdgesUnDirected(2, 3);
            graph.AddEdgesUnDirected(2, 4);
            graph.AddEdgesUnDirected(4, 5);

            graph.PrintGraph();
            Console.WriteLine();
            bool output = HasInCycleGraph(graph.AdjacencyList, graph.Vertix_Count);
            Console.WriteLine("cycle found :" + output);
        }

        private static bool HasInCycleGraph(List<List<int>> adjacencyList, int vertix_Count)
        {
            if (adjacencyList.Count == 0) return false;
            HashSet<int> visitedSet = new HashSet<int>();
            for (int i = 0; i < vertix_Count; i++)
            {
                Console.Write("Parent :{0}", i);
                if (!visitedSet.Contains(i))
                {
                    if (HasInCycleGraphHelper(adjacencyList, i, visitedSet, -1))
                    {
                        return true;
                    }
                }
                Console.WriteLine();
            }
            return false;
        }

        private static bool HasInCycleGraphHelper(List<List<int>> adjacencyList, int source, HashSet<int> visitedSet, int parent)
        {
            if (visitedSet.Contains(source))
                return false;

            if (source != parent)
                return true;

            visitedSet.Add(source);
            foreach (var neigh in adjacencyList[source])
            {
                if (HasInCycleGraphHelper(adjacencyList, neigh, visitedSet, source))
                {
                    return true;
                }
            }
            return false;
        }



        //private static bool IsDeductCycleInGraph(List<List<int>> adjacencyList, int vertix_Count)
        //{
        //    HashSet<int> visited = new HashSet<int>();
        //    for (int i = 0; i < vertix_Count; i++)
        //    {
        //        if (!visited.Contains(i) && DFSHelper(adjacencyList, i, visited, -1))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private static bool DFSHelper(List<List<int>> adjacencyList, int source, HashSet<int> visited, int parent)
        //{
        //    visited.Add(source);
        //    List<int> edges = adjacencyList[source];
        //    for (int i = 0; i < edges.Count; i++)
        //    {
        //        if (!visited.Contains(edges[i]))
        //        {
        //            if (DFSHelper(adjacencyList, edges[i], visited, source))
        //                return true;
        //        }
        //        else if (edges[i] != parent)
        //            return true;
        //    }
        //    return false;
        //}
    }
}
