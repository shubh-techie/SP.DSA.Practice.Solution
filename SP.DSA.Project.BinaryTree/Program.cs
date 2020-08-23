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
            BinaryTreeSolutionSetOne.BinaryTreeSolutionSetOneStart();


            //TreeNode root = GetTreeRoot();
            //ShowAllTraversal(root);
            //Console.WriteLine("Children parents {0}", BTCoreUtility.ChildrenSumParent(root));
            //Console.WriteLine("is balance Tree parents {0}", BTCoreUtility.IsBalanceTree(root));
            //BTCoreUtility.PrintRightViewBFS(root);
            //Console.WriteLine("Common Ansetor :" + BTCoreUtility.LCA(root, 40, 70).Data);
            //Console.WriteLine("Diameter of htis tree :" + BTCoreUtility.GetDiameterOFBinaryTree(root));

            //Console.WriteLine("Width of this array is :" + BTCoreUtility.GetMaxWidthRec(root));
            //Console.WriteLine("print left view");
            //Console.WriteLine();
            //BTCoreUtility.PrintAllLeftView(root);

            //Console.WriteLine("print left view");
            //Console.WriteLine();
            //BTCoreUtility.PrintAllLeftViewUsingRef(root);

            //Console.WriteLine("print left view");
            //Console.WriteLine();
            //BTCoreUtility.PrintAllLeftViewUsingBFS(root);

            //Console.WriteLine("spiral printing using stack");
            //BTCoreUtility.PrintSprialUsingTwoStack(root);

            //Console.WriteLine("Spiral Traversal");
            //BTCoreUtility.PrintSpiral(root);

            //Console.WriteLine("Level traversal");
            //BFSTraversalUtility.BFSTraverSal(root);
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

            Console.WriteLine();
            Console.WriteLine("Please press <enter> to exit.");
            Console.ReadLine();
        }

        private static void ShowAllTraversal(TreeNode root)
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("preorder traversal...");
            DFSTraversalUtility.PreOrder(root);

            Console.WriteLine("PreOrderIterative(root) traversal...");
            DFSTraversalUtility.PreOrderIterative(root);

            Console.WriteLine("===============================================");
            Console.WriteLine("InOrder traversal...");
            DFSTraversalUtility.InOrder(root);

            Console.WriteLine("InOrderIterative (root) traversal...");
            DFSTraversalUtility.InOrderIterative(root);

            Console.WriteLine("===============================================");
            Console.WriteLine("preorder traversal...");
            DFSTraversalUtility.PostOrder(root);

            Console.WriteLine("PostOrderIterative(root) traversal...");
            DFSTraversalUtility.PostOrderIterative(root);
            Console.WriteLine();
        }

        private static TreeNode GetTreeRoot()
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

            return root;
        }
    }
}
