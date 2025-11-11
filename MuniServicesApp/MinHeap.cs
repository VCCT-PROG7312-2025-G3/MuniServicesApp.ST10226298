using System;
using System.Collections.Generic;

namespace MuniServicesApp.DataStructures
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public int Count => heap.Count;

        public MinHeap()
        {
            heap = new List<T>();
        }

        public void Insert(T item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public T ExtractMin()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            T min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return min;
        }

        public T Peek()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }
            return heap[0];
        }

        public bool Contains(T item)
        {
            return heap.Contains(item);
        }

        public List<T> ToList()
        {
            return new List<T>(heap);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                {
                    break;
                }

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int smallest = index;

                if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
                {
                    smallest = leftChild;
                }

                if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
                {
                    smallest = rightChild;
                }

                if (smallest == index)
                {
                    break;
                }

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public void Clear()
        {
            heap.Clear();
        }
    }
}
