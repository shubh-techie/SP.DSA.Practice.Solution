using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LinkedList
{
    public class Node
    {
        public int Key, Value;
        public Node Prev, Next;
        public Node(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    public class CustomDoubleLinkedList
    {
        Node Head;
        Node Tail;
        public CustomDoubleLinkedList()
        {
            this.Head = new Node(0, 0);
            this.Tail = new Node(0, 0);
            this.Head.Next = this.Tail;
            this.Tail.Prev = this.Head;
        }
        public void AddToHead(Node currNode)
        {
            currNode.Prev = this.Head;
            currNode.Next = this.Head.Next;
            this.Head.Next.Prev = currNode;
            this.Head.Next = currNode;
        }

        public void PromoteToHead(Node currNode)
        {
            RemoveNode(currNode);
            AddToHead(currNode);
        }

        public void RemoveNode(Node currNode)
        {
            currNode.Prev.Next = currNode.Next;
            currNode.Next.Prev = currNode.Prev;
        }

        public void RemoveTail()
        {
            Node newTail = GetTailNode().Prev;
            newTail.Next = this.Tail;
            this.Tail.Prev = newTail;
        }

        public Node GetTailNode()
        {
            return this.Tail.Prev;
        }

    }

    public class LRUCache
    {
        CustomDoubleLinkedList DoubleLinkList;
        Dictionary<int, Node> cacheMap;
        int Capacity;

        public LRUCache(int capacity)
        {
            DoubleLinkList = new CustomDoubleLinkedList();
            this.Capacity = capacity;
            this.cacheMap = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if (cacheMap.ContainsKey(key))
            {
                Node CurrNode = cacheMap[key];
                int currValue = CurrNode.Value;
                DoubleLinkList.PromoteToHead(CurrNode);
                return currValue;
            }
            return -1;
        }

        public void Set(int key, int value)
        {
            if (cacheMap.ContainsKey(key))
            {
                Node hitNode = cacheMap[key];
                hitNode.Value = value;
                DoubleLinkList.PromoteToHead(hitNode);
            }
            else
            {
                Node newNode = new Node(key, value);
                if (cacheMap.Count == this.Capacity)
                {
                    Node tailNode = this.DoubleLinkList.GetTailNode();
                    this.cacheMap.Remove(tailNode.Key);
                    this.DoubleLinkList.RemoveTail();
                }
                cacheMap.Add(key, newNode);
                this.DoubleLinkList.AddToHead(newNode);
            }
        }
    }

    public class LRUCacheDemo
    {
        public static void LRUCacheDemoStart()
        {
            LRUCache cache = new LRUCache(5);
            cache.Set(1, 100);
            cache.Set(2, 200);
            cache.Set(3, 300);
            cache.Set(4, 400);
            cache.Set(5, 500);
            Console.WriteLine(cache.Get(4));
        }
    }
}
