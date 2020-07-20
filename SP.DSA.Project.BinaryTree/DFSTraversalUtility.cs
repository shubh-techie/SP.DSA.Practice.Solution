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
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public static void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
        }

        public static void PostOrder(TreeNode root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write(root.Data + " ");
            }
        }

        public static void PostOrderIterative(TreeNode root)
        {
            if (root != null)
            {
                Stack<TreeNode> track = new Stack<TreeNode>();
                List<int> output = new List<int>();
                TreeNode currNode = root;
                while (currNode != null || track.Count > 0)
                {
                    if (currNode != null)
                    {
                        output.Add(currNode.Data);
                        track.Push(currNode);
                        currNode = currNode.Right;
                    }
                    else
                    {
                        currNode = track.Pop().Left;
                    }
                }

                output.Reverse();

                Console.WriteLine(string.Join(", ", output));
            }
        }

        public static void PreOrderIterative(TreeNode root)
        {
            if (root != null)
            {
                Stack<TreeNode> track = new Stack<TreeNode>();
                TreeNode currNode = root;
                while (currNode != null || track.Count > 0)
                {
                    if (currNode != null)
                    {
                        Console.Write(currNode.Data + " ");
                        track.Push(currNode);
                        currNode = currNode.Left;
                    }
                    else
                    {
                        currNode = track.Pop().Right;
                    }
                }
            }
        }

        public static void InOrderIterative(TreeNode root)
        {
            if (root != null)
            {
                Stack<TreeNode> track = new Stack<TreeNode>();
                TreeNode currNode = root;
                while (currNode != null || track.Count > 0)
                {
                    if (currNode != null)
                    {
                        track.Push(currNode);
                        currNode = currNode.Left;
                    }
                    else if (track.Count > 0)
                    {
                        currNode = track.Pop();
                        Console.Write(currNode.Data + " ");
                        currNode = currNode.Right;
                    }
                }
            }
        }
    }
}



