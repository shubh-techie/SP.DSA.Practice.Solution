using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = GetTreeRoot();
            Console.WriteLine("Children parents {0}", BTCoreUtility.ChildrenSumParent(root));



            //Console.WriteLine("print left view");
            //Console.WriteLine();
            //BTCoreUtility.PrintAllLeftView(root);

            //Console.WriteLine("print left view");
            //Console.WriteLine();
            //BTCoreUtility.PrintAllLeftViewUsingRef(root);

            //Console.WriteLine("print left view");
            //Console.WriteLine();
            //BTCoreUtility.PrintAllLeftViewUsingBFS(root);



            Console.WriteLine("Level traversal");
            BFSTraversalUtility.BFSTraverSal(root);
            //ShowAllTraversal(root);
            //Console.WriteLine("height of the tree  : {0}", BTCoreUtility.GetHeightOfBinaryTree(root));
            //Console.WriteLine("is identical : {0}", BTCoreUtility.IsIdentical(root, root));
            //Console.WriteLine("Size of this tree is  : {0}", BTCoreUtility.GetSize(root));
            //Console.WriteLine("Maximum value :{0}", BTCoreUtility.GetMax(root));
            //Console.WriteLine("is sum 100 present  : {0}", BTCoreUtility.HasSumPresent(root, 100));
            //BTCoreUtility.GetKthLevelBinaryTree(root, 1);
            //Console.WriteLine();
            //Console.WriteLine("level order traversal...");
            //BFSTraversalUtility.BFSTraverSal(root);

            //Console.WriteLine("level order Solution...");
            //BFSTraversalUtility.BFSTraverSalSolution2(root);

            Console.WriteLine("Please press <enter> to exit.");
            Console.ReadLine();
        }

        private static void ShowAllTraversal(TreeNode root)
        {
            Console.WriteLine("PreOrderIterative(root) traversal...");
            Console.WriteLine();
            //DFSTraversalUtility.PreOrderIterative(root);

            Console.WriteLine("preorder traversal...");
            Console.WriteLine();
            DFSTraversalUtility.PreOrder(root);

            Console.WriteLine("preorder traversal...");
            Console.WriteLine();
            DFSTraversalUtility.InOrder(root);

            Console.WriteLine("preorder traversal...");
            Console.WriteLine();
            DFSTraversalUtility.PostOrder(root);
        }

        private static TreeNode GetTreeRoot()
        {
            TreeNode root = new TreeNode(30)
            {
                Left = new TreeNode(10),
                Right = new TreeNode(20)
            };

            root.Left.Left = new TreeNode(6);
            root.Left.Right = new TreeNode(4);

            root.Right.Right = new TreeNode(20);

            return root;
        }
    }
}
