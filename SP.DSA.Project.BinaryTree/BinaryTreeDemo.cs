using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class BinaryTreeDemo
    {
        public static void Traversal(TreeNode root)
        {
            Console.WriteLine();
            Console.WriteLine("LevelLineByLineOrder Order .................");
            LevelLineByLineOrder(root);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Level Order .................");
            LevelOrder(root);
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("PreOrder .................");
            PreOrder(root);

            Console.WriteLine();
            Console.WriteLine("PreOrderIteration .................");
            PreOrderIteration(root);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("PostOrder .................");
            PostOrder(root);

            Console.WriteLine();
            Console.WriteLine("PostOrderIteration .................");
            PostOrderIteration(root);
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("InOrder .................");
            InOrder(root);

            Console.WriteLine();
            Console.WriteLine("InOrderIteration .................");
            InOrderIteration(root);
            Console.WriteLine();

        }
        public static void PreOrderIteration(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode currNode = root;
            while (currNode != null || stack.Count > 0)
            {
                if (currNode != null)
                {
                    Console.Write(currNode.Data + " ");
                    stack.Push(currNode);
                    currNode = currNode.Left;
                }
                else
                {
                    currNode = stack.Count > 0 ? stack.Pop().Right : null;
                }
            }
        }
        public static void PostOrderIteration(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> postOutput = new List<int>();
            TreeNode currNode = root;

            while (currNode != null || stack.Count > 0)
            {
                if (currNode != null)
                {
                    postOutput.Insert(0, currNode.Data);
                    stack.Push(currNode);
                    currNode = currNode.Right;
                }
                else
                {
                    currNode = stack.Count > 0 ? stack.Pop().Left : null;
                }
            }

            //postOutput.Reverse();
            Console.WriteLine(string.Join(" ", postOutput));
        }
        public static void InOrderIteration(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode currNode = root;
            while (currNode != null || stack.Count > 0)
            {
                if (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.Left;
                }
                else
                {
                    currNode = stack.Count > 0 ? stack.Pop() : null;
                    Console.Write(currNode.Data + " ");
                    currNode = currNode.Right;
                }
            }
        }

        public static void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
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

        public static void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
        }


        public static void LevelOrder(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode currNode = queue.Dequeue();
                Console.Write(currNode.Data + " ");

                if (currNode.Left != null)
                    queue.Enqueue(currNode.Left);
                if (currNode.Right != null)
                    queue.Enqueue(currNode.Right);
            }
        }

        public static void LevelLineByLineOrder(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode currNode = null;
            List<int> temp = null;
            List<List<int>> result = new List<List<int>>();

            while (queue.Count > 0)
            {
                int count = queue.Count;
                temp = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    currNode = queue.Dequeue();
                    temp.Add(currNode.Data);

                    if (currNode.Left != null)
                        queue.Enqueue(currNode.Left);

                    if (currNode.Right != null)
                        queue.Enqueue(currNode.Right);
                }
                result.Add(temp);
                Console.WriteLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }


        }
    }
}
