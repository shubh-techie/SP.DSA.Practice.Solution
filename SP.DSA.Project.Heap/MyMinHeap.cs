using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Heap
{

    class MyMinHeap
    {
        int Size;
        int Capacity;
        int[] Storage;
        public MyMinHeap(int capacity)
        {
            this.Capacity = capacity;
            this.Storage = new int[capacity];
            this.Size = 0;
        }

        public int GetSize()
        {
            return this.Size;
        }

        public int GetPeek()
        {
            return this.Storage[0];
        }

        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        public int GetLeft(int index)
        {
            return (2 * index + 1);
        }

        public int GetRight(int index)
        {
            return (2 * index + 2);
        }

        public void Insert(int data)
        {
            if (this.Size == this.Capacity)
                return;

            this.Size++;
            int index = this.Size - 1;
            this.Storage[index] = data;
            this.BubbleUP(index);
        }

        public int ExtractMin()
        {
            if (this.Size == 0) throw new Exception("heap is empty");
            if (this.Size == 1)
                return this.Storage[0];

            //Swapping first and last element
            this.Swapping(0, this.Size - 1);
            this.Size--;
            this.BubbleDown(0);
            return this.Storage[this.Size];
        }

        public void Delete(int index)
        {
            this.Storage[index] = int.MinValue;
            this.BubbleUP(index);
            this.ExtractMin();
        }

        public void DecreaseValue(int index, int newValue)
        {
            this.Storage[index] = newValue;
            this.BubbleUP(index);
        }

        public void IncreaseValue(int index, int newValue)
        {
            this.Storage[index] = newValue;
            this.BubbleDown(index);
        }

        private void BubbleDown(int index)
        {
            if (index == this.Size) return;
            int left = this.GetLeft(index), right = this.GetRight(index);

            int smallestIndex = index;
            if (left < this.Size && this.Storage[left] < this.Storage[smallestIndex])
                smallestIndex = left;

            if (right < this.Size && this.Storage[right] < this.Storage[smallestIndex])
                smallestIndex = right;

            if (smallestIndex != index)
            {
                Swapping(smallestIndex, index);
                this.BubbleDown(smallestIndex);
            }

        }

        private void BubbleUP(int index)
        {
            if (index == 0) return;
            int parentIndex = this.GetParent(index);
            if (this.Storage[parentIndex] > this.Storage[index])
            {
                Swapping(parentIndex, index);
                BubbleUP(parentIndex);
            }
        }

        private void Swapping(int index1, int index2)
        {
            int temp = this.Storage[index1];
            this.Storage[index1] = this.Storage[index2];
            this.Storage[index2] = temp;
        }

        public override string ToString()
        {
            return string.Join("  ,", this.Storage);
        }

        public void PrintHeap()
        {
            for (int i = 0; i < this.GetSize(); i++)
            {
                Console.Write(this.Storage[i] + " ");
            }
            Console.WriteLine();
        }
    }

    public class MyMinHeapDemo
    {
        public static void Demo()
        {

            MyMinHeap myMinHeap = new MyMinHeap(10);
            // _minHeap.Storage = new int[] { 10, 20, 30, 40, 50, 60, 70 };
            myMinHeap.Insert(20);
            myMinHeap.Insert(10);
            myMinHeap.Insert(30);

            myMinHeap.PrintHeap();

            myMinHeap.Insert(40);
            myMinHeap.Insert(50);
            myMinHeap.Insert(60);

            myMinHeap.PrintHeap();

            myMinHeap.Insert(70);
            myMinHeap.Insert(5);
            myMinHeap.Insert(80);

            myMinHeap.PrintHeap();

            Console.WriteLine("root of this heap :" + myMinHeap.GetPeek());
            Console.WriteLine("Priority element :" + myMinHeap.ExtractMin());

            myMinHeap.Delete(4);
            myMinHeap.PrintHeap();
            myMinHeap.PrintHeap();
            myMinHeap.PrintHeap();
        }
    }
}
