using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinarySearchTree
{
    class ConvertBinarySearachTree
    {
        public static void ConvertBinarySearachTreeDemo()
        {
            int[] arr = { 7, 4, 12, 3, 6, 8, 1, 5, 10 };
            TreeNode root = ConvertBinarySearachTreeStart(arr, arr.Length);
            PreOrder(root);
        }
        public static TreeNode ConvertBinarySearachTreeStart(int[] arr, int n)
        {
            TreeNode root = null;
            for (int i = 0; i < arr.Length; i++)
            {
                root = InsertInBST(root, arr[i]);
            }
            return root;
        }
        public static TreeNode InsertInBST(TreeNode root, int data)
        {
            if (root == null)
                return new TreeNode(data);
            if (data < root.Data)
                root.Left = InsertInBST(root.Left, data);
            if (data > root.Data)
                root.Right = InsertInBST(root.Right, data);
            return root;
        }

        private static void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }



    }
}
