using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LinkedList
{
    public class DoublyLinkedNode
    {
        public int Val;
        public DoublyLinkedNode Prev, Next;
        public DoublyLinkedNode(int val)
        {
            this.Val = val;
        }
    }

    public class DoublyLinkedList
    {
        DoublyLinkedNode Head;
        public DoublyLinkedList()
        {
            this.Head = null;
        }

        public int Get(int index)
        {
            DoublyLinkedNode currNode = GetNode(index);
            return currNode != null ? currNode.Val : -1;
        }

        public DoublyLinkedNode GetNode(int index)
        {
            DoublyLinkedNode currNode = Head;
            for (int i = 0; i < index || currNode != null; i++)
            {
                currNode = currNode.Next;
            }
            return currNode;
        }

        public DoublyLinkedNode GetTail()
        {
            DoublyLinkedNode currNode = Head;
            while (currNode != null && currNode.Next != null)
            {
                currNode = currNode.Next;
            }
            return currNode;
        }

        public void AddAtHead(int val)
        {
            DoublyLinkedNode tempNode = new DoublyLinkedNode(val);
            tempNode.Next = Head;
            if (this.Head != null)
            {
                this.Head.Prev = tempNode;
            }
            Head = tempNode;
        }

        public void AddATail(int val)
        {
            if (this.Head == null)
            {
                this.AddAtHead(val);
                return;
            }
            else
            {
                DoublyLinkedNode tempNode = new DoublyLinkedNode(val);
                DoublyLinkedNode tailNode = this.GetTail();
                tailNode.Next = tempNode;
                tempNode.Prev = tailNode;
            }
        }

        public void Traverse()
        {
            DoublyLinkedNode currNode = this.Head;
            while (currNode != null)
            {
                Console.Write(" " + currNode.Val);
                currNode = currNode.Next;
            }


            Console.WriteLine();
        }

        public void DeleteAtIndex(int index)
        {
            DoublyLinkedNode deleteIndex = this.GetNode(index);
            if (deleteIndex == null)
                return;
            DoublyLinkedNode _prev = deleteIndex.Prev;
            DoublyLinkedNode _next = deleteIndex.Next;
            if (_prev != null)
            {
                _prev.Next = _next;
            }
            else
            {
                Head = _next;
            }

            if (_next != null)
            {
                _next.Prev = _prev;
            }
        }
    }
    public class DoubleLinkedListDemo
    {
        public static void DoubleLinkedListDemoStart()
        {
            DoublyLinkedList DLL = new DoublyLinkedList();
            DLL.AddAtHead(100);
            DLL.AddAtHead(200);
            DLL.AddAtHead(300);
            DLL.AddAtHead(400);
            DLL.AddAtHead(500);
            DLL.Traverse();
        }
    }
}
