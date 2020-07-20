using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LinkedList
{
    interface ILinkedList
    {
        void AddFirst();
        void AddLast();
        LinkNode GetIndexNode();
        int GetIndexValue();
    }

    public class LinkNode
    {
        public int Val;
        public LinkNode Next;
        public LinkNode(int val)
        {
            this.Val = val;
            this.Next = null;
        }
    }

    public class SingleLinkedList
    {
        LinkNode Head;
        public SingleLinkedList()
        {
            this.Head = null;
        }

        public void AddFirst(int val)
        {
            LinkNode temp = new LinkNode(val);
            temp.Next = this.Head;
            this.Head = temp;
        }

        public void AddLast(int val)
        {
            LinkNode temp = new LinkNode(val);
            if (this.Head == null)
            {
                AddFirst(val);
            }
            else
            {
                LinkNode tailNode = this.GetTailNode();
                tailNode.Next = temp;
            }
        }
        public LinkNode GetTailNode()
        {
            LinkNode currNode = this.Head;
            while (currNode.Next != null)
            {
                currNode = currNode.Next;
            }
            return currNode;
        }

        public void DeleteFirst()
        {
            if (this.Head != null)
            {
                this.Head = this.Head.Next;
            }
        }

        public void DeleteLast()
        {
            if (this.Head == null)
                DeleteFirst();
            else
            {
                LinkNode currNode = this.Head;
                while (currNode.Next.Next != null)
                {
                    currNode = currNode.Next;
                }
                currNode.Next = null;
            }
        }

        public void Traverse()
        {
            if (this.Head == null)
            {
                Console.WriteLine("List is empty.");
            }
            else
            {
                LinkNode currrNode = this.Head;
                while (currrNode != null)
                {
                    Console.Write(currrNode.Val + "  ");
                    currrNode = currrNode.Next;
                }
                Console.WriteLine();
            }
        }

        public int GetIndexValue(int index)
        {
            LinkNode currrNode = this.GetIndexNode(index);
            return currrNode == null ? -1 : currrNode.Val;
        }

        private LinkNode GetIndexNode(int index)
        {
            LinkNode currNode = this.Head;
            for (int i = 0; i < index && currNode != null; i++)
            {
                currNode = currNode.Next;
            }
            return currNode;
        }

        private void RemoveNthNode(int index)
        {
            LinkNode currNode = this.GetIndexNode(index);
            if (currNode == null)
                return;
            if (currNode.Next == null)
                currNode = null;

            if (currNode.Next.Next != null)
                currNode.Next = null;
        }
    }

    public class SingleLinkedListDemo
    {
        public static void SingleLinkedListDemoStart()
        {
            SingleLinkedList linkedList = new SingleLinkedList();
            linkedList.AddFirst(100);
            linkedList.AddFirst(200);
            linkedList.AddFirst(300);
            linkedList.AddFirst(400);
            linkedList.Traverse();
            linkedList.AddLast(600);
            linkedList.AddLast(700);
            linkedList.AddLast(800);
            linkedList.Traverse();
            linkedList.DeleteFirst();
            linkedList.Traverse();
            linkedList.DeleteLast();
            linkedList.Traverse();
        }
    }
}

