using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Heap
{

    public class DemoMinHeapAsPriorityQueue
    {
        public static void Demo()
        {
            //int[] Ropes = { 4, 3, 2, 6 };
            //int[] Ropes = { 8, 4, 6, 12 };
            int[] Ropes = { 1, 2, 5, 10, 35, 89 };
            //int[] Ropes = { 20, 4, 8, 2 };
            int size = Ropes.Length;
            Console.WriteLine("Mimimum Cost :" + GetMimimumCost(Ropes, size));
        }

        private static int GetMimimumCost(int[] ropes, int size)
        {
            if (size == 0) return 0;
            int cost = 0;
            MaxHeap priorityQueue = new MaxHeap(size);
            for (int i = 0; i < size; i++)
            {
                priorityQueue.Insert(ropes[i]);
            }
            priorityQueue.PrintHeap();

            while (priorityQueue.GetSize() != 1)
            {
                int fMin = priorityQueue.Pop();
                int sMin = priorityQueue.Pop();
                cost += fMin + sMin;
                priorityQueue.Insert(fMin + sMin);
            }
            return cost;
        }

    }

    abstract public class Heap
    {
        private int Capacity;
        protected int Size;
        protected int[] Storage;

        public Heap()
        {

        }

        public Heap(int capacity)
        {
            this.Capacity = capacity;
            this.Storage = new int[capacity];
            this.Size = 0;
        }

        public int GetPeek()
        {
            return this.Storage[0];
        }

        public int GetSize()
        {
            return this.Size;
        }

        public int GetParent(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public int GetLeft(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        public int GetRight(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
        protected void Swap(int i, int j)
        {
            int temp = this.Storage[i];
            this.Storage[i] = this.Storage[j];
            this.Storage[j] = temp;
        }

        public void PrintHeap()
        {
            Console.WriteLine();
            for (int i = 0; i < this.Size; i++)
            {
                Console.Write(this.Storage[i] + " ");
            }
            Console.WriteLine();
        }

        public void Insert(int val)
        {
            if (this.Size == this.Capacity) return;
            this.Size++;
            this.Storage[this.Size - 1] = val;
            MinHeapifyUP(this.Size - 1);
        }

        public int Pop()
        {
            if (this.Size == 0) throw new Exception("Heap is empty.");
            if (this.Size == 1)
            {
                this.Size--;
                return this.Storage[0];
            }
            this.Swap(0, this.Size - 1);
            this.Size--;
            this.MinHeapifyDown(0);
            return this.Storage[this.Size];
        }


        protected abstract void MinHeapifyUP(int index);
        protected abstract void MinHeapifyDown(int index);
    }

    public class DemoMinHeap : Heap
    {
        public DemoMinHeap(int capacity) : base(capacity)
        {
        }

        protected override void MinHeapifyUP(int index)
        {
            if (index == 0) return;

            int parentIndex = this.GetParent(index);
            if (this.Storage[parentIndex] > this.Storage[index])
            {
                Swap(parentIndex, index);
                MinHeapifyUP(parentIndex);
            }
        }

        protected override void MinHeapifyDown(int index)
        {
            if (index == this.Size) return;
            int smallestIndex = index;
            int leftIndex = this.GetLeft(index), rightIndex = this.GetRight(index);
            if (leftIndex < this.GetSize() && this.Storage[leftIndex] < this.Storage[smallestIndex])
            {
                smallestIndex = leftIndex;
            }

            if (rightIndex < this.GetSize() && this.Storage[rightIndex] < this.Storage[smallestIndex])
            {
                smallestIndex = rightIndex;
            }

            if (smallestIndex != index)
            {
                Swap(smallestIndex, index);
                MinHeapifyDown(smallestIndex);
            }
        }
    }

    public class MaxHeap : Heap
    {
        public MaxHeap(int capacity) : base(capacity)
        {

        }

        protected override void MinHeapifyUP(int index)
        {
            if (index == 0) return;

            int parentIndex = this.GetParent(index);
            if (this.Storage[parentIndex] < this.Storage[index])
            {
                Swap(parentIndex, index);
                MinHeapifyUP(parentIndex);
            }
        }

        protected override void MinHeapifyDown(int index)
        {
            if (index == this.Size) return;
            int biggerIndex = index;
            int leftIndex = this.GetLeft(index), rightIndex = this.GetRight(index);
            if (leftIndex < this.GetSize() && this.Storage[leftIndex] > this.Storage[biggerIndex])
            {
                biggerIndex = leftIndex;
            }

            if (rightIndex < this.GetSize() && this.Storage[rightIndex] > this.Storage[biggerIndex])
            {
                biggerIndex = rightIndex;
            }

            if (biggerIndex != index)
            {
                Swap(biggerIndex, index);
                MinHeapifyDown(biggerIndex);
            }
        }
    }
}
