using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    /*
      We are given a binary tree (with root node root), a target node, and an integer value K.
      Return a list of the values of all nodes that have a distance K from the target node.  The answer can be returned in any order.
     */
    public class Ques863AllNodesDistanceKinBinaryTree
    {
        public static void DistanceKDemo()
        {
            TreeNode root = new TreeNode(3);
            root.Left = new TreeNode(5);
            root.Left.Left = new TreeNode(6);
            root.Left.Right = new TreeNode(2) { Left = new TreeNode(7), Right = new TreeNode(4) };
            root.Right = new TreeNode(1) { Left = new TreeNode(0), Right = new TreeNode(8) };

            int k = 5;
            IList<int> result = DistanceK(root, root.Left, k);
            Console.WriteLine(string.Join(" ", result));
        }

        private static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            IList<int> output = new List<int>();
            if (root == null) return output;
            Dictionary<TreeNode, int> distanceMapping = new Dictionary<TreeNode, int>();
            Find(root, target, distanceMapping);
            DistanceKHelper(root, target, k, distanceMapping[root], output, distanceMapping);
            return output;
        }

        private static void DistanceKHelper(TreeNode root, TreeNode target, int k, int depth, IList<int> output, Dictionary<TreeNode, int> distanceMapping)
        {
            if (root == null) return;
            if (distanceMapping.ContainsKey(root))
                depth = distanceMapping[root];

            if (depth == k)
                output.Add(root.Val);

            DistanceKHelper(root.Left, target, k, depth + 1, output, distanceMapping);
            DistanceKHelper(root.Right, target, k, depth + 1, output, distanceMapping);
        }

        private static int Find(TreeNode root, TreeNode target, Dictionary<TreeNode, int> distanceMapping)
        {
            if (root == null) return -1;
            if (root == target)
            {
                distanceMapping[root] = 0;
                return 0;
            }

            int left = Find(root.Left, target, distanceMapping);
            if (left >= 0)
            {
                distanceMapping[root] = left + 1;
                return left + 1;
            }

            int right = Find(root.Right, target, distanceMapping);
            if (right >= 0)
            {
                distanceMapping[root] = right + 1;
                return right + 1;
            }

            return -1;
        }
    }
}
