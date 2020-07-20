using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LinkedList
{
    public class LinkedListUtility
    {
        public static void LinkedListUtilityDemo()
        {
            AdditionOfTwoListDemo();
        }

        private static void AdditionOfTwoListDemo()
        {
            LinkNode h1 = new LinkNode(2);
            h1.Next = new LinkNode(3);
            h1.Next.Next = new LinkNode(4);
            h1.Next.Next.Next = new LinkNode(4);
            Console.WriteLine("head 1");
            Traverse(h1);

            LinkNode h2 = new LinkNode(3);
            h2.Next = new LinkNode(4);
            h2.Next.Next = new LinkNode(5);
            h2.Next.Next.Next = new LinkNode(5);
            Console.WriteLine("head 2");
            Traverse(h2);

            LinkNode result = GetSum(h1, h2);
            Traverse(result);

            //ReverseList(h1);
            //Console.WriteLine("head 1");
            //Traverse(h1);

            //ReverseList(h2);
            //Console.WriteLine("head 2");
            //Traverse(h2);

            LinkNode reverseresult = GetSumReverse(h1, h2);
            Traverse(reverseresult);
        }

        private static LinkNode GetSumReverse(LinkNode h1, LinkNode h2)
        {
            if (h1 == null) return h2;
            if (h2 == null) return h1;
            h1 = ReverseList(h1);
            h2 = ReverseList(h2);
            return GetSum(h1, h2);
        }

        private static LinkNode ReverseList(LinkNode head)
        {
            LinkNode currNode = head, prev = null, next = null;

            while (currNode != null)
            {
                next = currNode.Next;
                currNode.Next = prev;
                prev = currNode;
                currNode = next;
            }
            head = prev;
            return head;
        }

        private static LinkNode GetSum(LinkNode h1, LinkNode h2)
        {
            LinkNode dummyNode = new LinkNode(0);
            LinkNode sumNode = null;
            sumNode = dummyNode;

            LinkNode currH1 = h1;
            LinkNode currH2 = h2;
            int rem = 0, sum = 0;

            while (currH1 != null || currH2 != null)
            {
                int digit1 = h1 == null ? 0 : currH1.Val;
                int digit2 = h2 == null ? 0 : currH2.Val;
                sum = digit1 + digit2 + rem;

                sumNode.Next = new LinkNode(sum % 10);
                sumNode = sumNode.Next;
                rem = sum / 10;
                //move to next node.
                if (currH1 != null)
                    currH1 = currH1.Next;
                if (currH2 != null)
                    currH2 = currH2.Next;
            }
            if (rem > 0)
                sumNode.Next = new LinkNode(rem);
            return dummyNode.Next;
        }

        private static void Traverse(LinkNode head)
        {
            Console.WriteLine();
            LinkNode currNode = head;
            while (currNode != null)
            {
                Console.Write(currNode.Val + " ");
                currNode = currNode.Next;
            }
            Console.WriteLine();
        }
    }
}
