using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class BTCoreUtility
    {
        public static void ConvertMirror(TreeNode root)
        {
            if (root == null) return;
            ConvertMirror(root.Left);
            ConvertMirror(root.Right);

            TreeNode temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;
        }
        public static bool IsMirror(TreeNode root)
        {
            return IsMirrorHelper(root, root);
        }

        private static bool IsMirrorHelper(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;

            if (root1.Data != root2.Data) return false;
            return IsMirrorHelper(root1.Left, root2.Right) && IsMirrorHelper(root1.Right, root2.Left);
        }

        public static int GetDiameterOFBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            int currDia = 1 + GetHight(root.Left) + GetHight(root.Right);
            int diaLeft = GetDiameterOFBinaryTree(root.Left);
            int diaRight = GetDiameterOFBinaryTree(root.Right);
            return Math.Max(currDia, Math.Max(diaLeft, diaRight));
        }

        private static void GetDiameterOFBinaryTreeHelper(TreeNode root, ref int uMax)
        {
            if (root == null) return;
            int leftHight = GetHight(root.Left);
            int rightHeight = GetHight(root.Right);

            uMax = Math.Max(uMax, 1 + leftHight + rightHeight);
            GetDiameterOFBinaryTreeHelper(root.Left, ref uMax);
            GetDiameterOFBinaryTreeHelper(root.Right, ref uMax);
        }

        public static TreeNode LCA(TreeNode root, int p, int q)
        {
            if (root == null) return null;
            if (root.Data == p || root.Data == q)
                return root;
            TreeNode left = LCA(root.Left, p, q);
            TreeNode right = LCA(root.Right, p, q);
            //if (left == null && right == null) return null;
            if (left != null && right != null) return root;
            return left != null ? left : right;
        }
        public static void PrintRightViewBFS(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode currNode = null;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    currNode = queue.Dequeue();
                    if (i == count - 1)
                        Console.WriteLine(currNode.Data + "");

                    if (currNode.Left != null)
                        queue.Enqueue(currNode.Left);
                    if (currNode.Right != null)
                        queue.Enqueue(currNode.Right);
                }
            }
        }


        public static void PrintLeftViewBFS(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode currNode = null;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    currNode = queue.Dequeue();
                    if (i == 0)
                        Console.WriteLine(currNode.Data + "");

                    if (currNode.Left != null)
                        queue.Enqueue(currNode.Left);
                    if (currNode.Right != null)
                        queue.Enqueue(currNode.Right);
                }
            }
        }

        public static void PrintLeftViewDFS(TreeNode root)
        {
            if (root == null) return;
            int maxValue = 0;
            PrintAllLeftViewHelper(root, ref maxValue, 1);
        }

        private static void PrintAllLeftViewHelper(TreeNode root, ref int maxLevel, int level)
        {
            if (root == null) return;
            if (maxLevel < level)
            {
                Console.WriteLine("printing for level " + level + " val :" + root.Data);
                maxLevel = level;
            }

            PrintAllLeftViewHelper(root.Left, ref maxLevel, level + 1);
            PrintAllLeftViewHelper(root.Right, ref maxLevel, level + 1);
        }

        public static bool IsBalanceTree(TreeNode root)
        {
            if (root == null) return true;
            int leftHight = GetHight(root.Left);
            int rightHeight = GetHight(root.Right);
            return Math.Abs(leftHight - rightHeight) <= 1 && IsBalance(root.Left) && IsBalance(root.Right);
        }
        public static int GetMaxWidth(TreeNode root)
        {
            if (root == null) return 0;
            int uMax = 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode currNode = null;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                uMax = Math.Max(count, uMax);
                for (int i = 0; i < count; i++)
                {
                    currNode = queue.Dequeue();
                    if (currNode.Left != null)
                        queue.Enqueue(currNode.Left);
                    if (currNode.Right != null)
                        queue.Enqueue(currNode.Right);
                }
            }

            return uMax;
        }

        public static int GetMaxWidthRec(TreeNode root)
        {
            if (root == null) return 0;
            int uWidth = 0;
            List<int> track = new List<int>();
            GetMaxWidthHelper(root, track, 0, ref uWidth);
            return uWidth;
        }

        private static void GetMaxWidthHelper(TreeNode root, List<int> track, int level, ref int uWidth)
        {
            if (root == null)
                return;
            else if (level >= track.Count)
                track.Add(1);
            else
                track[level]++;

            uWidth = Math.Max(uWidth, track[level]);
            GetMaxWidthHelper(root.Left, track, level + 1, ref uWidth);
            GetMaxWidthHelper(root.Right, track, level + 1, ref uWidth);
        }

        public static void PrintSprialUsingTwoStack(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> leftToRight = new Stack<TreeNode>();
            Stack<TreeNode> rightToLeft = new Stack<TreeNode>();
            leftToRight.Push(root);
            TreeNode currNode = null;
            while (leftToRight.Count > 0 || rightToLeft.Count > 0)
            {
                while (leftToRight.Count > 0)
                {
                    currNode = leftToRight.Pop();
                    Console.Write(currNode.Data + " ");
                    if (currNode.Right != null)
                        rightToLeft.Push(currNode.Right);
                    if (currNode.Left != null)
                        rightToLeft.Push(currNode.Left);

                }
                while (rightToLeft.Count > 0)
                {
                    currNode = rightToLeft.Pop();
                    Console.Write(currNode.Data + " ");
                    if (currNode.Left != null)
                        leftToRight.Push(currNode.Left);
                    if (currNode.Right != null)
                        leftToRight.Push(currNode.Right);
                }
            }
        }
        public static void PrintSpiral(TreeNode node)
        {
            if (node == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            queue.Enqueue(node);
            TreeNode currNode = null;
            bool reverse = false;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    currNode = queue.Dequeue();
                    if (reverse)
                        stack.Push(currNode);
                    else
                        Console.Write(currNode.Data + " ");

                    if (currNode.Left != null)
                        queue.Enqueue(currNode.Left);
                    if (currNode.Right != null)
                        queue.Enqueue(currNode.Right);
                }
                if (reverse)
                {
                    while (stack.Count > 0)
                    {
                        Console.Write(stack.Pop().Data + " ");
                    }
                }
                reverse = !reverse;
                Console.WriteLine();
            }

        }
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
            if (root != null) return;

            if (maxLevel < level)
            {
                Console.WriteLine(root.Data + " ");
                maxLevel = level;
            }

            PrintAllLeftViewUsingRefHelper(root.Left, ref maxLevel, level + 1);
            PrintAllLeftViewUsingRefHelper(root.Right, ref maxLevel, level + 1);

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
