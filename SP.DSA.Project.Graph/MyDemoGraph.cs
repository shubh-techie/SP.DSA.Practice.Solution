using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class MyDemoGraph
    {
        public static void Demo()
        {

            TestingcriticalConnections();
            //TestingGetArticulationPoints();

            //GraphUtility.BFS(graphObj.AdjacencyList, 5);
            //GraphUtility.DFS(graphObj.AdjacencyList, 5);
            //GraphUtility.DFSRecursion(graphObj.AdjacencyList, 5);
            //List<int> paths = GraphUtility.GetShortestPath(graphObj, 0);
            //Console.WriteLine("shorted path :" + string.Join(" ", paths));

        }

        private static void TestingcriticalConnections()
        {
            GNode cGraph = new GNode(6);
            cGraph.AddEdgeUGraph(1, 2);
            cGraph.AddEdgeUGraph(1, 3);
            cGraph.AddEdgeUGraph(3, 4);
            cGraph.AddEdgeUGraph(1, 4);
            cGraph.AddEdgeUGraph(4, 5);

            cGraph.PrintGraph();
            List<List<int>> criticalEdges = GraphUtility.GetCriticalConnection(cGraph);

            foreach (var item in criticalEdges)
            {
                Console.WriteLine(string.Join(" ", item));
            }


            cGraph = new GNode(4);
            cGraph.AddEdgeUGraph(0, 1);
            cGraph.AddEdgeUGraph(1, 2);
            cGraph.AddEdgeUGraph(2, 0);
            cGraph.AddEdgeUGraph(1, 3);

            cGraph.PrintGraph();
            criticalEdges = GraphUtility.GetCriticalConnection(cGraph);

            foreach (var item in criticalEdges)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }

        public void TestingGetArticulationPoints()
        {
            //GNode graphObj = new GNode(5);
            //graphObj.AddEdge(0, 1);
            //graphObj.AddEdge(0, 2);
            //graphObj.AddEdge(0, 3);
            //graphObj.AddEdge(2, 4);
            //graphObj.AddEdge(2, 0);
            //graphObj.AddEdge(2, 3);
            //graphObj.AddEdge(3, 3);

            //graphObj.PrintGraph();


            //GraphUtility.GetArticulationPoints(graphObj);

            GNode CriticalRoutersGraph = new GNode(7);
            CriticalRoutersGraph.AddEdgeUGraph(0, 1);
            CriticalRoutersGraph.AddEdgeUGraph(0, 2);
            CriticalRoutersGraph.AddEdgeUGraph(1, 3);
            CriticalRoutersGraph.AddEdgeUGraph(2, 3);
            CriticalRoutersGraph.AddEdgeUGraph(2, 5);
            CriticalRoutersGraph.AddEdgeUGraph(5, 6);
            CriticalRoutersGraph.AddEdgeUGraph(3, 4);
            CriticalRoutersGraph.PrintGraph();


            //GNode g3 = new GNode(7);
            //g3.AddEdgeUGraph(0, 1);
            //g3.AddEdgeUGraph(1, 2);
            //g3.AddEdgeUGraph(2, 0);
            //g3.AddEdgeUGraph(1, 3);
            //g3.AddEdgeUGraph(1, 4);
            //g3.AddEdgeUGraph(1, 6);
            //g3.AddEdgeUGraph(3, 5);
            //g3.AddEdgeUGraph(4, 5);

            //g3.PrintGraph();

            List<int> result = GraphUtility.GetArticulationPoints(CriticalRoutersGraph);
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
