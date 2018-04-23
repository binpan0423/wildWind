using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycodingpractice
{
    abstract class Heap
    {
        public int[] data;
        public int length;
        public Heap(int[] data)
        {
            this.data = data;
            this.length = data.Length;
        }


        //构建堆
        public abstract Heap BuildHeap();

        //自上而下调整
        public abstract void AdjustDown(int index);
        //自下而上调整
        public abstract void AdjustUp(int index);


        //删除根节点
        public abstract Heap Remove();
        //插入到最后
        public abstract Heap Insert(int value);


        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) >> 1;
        }

        public int GetLeftChildIndex(int parentIndex)
        {
            return (parentIndex << 1) + 1;
        }

        public int GetRightChildIndex(int parentIndex)
        {
            return (parentIndex << 1) + 2;
        }

        public void Swap(int indexA, int indexB)
        {
            data[indexA] = data[indexA] ^ data[indexB];
            data[indexB] = data[indexA] ^ data[indexB];
            data[indexA] = data[indexA] ^ data[indexB];
        }

        public void Print()
        {
            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    //最小堆   二叉树， 根节点最小，并且其左右子树也是最小堆。
    class MinHeap : Heap
    {
        public MinHeap(int[] data)
            : base(data)
        {

        }


        public override Heap BuildHeap()
        {
            //从最后一个节点的父节点开始
            int start = GetParentIndex(length - 1);
            for (; start >= 0; start--)
            {
                AdjustDown(start);
            }
            return this;
        }


        public override Heap Remove()
        {
            Swap(0, length - 1);
            int[] newData = new int[length - 1];
            Array.Copy(data, newData, length - 1);
            this.data = newData;
            this.length = length - 1;
            AdjustDown(0);
            return this;
        }

        public override Heap Insert(int value)
        {
            int[] newData = new int[length + 1];
            Array.Copy(data, newData, length);
            newData[length] = value;
            this.data = newData;
            this.length = length + 1;
            AdjustUp(this.length - 1);
            return this;
        }

        public override void AdjustDown(int parentIndex)
        {
            //从最后一个节点的树开始调整
            // n-1   
            int leftChildIndex = GetLeftChildIndex(parentIndex);
            int rightChildIndex = GetRightChildIndex(parentIndex);
            int minIndex = parentIndex;
            if (leftChildIndex < this.length &&  data[leftChildIndex] < data[minIndex])
            {
                minIndex = leftChildIndex;
            }
            if (rightChildIndex < this.length && data[rightChildIndex] < data[minIndex])
            {
                minIndex = rightChildIndex;
            }
            if (minIndex != parentIndex)
            {
                Swap(minIndex, parentIndex);
                //递归保持堆的特性。调整交换过的节点。
                AdjustDown(minIndex);
            }
        }

        public override void AdjustUp(int index)
        {
            int parentIndex = GetParentIndex(index);
            if (parentIndex >= 0 && data[index] < data[parentIndex])
            {
                Swap(index, parentIndex);
                //递归保持堆特性。调整交换过的节点
                AdjustUp(parentIndex);
            }
        }

        static void Main(string[] args)
        {
            int[] data = new int[10];
            Random ran = new Random((new DateTime()).Second);
            for (int i = 0; i != 10; ++i)
            {
                data[i] = ran.Next(1, 1000);
            }

            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("XXXXXXXXXXXXXXXXXX");
            Heap heap = new MinHeap(data);
            heap.BuildHeap().Print();
            Console.WriteLine("XXXXXXXXXXXXXXXXXX");
            heap.Remove().Print();
            Console.WriteLine("XXXXXXXXXXXXXXXXXX");
            heap.Insert(1).Print();

            //heapSort
            Console.WriteLine("XXXXXXXXXXXXXXXXXX");
            int length = heap.length;
            for (int i = 0; i != length; ++i)
            {
                Console.WriteLine(heap.data[0]);
                heap.Remove();
            }
        }
    }
}
