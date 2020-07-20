using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinarySearchTree
{
    public class Obj
    {
        public TreeNode Node;
        public int HLevel;
        public Obj(TreeNode node, int hLevel)
        {
            this.Node = node;
            this.HLevel = hLevel;
        }

    }
    public class CoreBSTUtility
    {
        public static void TopViewBT(TreeNode root)
        {
            SortedDictionary<int, int> topSet = new SortedDictionary<int, int>();
            GetBottomView(root, topSet, 0);
            foreach (var item in topSet.Values)
            {
                Console.Write(item + " ");
            }
        }

        private static void GetBottomView(TreeNode root, SortedDictionary<int, int> topSet, int level)
        {
            if (root == null) return;
            Queue<Obj> queue = new Queue<Obj>();
            queue.Enqueue(new Obj(root, 0));
            while (queue.Count > 0)
            {
                Obj currObj = queue.Dequeue();
                if (!topSet.ContainsKey(currObj.HLevel))
                {
                    topSet.Add(currObj.HLevel, currObj.Node.Data);
                }
                else
                {
                    topSet[currObj.HLevel] = currObj.Node.Data;
                }

                if (currObj.Node.Left != null)
                    queue.Enqueue(new Obj(currObj.Node.Left, currObj.HLevel - 1));
                if (currObj.Node.Right != null)
                    queue.Enqueue(new Obj(currObj.Node.Right, currObj.HLevel + 1));
            }
        }

        private static void GetTopView(TreeNode root, SortedDictionary<int, int> topSet, int level)
        {
            if (root == null) return;
            Queue<Obj> queue = new Queue<Obj>();
            queue.Enqueue(new Obj(root, 0));
            while (queue.Count > 0)
            {
                Obj currObj = queue.Dequeue();
                if (!topSet.ContainsKey(currObj.HLevel))
                {
                    topSet.Add(currObj.HLevel, currObj.Node.Data);
                }

                if (currObj.Node.Left != null)
                    queue.Enqueue(new Obj(currObj.Node.Left, currObj.HLevel - 1));
                if (currObj.Node.Right != null)
                    queue.Enqueue(new Obj(currObj.Node.Right, currObj.HLevel + 1));
            }
        }

        public static void VerticalTraversal(TreeNode root)
        {
            if (root == null) return;
            SortedDictionary<int, List<int>> map = new SortedDictionary<int, List<int>>();
            Queue<Obj> queue = new Queue<Obj>();
            queue.Enqueue(new Obj(root, 0));
            while (queue.Count > 0)
            {
                Obj currObj = queue.Dequeue();
                if (map.ContainsKey(currObj.HLevel))
                    map[currObj.HLevel].Add(currObj.Node.Data);
                else
                    map.Add(currObj.HLevel, new List<int>() { currObj.Node.Data });

                if (currObj.Node.Left != null)
                    queue.Enqueue(new Obj(currObj.Node.Left, currObj.HLevel - 1));

                if (currObj.Node.Right != null)
                    queue.Enqueue(new Obj(currObj.Node.Right, currObj.HLevel + 1));
            }

            foreach (var lColl in map.Values)
            {
                foreach (var item in lColl)
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
