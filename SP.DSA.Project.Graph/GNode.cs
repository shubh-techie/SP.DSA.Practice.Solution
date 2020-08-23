using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Graph
{
    public class GNode
    {
        public int vCount;
        public List<List<int>> AdjacencyList;
        public GNode(int vertixCount)
        {
            vCount = vertixCount;
            this.AdjacencyList = new List<List<int>>(vertixCount);
            for (int i = 0; i < vCount; i++)
            {
                AdjacencyList.Add(new List<int>());
            }
        }

        public void AddEdge(int vertix, int edge)
        {
            this.AdjacencyList[vertix].Add(edge);
        }

        public void AddEdgeUGraph(int vertix, int edge)
        {
            this.AdjacencyList[vertix].Add(edge);
            this.AdjacencyList[edge].Add(vertix);
        }

        public void PrintGraph()
        {
            for (int i = 0; i < this.AdjacencyList.Count; i++)
            {
                Console.Write(i);
                foreach (var item in this.AdjacencyList[i])
                {
                    Console.Write("->" + item);
                }
                Console.WriteLine();
            }
        }
    }
}
