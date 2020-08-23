using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Heap
{
    public class PriorityQueueDemo
    {
        public static void Demo()
        {
            // int[] Ropes = { 4, 3, 2, 6 };
            int[] Ropes = { 8, 4, 6, 12 };
            int size = Ropes.Length;

            Console.WriteLine("Mimimum Cost :" + GetMimimumCost(Ropes, size));
        }

        private static int GetMimimumCost(int[] ropes, int size)
        {
            if (size == 0) return 0;
            int cost = 0;
            PriorityQueue priorityQueue = new PriorityQueue(ropes, size);
            while (priorityQueue.Size != 1)
            {
                int fMin = priorityQueue.ExtractMin();
                int sMin = priorityQueue.ExtractMin();
                cost += fMin + sMin;
                priorityQueue.InsertKey(fMin + sMin);
            }

            return cost;
        }

    }

    internal class PriorityQueue
    {
        public int Size { get; set; }

        public int[] Storage;
        public int Capacity;

        public PriorityQueue(int[] arr, int capacity)
        {
            this.Size = capacity;
            this.Capacity = capacity;
            this.Storage = arr;

            for (int i = GetParent(this.Size); i >= 0; i--)
            {
                MinHeapify(i);
            }
        }

        private void MinHeapify(int index)
        {
            if (index == 0) return;

            int left = this.GetLeft(index);
            int right = this.GetParent(index);
            int smallest = index;
            if (left < this.Size && this.Storage[left] < this.Storage[smallest])
                smallest = left;
            if (right < this.Size && this.Storage[right] < this.Storage[smallest])
                smallest = right;

            if (smallest != index)
            {
                this.Swapping(smallest, index);
                MinHeapify(smallest);
            }
        }

        public void InsertKey(int value)
        {
            if (this.Size == this.Capacity) throw new Exception("storage is full");
            this.Size++;
            int index = this.Size - 1;
            this.Storage[index] = value;
            this.BubbleUp(index);
        }

        private void BubbleUp(int index)
        {
            if (index == 0)
                return;

            int parentIndex = this.GetParent(index);
            if (this.Storage[parentIndex] > this.Storage[index])
            {
                this.Swapping(parentIndex, index);
                this.BubbleUp(parentIndex);
            }
        }

        public int ExtractMin()
        {
            if (this.Size == 0) throw new Exception("Min heap is empty");
            if (this.Size == 1)
                return this.Storage[0];

            Swapping(0, this.Size - 1);
            this.Size--;
            MinHeapify(0);
            return this.Storage[this.Size];
        }

        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        public int GetLeft(int index)
        {
            return 2 * index + 1;
        }

        public int GetRight(int index)
        {
            return 2 * index + 2;
        }

        public void Swapping(int i, int j)
        {
            int temp = this.Storage[i];
            this.Storage[i] = this.Storage[j];
            this.Storage[j] = temp;
        }

    }
}
