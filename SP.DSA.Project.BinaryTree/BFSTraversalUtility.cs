using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class BFSTraversalUtility
    {
        public static void BFSTraverSal(TreeNode root)
        {
            if (root == null)
                return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            TreeNode currNode = null;
            while (queue.Count > 1)
            {
                currNode = queue.Dequeue();
                if (currNode == null)
                {
                    queue.Enqueue(null);
                    continue;
                }
                Console.Write(currNode.Data + " ");

                if (currNode.Left != null)
                    queue.Enqueue(currNode.Left);
                if (currNode.Right != null)
                    queue.Enqueue(currNode.Right);
            }
        }

        public static void BFSTraverSalSolution2(TreeNode root)
        {
            if (root == null)
                return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode currNode = queue.Dequeue();
                    Console.Write(currNode.Data + " ");
                    if (currNode.Left != null)
                        queue.Enqueue(currNode.Left);
                    if (currNode.Right != null)
                        queue.Enqueue(currNode.Right);
                }
                Console.WriteLine();
            }
        }
    }
}
