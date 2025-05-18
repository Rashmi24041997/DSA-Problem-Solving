using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    public class MaxHeap
    {
        List<int> heap = new();

        public int Count => heap.Count;

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty");

            return heap[0];
        }

        public bool IsEmpty() => heap.Count == 0;

        public void Clear() => heap.Clear();

        public bool Contains(int value) => heap.Contains(value);

        public int[] ToArray() => heap.ToArray();
        
        public void Insert(int value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (heap[index] > heap[parent])
                {
                    (heap[index], heap[parent]) = (heap[parent], heap[index]);
                    index = parent;
                }
            }
        }

        private void HeapifyDown(int parent)
        {
            int heapCount = heap.Count;
            while (parent < heapCount)
            {
                int left = 2 * parent + 1;
                int right = 2 * parent + 2;
                int largest = parent;

                if (left < heapCount && heap[left] > heap[largest])
                    largest = left; ;
                if (right < heapCount && heap[right] > heap[largest])
                    largest = right;

                if (largest == parent) break;

                (heap[largest], heap[parent]) = (heap[parent], heap[largest]);
                parent = largest;
            }
        }

        public int ExtractMax()
        {
            if (IsEmpty()) throw new InvalidOperationException("Heap is empty");

            int max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return max;
        }

    }
    public class MinHeap
    {
        List<int> heap = new();

        public void Insert(int value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        public int ExtractMin()
        {
            int min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return min;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (heap[index] < heap[parent])
                {
                    (heap[index], heap[parent]) = (heap[parent], heap[index]);
                    index = parent;
                }
            }
        }

        private void HeapifyDown(int parent)
        {
            int heapCount = heap.Count;
            while (parent < heapCount)
            {
                int left = 2 * parent + 1;
                int right = 2 * parent + 2;
                int smallest = parent;

                if (left < heapCount && heap[left] < heap[smallest])
                    smallest = left;
                if (right < heapCount && heap[right] < heap[smallest])
                    smallest = right;

                if (smallest == parent) break;

                (heap[smallest], heap[parent]) = (heap[parent], heap[smallest]);
                parent = smallest;
            }
        }

        public int Count => heap.Count;

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty");

            return heap[0];
        }

        public bool IsEmpty() => heap.Count == 0;

        public void Clear() => heap.Clear();

        public bool Contains(int value) => heap.Contains(value);

        public int[] ToArray() => heap.ToArray();

    }
    public static class HeapProblems
    {
        public static class EasyHP
        {
            public static void Method()
            { }
        }
        public static class Medium
        {
        }
        public static class Hard
        {
        }
    }
}
