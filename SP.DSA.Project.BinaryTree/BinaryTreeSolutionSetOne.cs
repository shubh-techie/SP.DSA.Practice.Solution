using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class BinaryTreeSolutionSetOne
    {
        public static void BinaryTreeSolutionSetOneStart()
        {
            TreeNode root = new TreeNode(10)
            {
                Left = new TreeNode(20),
                Right = new TreeNode(30)
            };

            root.Left.Left = new TreeNode(40);
            root.Left.Right = new TreeNode(50);

            root.Right.Left = new TreeNode(60);
            root.Right.Right = new TreeNode(70);

            BTCoreUtility.LevelOrder(root);
            //BinaryTreeDemo.LevelLineByLineOrder(root);


            //Console.WriteLine("Has sum 110           :{0}", BinaryTreeDemoUtility.HasPathSum(root, 100));
            //Console.WriteLine("Max Path Sum          :{0}", BinaryTreeDemoUtility.MaxPathSum(root));
            //Console.WriteLine("DepthOfBinaryTree     :{0}", BinaryTreeDemoUtility.DepthOfBinaryTree(root));
            //Console.WriteLine("DepthHelperBottomUp   :{0}", BinaryTreeDemoUtility.DepthHelperBottomUp(root));
            //Console.WriteLine("DepthHelperBFS        :{0}", BinaryTreeDemoUtility.DepthHelperBFS(root));
            //Console.WriteLine("DepthHelperBFS        :{0}", BinaryTreeDemoUtility.DepthHelperBFS(root));
            //SerializeAndDeserializeBinaryTree.SerializeAndDeserialize(root);


            //BinaryTreeDemo.Traversal(root);
            Console.WriteLine();
        }
    }
}
