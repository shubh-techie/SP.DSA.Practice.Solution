using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class BTCoreUtility
    {
        public static int GetHeightOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(GetHeightOfBinaryTree(root.Left), GetHeightOfBinaryTree(root.Right));
        }

        public static bool IsIdentical(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null && root2 == null)
                return false;

            if (root1.Data != root2.Data)
                return false;

            return IsIdentical(root1.Left, root1.Left) && IsIdentical(root1.Right, root2.Right);
        }

        public static int GetSize(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + GetSize(root.Left) + GetSize(root.Right);
        }

        public static bool HasSumPresent(TreeNode root, int sum)
        {
            if (root == null && sum == 0)
                return true;
            else
                return HasSumPresent(root.Left, sum - root.Data) || HasSumPresent(root.Right, sum - root.Data);
        }

        public static int GetMax(TreeNode root)
        {
            if (root == null)
                return int.MinValue;
            return Math.Max(root.Data, Math.Max(GetMax(root.Left), GetMax(root.Right)));
        }

        private static int GetMaxHelper(TreeNode root, int maxVal)
        {
            if (root == null)
                return maxVal;
            int leftMax = GetMaxHelper(root.Left, Math.Max(maxVal, root.Data));
            int rightMax = GetMaxHelper(root.Right, Math.Max(maxVal, root.Data));
            return Math.Max(leftMax, rightMax);
        }

        public static void GetKthLevelBinaryTree(TreeNode root, int k)
        {
            if (root != null)
            {
                if (k == 0)
                    Console.WriteLine(root.Data + " ");
                GetKthLevelBinaryTree(root.Left, k - 1);
                GetKthLevelBinaryTree(root.Right, k - 1);
            }
        }

        public static void PrintAllLeftView(TreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Data + " ");
                if (root != null)
                    PrintAllLeftView(root.Left);
                else
                    PrintAllLeftView(root.Right);
            }

        }

        public static void PrintAllLeftViewUsingBFS(TreeNode root)
        {
            if (root != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        TreeNode currNode = queue.Dequeue();
                        if (i == 0)
                            Console.WriteLine(currNode.Data + " ");

                        if (currNode.Left != null)
                            queue.Enqueue(currNode.Left);
                        if (currNode.Right != null)
                            queue.Enqueue(currNode.Right);
                    }
                }
            }
        }

        public static void PrintAllLeftViewUsingRef(TreeNode root)
        {
            if (root != null)
            {
                int maxLevel = 0;
                PrintAllLeftViewUsingRefHelper(root, ref maxLevel, 1);
            }

        }

        public static void PrintAllLeftViewUsingRefHelper(TreeNode root, ref int maxLevel, int level)
        {
            if (root != null)
            {
                if (maxLevel < level)
                {
                    Console.WriteLine(root.Data + " ");
                    maxLevel = level;
                }

                PrintAllLeftViewUsingRefHelper(root.Left, ref maxLevel, level + 1);
                PrintAllLeftViewUsingRefHelper(root.Right, ref maxLevel, level + 1);
            }

        }


        public static bool ChildrenSumParent(TreeNode root)
        {
            if (root == null)
                return true;
            else if (root.Left == null && root.Right == null)
                return true;

            int sum = getSum(root);
            return root.Data == sum && ChildrenSumParent(root.Left) && ChildrenSumParent(root.Right);
        }

        private static int getSum(TreeNode root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return root.Data;
            else
                return getSum(root.Left) + getSum(root.Right);
        }

        public static bool IsBalance(TreeNode root)
        {
            if (root == null) return true;
            int leftHight = GetHeightOfBinaryTree(root.Left);
            int rightHeight = GetHeightOfBinaryTree(root.Right);
            return Math.Abs(leftHight - rightHeight) <= 1 && IsBalance(root.Left) && IsBalance(root.Right);
        }

        private static int GetHight(TreeNode Childroot)
        {
            if (Childroot == null) return 0;
            return 1 + Math.Max(GetHight(Childroot.Left), GetHight(Childroot.Right));
        }
    }
}
