using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = GetBinarySearchTree();
            PreOrder(root);
            Console.WriteLine();
            GetKthElement(root, 3);
            //ConvertBinarySearachTree.ConvertBinarySearachTreeDemo();
            //Console.WriteLine("is MaxDiff : " + MaxDiff(root, 83));
            //CoreBSTUtility.TopViewBT(root);
            //Console.WriteLine(GetCountOFNode(root, 70, 110));
            //Console.WriteLine("is BST" + IsBSTUsingIntValue(root));
            //Console.WriteLine("Floor of this BST " + GetFloor(root, 4));
            //Console.WriteLine(IsSumFound(root, 40));
            //Console.WriteLine("lowest common ancestor " + GetLCA(root, 130, 80).Data);
            //PrintInRange(root, 80, 110);
            //Console.WriteLine("is binary search tree " + IsBinarySearchTree(root));
            //Console.WriteLine("is this key found :" + IsKeyPresentInBST(root, 105));
            //Console.WriteLine("Minimum Element in this tree" + GetMinimumElement(root));
            //printCommon(root, root);
            //Console.WriteLine("Floor of this tree :" + GetFloorBST(root, 10));
            //Console.WriteLine("Floor of this tree :" + GetCeilBST(root, 180));

            //TreeNode rootv2 = InsertInBST(root, 105);
            //TreeNode rootv3 = InsertInBST(root, 115);
            //PreOrder(rootv3);
            //Console.WriteLine();

            //TreeNode rootv4 = DeleteNode(root, 100);
            //PreOrder(rootv4);
            //Console.WriteLine();

            //Console.WriteLine();
            //levelOrder(rootv4);

            //SmalleroRight();

            Console.WriteLine();
            Console.WriteLine("------------------end of program press<enter>-------------------");
            Console.ReadLine();
        }

        private static void GetKthElement(TreeNode root, int k)
        {
            if (root != null)
            {
                Console.WriteLine("printing k " + k);
                k = k - 1;
                GetKthElement(root.Left, k);
                if (k == 0)
                {
                    Console.WriteLine("kth element :" + root.Data);
                    return;
                }
                GetKthElement(root.Right, k);
            }
        }

        TreeNode Insert(TreeNode root, int data)
        {
            if (root == null)
                return new TreeNode(data);
            if (data < root.Data)
                root.Left = Insert(root.Left, data);
            if (data > root.Data)
                root.Right = Insert(root.Right, data);
            return root;
        }

        public static TreeNode ConstructBst(int[] arr, int n)
        {
            TreeNode root = null;

            for (int i = 0; i < arr.Length; i++)
            {
                root = InsertInBST(root, arr[i]);
            }
            return root;
        }

        private static int MaxDiff(TreeNode root, int key)
        {
            if (root == null) return 0;
            int minDiff = int.MaxValue;

            while (root != null)
            {
                if (root.Data == key)
                    return 0;

                minDiff = Math.Min(minDiff, Math.Abs(root.Data - key));

                if (key < root.Data)
                    root = root.Left;
                else
                    root = root.Right;
            }

            return minDiff;
        }

        private static void VerticalTraversal(TreeNode root)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            VerticalTraversal(root, result, 0);

            foreach (var lColl in result.Values)
            {
                foreach (var item in lColl)
                {
                    Console.Write(item + " ");
                }
            }
        }

        private static void VerticalLevelTraversal(TreeNode root, Dictionary<int, List<int>> result, int hLevel)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode currNode = null;
            int level = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {

                }
            }
        }

        private static void VerticalTraversal(TreeNode root, Dictionary<int, List<int>> result, int hLevel)
        {
            if (root == null) return;
            VerticalTraversal(root.Left, result, hLevel - 1);
            if (!result.ContainsKey(hLevel))
            {
                result.Add(hLevel, new List<int>() { root.Data });
            }
            else
            {
                result[hLevel].Add(root.Data);
            }
            VerticalTraversal(root.Right, result, hLevel + 1);
        }

        private static bool IsBSTUsingIntValue(TreeNode root)
        {
            return IsBSTUsingIntValueHelper(root, int.MinValue, int.MaxValue);
        }

        private static bool IsBSTUsingIntValueHelper(TreeNode root, int leftData, int rightData)
        {
            if (root == null) return true;
            return root.Data > leftData && root.Data < rightData && IsBSTUsingIntValueHelper(root.Left, leftData, root.Data) && IsBSTUsingIntValueHelper(root.Right, root.Data, rightData);
        }

        private static bool IsBST(TreeNode root)
        {
            return IsBSTHelper(root, null, null);
        }

        private static bool IsBSTHelper(TreeNode root, TreeNode left, TreeNode right)
        {
            if (root == null) return true;
            if (left != null && root.Data < left.Data)
                return false;
            if (right != null && root.Data > right.Data)
                return false;
            return IsBSTHelper(root.Left, left, root) && IsBSTHelper(root.Right, root, right);
        }

        private static int GetFloor(TreeNode root, int key)
        {
            if (root == null) return -1;
            TreeNode result = null;
            while (root != null)
            {
                if (root.Data == key)
                    return root.Data;
                if (key < root.Data)
                    root = root.Left;
                else
                {
                    result = root;
                    root = root.Right;
                }
            }
            return result == null ? int.MaxValue : result.Data;
        }

        private static void SmalleroRight()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int no = Convert.ToInt32(Console.ReadLine());
                string str = Console.ReadLine();
                int[] input = new int[no];
                int count = 0;
                foreach (string item in str.Split(' '))
                {
                    input[count++] = Convert.ToInt32(item);
                }
                Console.WriteLine(string.Join(", ", input));

                Console.Write("Max :{0} for this array", GetSmallerOnRight(input));

            }

        }

        private static int GetSmallerOnRight(int[] arr)
        {
            int uMax = 0, lmax = 0, size = arr.Length;
            Stack<int> track = new Stack<int>();
            for (int i = size - 1; i >= 0; i--)
            {
                while (track.Count > 0 && track.Peek() >= arr[i])
                {
                    track.Pop();
                }
                uMax = Math.Max(uMax, track.Count);
                Console.WriteLine(uMax + " ");
                track.Push(arr[i]);
            }

            return uMax;
        }

        private static bool IsSumFound(TreeNode root, int sum)
        {
            HashSet<int> seen = new HashSet<int>();
            return IsSumFoundHelper(root, sum, seen);
        }

        private static bool IsSumFoundHelper(TreeNode root, int sum, HashSet<int> seen)
        {
            if (root == null) return false;
            if (IsSumFoundHelper(root.Left, sum, seen) == true) return true;
            int otherPair = sum - root.Data;
            if (seen.Contains(otherPair))
                return true;
            else
                seen.Add(root.Data);
            return IsSumFoundHelper(root.Right, sum, seen);
        }

        private static List<int> PrintInRange(TreeNode root, int low, int high)
        {
            List<int> output = new List<int>();
            //PrintInRange(root, low, high, output);
            output.Sort();
            return output;
        }

        private static int GetCountOFNode(TreeNode root, int low, int high)
        {
            int[] arr = new int[1];
            PrintInRange(root, low, high, arr);
            return arr.Length;
        }

        private static void PrintInRange(TreeNode root, int start, int end, int[] arr)
        {
            if (root == null) return;
            if (root.Data >= start && root.Data <= end)
                arr[0]++;
            PrintInRange(root.Left, start, end, arr);
            PrintInRange(root.Right, start, end, arr);
        }

        private static TreeNode GetLCA(TreeNode root, int p, int q)
        {
            if (root == null)
                return null;
            if (root.Data == p || root.Data == q)
                return root;
            TreeNode _left = GetLCA(root.Left, p, q);
            TreeNode _right = GetLCA(root.Right, p, q);
            if (_left == null && _right == null) return null;
            if (_left != null && _right != null) return root;
            return _left != null ? _left : _right;
        }

        private static TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            else if (key < root.Data)
                root.Left = DeleteNode(root.Left, key);
            else if (key > root.Data)
                root.Right = DeleteNode(root.Right, key);
            else
            {
                if (root.Left == null)
                    return root.Right;
                if (root.Right == null)
                    return root.Left;
                else
                {
                    TreeNode success = GetNextSuccessor(root);
                    root.Data = success.Data;
                    root.Right = DeleteNode(root.Right, success.Data);
                }
            }

            return root;
        }

        private static TreeNode DeleteKeyFromBST(TreeNode root, int key)
        {
            if (root == null) return null;
            else if (key < root.Data)
                root.Left = DeleteKeyFromBST(root.Left, key);
            else if (key > root.Data)
                root.Right = DeleteKeyFromBST(root.Right, key);
            else
            {
                if (root.Left == null)
                    return root.Right;
                if (root.Right == null)
                    return root.Left;
                else
                {
                    TreeNode successor = GetSuccessor(root);
                    root.Data = successor.Data;
                    root.Right = DeleteKeyFromBST(root.Right, successor.Data);
                }
            }

            return root;
        }

        private static TreeNode GetSuccessor(TreeNode root)
        {
            TreeNode currNode = root.Right;
            while (root != null && currNode.Left != null)
            {
                currNode = currNode.Left;
            }
            return currNode;
        }

        private static TreeNode GetNextSuccessor(TreeNode root)
        {
            TreeNode currNode = root.Right;
            while (currNode != null && currNode.Left != null)
            {
                currNode = currNode.Left;
            }
            return currNode;
        }

        private static void printCommon(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return;
            List<int> commonCollection = new List<int>();
            HashSet<int> trackSet = new HashSet<int>();

            GetRoot1Items(root1, trackSet);
            GetAllCommonItems(root2, trackSet, commonCollection);
            commonCollection.Sort();
            Console.WriteLine(string.Join(", ", commonCollection));
        }

        private static void GetAllCommonItems(TreeNode root2, HashSet<int> trackSet, List<int> commonCollection)
        {
            if (root2 == null) return;
            if (trackSet.Contains(root2.Data))
                commonCollection.Add(root2.Data);
            GetAllCommonItems(root2.Left, trackSet, commonCollection);
            GetAllCommonItems(root2.Right, trackSet, commonCollection);
        }

        private static void GetRoot1Items(TreeNode root, HashSet<int> items)
        {
            if (root == null) return;
            items.Add(root.Data);
            GetRoot1Items(root.Left, items);
            GetRoot1Items(root.Right, items);
        }

        private static int GetMinimumElement(TreeNode root)
        {
            if (root == null) return -1;
            int prev = -1;
            while (root != null)
            {
                prev = root.Data;
                root = root.Left;
            }

            return prev;
        }

        private static bool IsKeyPresentInBST(TreeNode root, int key)
        {
            if (root == null) return false;

            while (root != null)
            {
                if (root.Data == key)
                    return true;

                if (key < root.Data)
                    root = root.Left;
                else
                    root = root.Right;
            }

            return false;
        }

        private static int GetCeilBST(TreeNode root, int key)
        {
            int output = -1;
            while (root != null)
            {
                if (root.Data == key)
                    return root.Data;
                else if (root.Data < key)
                    root = root.Right;
                else
                {
                    output = root.Data;
                    root = root.Left;
                }
            }
            return output;
        }

        private static int GetFloorBST(TreeNode root, int key)
        {
            int output = -1;

            while (root != null)
            {
                if (root.Data == key)
                {
                    return root.Data;
                }
                else if (root.Data > key)
                {
                    root = root.Left;
                }
                else
                {
                    output = root.Data;
                    root = root.Right;
                }
            }

            return output;
        }

        public static void levelOrder(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode currNode = null;
            while (queue.Count > 0)
            {
                currNode = queue.Dequeue();
                Console.Write(currNode.Data + " ");
                if (currNode.Left != null)
                    queue.Enqueue(currNode.Left);
                if (currNode.Right != null)
                    queue.Enqueue(currNode.Right);
            }
        }





        private static TreeNode InsertInBST(TreeNode root, int key)
        {
            if (root == null)
                return new TreeNode(key);
            else if (root.Data == key)
                return root;
            if (key < root.Data)
                root.Left = InsertInBST(root.Left, key);
            else
                root.Right = InsertInBST(root.Right, key);

            return root;
        }

        private static bool IsBinarySearchTree(TreeNode root)
        {
            return IsBinarySearchTreeHelper(root, null, null);
        }

        private static bool IsBinarySearchTreeHelper(TreeNode root, TreeNode left, TreeNode right)
        {
            if (root == null) return true;

            if (left != null && left.Data > root.Data)
                return false;
            if (right != null && right.Data < root.Data)
                return true;

            return IsBinarySearchTreeHelper(root.Left, left, root) && IsBinarySearchTreeHelper(root.Right, root, right);
        }

        private static TreeNode GetBinarySearchTree()
        {
            TreeNode root = new TreeNode(100)
            {
                Left = new TreeNode(80),
                Right = new TreeNode(120)
            };

            root.Left.Left = new TreeNode(70);
            root.Left.Right = new TreeNode(90);

            root.Right.Left = new TreeNode(110);
            root.Right.Right = new TreeNode(130);

            return root;
        }

        private static void PreOrder(TreeNode root)
        {
            if (root == null) return;
            Console.Write(root.Data + "  ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }


    }
}
