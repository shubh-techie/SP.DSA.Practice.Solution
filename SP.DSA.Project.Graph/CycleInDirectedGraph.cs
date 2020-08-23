using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class CycleInDirectedGraph
    {
        public static void CycleInDirectedGraphStart()
        {
            MyGraph graph = new MyGraph(6);
            graph.AddEdges(0, 1);
            //graph.AddEdges(2, 1);
            //graph.AddEdges(2, 3);
            //graph.AddEdges(3, 4);
            //graph.AddEdges(4, 5);
            //graph.AddEdges(5, 3);

            graph.PrintGraph();

            bool output = HasCycleInGraph(graph.AdjacencyList, graph.Vertix_Count);
            Console.WriteLine("cycle found :" + output);
        }



        private static bool HasCycleInGraph(List<List<int>> adjacencyList, int vertix_Count)
        {
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> trackPath = new HashSet<int>();
            for (int i = 0; i < vertix_Count; i++)
            {
                if (!visited.Contains(i) && HasCycleInGraphHelper(adjacencyList, i, visited, trackPath))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasCycleInGraphHelper(List<List<int>> adjacencyList, int vertex, HashSet<int> visited, HashSet<int> trackPath)
        {
            if (trackPath.Contains(vertex))
                return true;
            if (visited.Contains(vertex))
                return false;

            visited.Add(vertex);
            trackPath.Add(vertex);
            foreach (var neigh in adjacencyList[vertex])
            {
                if (HasCycleInGraphHelper(adjacencyList, neigh, visited, trackPath))
                    return true;
            }

            trackPath.Remove(vertex);
            return false;
        }



        //private static bool IsDeductCycleInGraph(List<List<int>> adjacencyList, int vertix_Count)
        //{
        //    HashSet<int> visited = new HashSet<int>();
        //    HashSet<int> trackParent = new HashSet<int>();

        //    for (int i = 0; i < vertix_Count; i++)
        //    {
        //        if (DFSHelper(adjacencyList, i, visited, trackParent))
        //            return true;
        //    }
        //    return false;
        //}

        //private static bool DFSHelper(List<List<int>> adjacencyList, int source, HashSet<int> visited, HashSet<int> trackParent)
        //{
        //    visited.Add(source);
        //    trackParent.Add(source);

        //    List<int> nextVertex = adjacencyList[source];
        //    for (int i = 0; i < nextVertex.Count; i++)
        //    {
        //        if (!visited.Contains(i) && !trackParent.Contains(i) && DFSHelper(adjacencyList, i, visited, trackParent))
        //        {
        //            return true;
        //        }
        //        else if (trackParent.Contains(source))
        //        {
        //            return true;
        //        }
        //    }
        //    visited.Remove(source);
        //    return false;
        //}
    }
}
