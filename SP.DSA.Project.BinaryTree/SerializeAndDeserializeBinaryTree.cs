using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BinaryTree
{
    public class SerializeAndDeserializeBinaryTree
    {
        public static void SerializeAndDeserialize(TreeNode root)
        {
            Codec codec = new Codec();
            Console.WriteLine(codec.serialize(root));
        }
    }

    public class Codec
    {
        private void serializeHelper(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("null").Append(",");
            }
            else
            {
                sb.Append(root.Data).Append(",");
                serializeHelper(root.Left, sb);
                serializeHelper(root.Right, sb);
            }
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            serializeHelper(root, sb);
            return sb.ToString();
        }



        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            Queue<string> dataQueue = new Queue<string>();
            string[] split = data.Split(',');
            foreach (var item in split)
            {
                dataQueue.Enqueue(item);
            }
            return deserializeHelper(dataQueue);
        }

        private TreeNode deserializeHelper(Queue<string> dataQueue)
        {
            if (dataQueue.Count == 0) return null;
            string val = dataQueue.Dequeue();
            if (val == "null")
                return null;
            TreeNode root = new TreeNode(Convert.ToInt32(val));
            root.Left = deserializeHelper(dataQueue);
            root.Right = deserializeHelper(dataQueue);
            return root;
        }
    }
}
