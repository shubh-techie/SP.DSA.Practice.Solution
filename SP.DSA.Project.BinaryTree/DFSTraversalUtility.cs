using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class DFSTraversalUtility
    {
        public static void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                Console.Write("NULL" + " ");
            }
            else
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public static void InOrder(TreeNode root)
        {
            if (root == null)
            {
                Console.Write("NULL" + " ");
            }
            else
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
        }

        public static void PostOrder(TreeNode root)
        {
            if (root == null)
            {
                Console.Write("NULL" + " ");
            }
            else
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write(root.Data + " ");
            }
        }

        public static void PreOrderIterative(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("There is no item to display.");
                return;
            }

            Stack<TreeNode> track = new Stack<TreeNode>();
            TreeNode tempNode = root;
            while (tempNode != null || track.Count > 0)
            {
                Console.WriteLine(tempNode.Data);
                if (tempNode.Left != null)
                {
                    tempNode = tempNode.Left;
                    if (tempNode.Right != null)
                        track.Push(tempNode.Right);
                }
                else
                {
                    tempNode = track.Pop();
                    tempNode = tempNode.Left;
                    if (tempNode.Right != null)
                        track.Push(tempNode.Right);
                }
            }
        }
    }
}



