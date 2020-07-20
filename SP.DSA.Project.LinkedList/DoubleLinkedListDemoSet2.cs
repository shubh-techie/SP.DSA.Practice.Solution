using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LinkedList
{
    public class DoubleLinkedListNode
    {
        public int Val;
        public DoubleLinkedListNode Prev, Next;
        public DoubleLinkedListNode(int val)
        {
            this.Val = val;
            this.Prev = this.Next = null;
        }
    }

    public class MyDoubleLinkedList
    {
        DoubleLinkedListNode Head;
        public MyDoubleLinkedList()
        {
            Head = null;
        }

        public int GetIndexValue(int index)
        {
            DoubleLinkedListNode curr = GetIndexNode(index);
            return curr == null ? -1 : curr.Val;
        }
        public DoubleLinkedListNode GetIndexNode(int index)
        {
            DoubleLinkedListNode curr = this.Head;
            for (int i = 0; i < index && curr != null; i++)
            {
                curr = curr.Next;
            }
            return curr;
        }

        public DoubleLinkedListNode GetTail()
        {
            DoubleLinkedListNode curr = this.Head;
            while (curr != null && curr.Next != null)
            {
                curr = curr.Next;
            }
            return curr;
        }

        public void AddATHead(int val)
        {
            DoubleLinkedListNode tempNode = new DoubleLinkedListNode(val);
            tempNode.Next = this.Head;
            if (this.Head != null)
            {
                this.Head.Prev = tempNode;
            }
            this.Head = tempNode;
        }

        public void AddATail(int val)
        {
            if (this.Head == null)
            {
                AddATHead(val);
            }
            else
            {
                DoubleLinkedListNode tempNode = new DoubleLinkedListNode(val);
                DoubleLinkedListNode TailNode = GetTail();
                tempNode.Prev = TailNode;
                TailNode.Next = tempNode;
            }

        }

        public void DeleteFromGivenIndex(int index)
        {
            DoubleLinkedListNode deleteNode = GetIndexNode(index);
            if (deleteNode == null)
            {
                return;
            }

            DoubleLinkedListNode prev = deleteNode.Prev;
            DoubleLinkedListNode next = deleteNode.Next;

            if (prev != null)
            {
                prev.Next = next;
            }
            else
            {
                Head = next;
            }

            if (next != null)
            {
                next.Prev = prev;
            }
        }

    }

    class DoubleLinkedListDemoSet2
    {
    }
}
