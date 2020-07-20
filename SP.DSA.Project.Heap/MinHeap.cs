using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Heap
{
    public class MinHeap
    {
        public int[] Storage;
        public int Size { get; set; }
        public int Capacity { get; set; }
        public MinHeap(int capacity)
        {
            this.Capacity = capacity;
            Storage = new int[capacity];
            Size = 0;
        }


        public void MinHeadDemo()
        {
            MinHeap _minHeap = new MinHeap(100);
            // _minHeap.Storage = new int[] { 10, 20, 30, 40, 50, 60, 70 };
            _minHeap.Insert(10);
            _minHeap.Insert(20);
            _minHeap.Insert(30);
            _minHeap.Insert(40);
            _minHeap.Insert(50);
            _minHeap.Insert(60);
            _minHeap.Insert(70);
            _minHeap.Insert(5);
            _minHeap.Insert(80);
            Console.WriteLine("root of this heap :" + _minHeap.GetPeek());

            Console.WriteLine("Priority element :" + _minHeap.ExtractMin());

            _minHeap.Delete(4);
            _minHeap.PrintHeap();

          
        }

        public int GetPeek()
        {
            return this.Storage[0];
        }

        public int GetSize()
        {
            return this.Size;
        }
        public void Insert(int Data)
        {
            if (this.Size == this.Capacity) throw new Exception("index out of range.");
            this.Size++;
            Storage[Size - 1] = Data;
            int i = Size - 1;
            this.BubbleUp(i);
        }

        public int ExtractMin()
        {
            if (this.Size == 0) throw new Exception("There is no priorit item.");
            if (this.Size == 1)
            {
                return this.Storage[0];
            }

            //Swap wiht last element the last element.
            this.Swap(0, Size - 1);

            //Decrease the root.
            this.Size--;

            //bubble donwn the array.
            this.BubbleDown(0);

            return Storage[this.Size];
        }

        public void Delete(int index)
        {
            Storage[index] = int.MinValue;
            BubbleUp(index);
            this.ExtractMin();
        }

        public void BubbleUp(int i)
        {
            if (i == 0) return;

            //interation.
            //while (i >= 0 && (Storage[GetParent(i)] > Storage[i]))
            //{
            //    this.Swap(GetParent(i), i);
            //    //i = GetParent(i);
            //    BubbleUp(GetParent(i));
            //}

            //Recursion.
            this.PrintHeap();
            if (Storage[GetParent(i)] > Storage[i])
            {
                this.Swap(GetParent(i), i);
                BubbleUp(GetParent(i));
            }

        }
        public void BubbleDown(int i)
        {
            if (i == this.Size) return;

            int left = this.GetLeft(i); int right = this.GetRight(i);
            int smallest = i;

            if (left < this.Size && Storage[left] < Storage[smallest])
            {
                smallest = left;
            }

            if (right < this.Size && Storage[right] < Storage[smallest])
            {
                smallest = right;
            }

            if (smallest != i)
            {
                Swap(smallest, i);
                BubbleDown(smallest);
            }
            this.PrintHeap();
        }

        public int GetParent(int i)
        {
            return (i - 1) / 2;
        }

        public int GetLeft(int i)
        {
            return 2 * i + 1;
        }

        public int GetRight(int i)
        {
            return 2 * i + 2;
        }
        public void Swap(int n1, int n2)
        {
            int temp = Storage[n1];
            Storage[n1] = Storage[n2];
            Storage[n2] = temp;
        }

        public void PrintHeap()
        {
            Console.WriteLine();
            for (int i = 0; i < this.GetSize(); i++)
            {
                Console.Write(this.Storage[i] + "  ");
            }
        }
    }
}
