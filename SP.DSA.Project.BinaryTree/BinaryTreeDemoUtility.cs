using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class BinaryTreeDemoUtility
    {
        public TreeNode MakeMirror(TreeNode root)
        {
            if (root == null) return null;
            MakeMirror(root.Left);
            MakeMirror(root.Right);

            TreeNode temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            return root;
        }
        public int VerticalLength(TreeNode root)
        {
            int min = 0, max = 0;
            HelperVerticalLength(root, ref min, ref max, 0);
            return 1 + Math.Abs(min) + Math.Abs(max);
        }

        private void HelperVerticalLength(TreeNode root, ref int min, ref int max, int curr)
        {
            if (root == null) return;

            min = Math.Min(min, curr);
            max = Math.Max(max, curr);
            HelperVerticalLength(root.Right, ref min, ref max, curr - 1);
            HelperVerticalLength(root.Right, ref min, ref max, curr + 1);
        }

        public static int Diameter(TreeNode root)
        {
            if (root == null) return 0;
            int currDiameter = 1 + GetHeight(root.Left) + GetHeight(root.Right);
            return Math.Max(currDiameter, Math.Max(Diameter(root.Left), Diameter(root.Left)));
        }

        public static bool IsBalance(TreeNode root)
        {
            if (root == null) return true;
            int lh = GetHeight(root.Left);
            int rh = GetHeight(root.Right);
            int abs = Math.Abs(lh - rh);
            return abs <= 1 && IsBalance(root.Left) && IsBalance(root.Right);
        }

        private static int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
        }

        public TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root.Data == p.Data || root.Data == q.Data) return root;

            TreeNode left = LCA(root.Left, p, q);
            TreeNode right = LCA(root.Right, p, q);

            if (left != null && right != null)
                return root;
            return left != null ? left : right;
        }

        public TreeNode BuildTree(int[] preOrder, int[] inOrder)
        {
            if (inOrder.Length == 0 && preOrder.Length == 0) return null;
            return BuildTreeHelper(preOrder, inOrder, 0, 0, inOrder.Length - 1);
        }

        private TreeNode BuildTreeHelper(int[] preOrder, int[] inOrder, int preStart, int inStart, int inEnd)
        {
            if (preStart > preOrder.Length - 1 || inStart > inEnd)
                return null;

            int inIndex = 0;

            TreeNode root = new TreeNode(preOrder[preStart]);
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inOrder[i] == root.Data)
                {
                    inIndex = i;
                    break;
                }
            }

            root.Left = BuildTreeHelper(preOrder, inOrder, preStart + 1, inStart, inIndex - 1);
            root.Right = BuildTreeHelper(preOrder, inOrder, preStart + 1 + inIndex - inStart, inIndex + 1, inEnd);
            return root;
        }

        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            return HasPathSumHelper(root, sum);
        }

        private static bool HasPathSumHelper(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.Left == null && root.Right == null && root.Data == sum)
                return true;
            return HasPathSumHelper(root.Left, sum - root.Data) || HasPathSumHelper(root.Right, sum - root.Data);
        }

        public static int MaxPathSum(TreeNode root)
        {
            if (root == null) return 0;
            int lMax = root.Data + MaxPathSum(root.Left);
            int rMax = root.Data + MaxPathSum(root.Right);
            return Math.Max(lMax, rMax);
        }
        public bool IsSymmetric(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;

            return root1.Data == root2.Data && IsSymmetric(root1.Left, root2.Right) && IsSymmetric(root1.Right, root2.Left);
        }

        public static int DepthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            int depth = 0;
            DepthHelper(root, 1, ref depth);
            return depth;
        }

        private static void DepthHelper(TreeNode root, int depth, ref int maxDepth)
        {
            if (root == null) return;
            maxDepth = Math.Max(maxDepth, depth);
            DepthHelper(root.Left, depth + 1, ref maxDepth);
            DepthHelper(root.Right, depth + 1, ref maxDepth);
        }

        public static int DepthHelperBottomUp(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(DepthHelperBottomUp(root.Left), DepthHelperBottomUp(root.Right));
        }

        public static int DepthHelperBFS(TreeNode root)
        {
            if (root == null) return 0;
            int level = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                level++;
                for (int i = 0; i < count; i++)
                {
                    TreeNode curr = queue.Dequeue();

                    if (curr.Left != null)
                        queue.Enqueue(curr.Left);

                    if (curr.Right != null)
                        queue.Enqueue(curr.Right);
                }
            }

            return level;
        }
    }
}
