using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    public class Queue
    {
        private int[] arr;
        private int start, end, currSize, maxSize;

        public Queue()
        {
            arr = new int[100005];
            start = -1;
            end = -1;
            currSize = 0;
            maxSize = 100005;
        }

        public Queue(int maxSize)
        {
            this.maxSize = maxSize;
            arr = new int[maxSize];
            start = -1;
            end = -1;
            currSize = 0;
        }

        public void push(int newElement)
        {
            if (currSize == maxSize)
            {
                throw new Exception("Queue is full\nExiting...");
            }
            if (end == -1)
            {
                start = 0;
                end = 0;
            }
            else
                end = (end + 1) % maxSize;
            arr[end] = newElement;
            currSize++;
        }

        public int pop()
        {
            if (start == -1)
            {
                throw new Exception("Queue Empty\nExiting...");
            }
            int popped = arr[start];
            if (currSize == 1)
            {
                start = -1;
                end = -1;
            }
            else
                start = (start + 1) % maxSize;
            currSize--;
            return popped;
        }

        public int top()
        {
            if (start == -1)
            {
                throw new Exception("Queue is Empty");
            }
            return arr[start];
        }

        public int size()
        {
            return currSize;
        }
    }

    public class MyQueueUsing2Stack
    {
        Stack<int> st1, st2;
        int count = 0;
        public MyQueueUsing2Stack()
        {
            st1 = new();
            st2 = new();
        }

        public void Push(int x)
        {
            st1.Push(x);
            st2 = new Stack<int>(st1);
            count++;
        }

        public int Pop()
        {
            if (count == 0) return -1;
            int val = st2.Pop();
            st1 = new Stack<int>(st2);
            count--;
            return val;
        }

        public int Peek()
        {
            return st2.Peek();
        }

        public bool Empty()
        {
            return st2.Count == 0;
        }
    }

    public class MyQueueUsing2stackBtr
    {
        Stack<int> st1, st2;
        int count = 0;
        int front = 0, rear = 0;
        public MyQueueUsing2stackBtr()
        {
            st1 = new();
            st2 = new();
        }

        public void Push(int x)
        {
            while (st1.Count > 0)
            {
                st2.Push(st1.Pop());
            }
            st1.Push(x);
            while (st2.Count > 0)
            {
                st1.Push(st2.Pop());
            }
            front = front == 0 ? x : front;
            rear = x;
            count++;
        }

        public int Pop()
        {
            if (count == 0) return -1;
            int val = st1.Pop();
            front = val;
            count--;
            return val;
        }

        public int Peek()
        {
            return st1.Peek();
        }

        public bool Empty()
        {
            return count == 0;
        }
    }


    public class MyQueueUsing2stackOpt
    {
        Stack<int> st1, st2;
        int count = 0;
        int front = -1, rear = 0;
        public MyQueueUsing2stackOpt()
        {
            st1 = new();
            st2 = new();
        }

        public void Push(int x)
        {
            st1.Push(x);
            front = front == 0 ? x : front;
            rear = x;
            count++;
        }

        public int Pop()
        {
            if (count == 0) return -1;
            if (st2.Count == 0)
            {
                while (st1.Count > 0)
                {
                    st2.Push(st1.Pop());
                }
            }
            int val = st2.Pop();
            front = st2.Count > 0 ? st2.Peek() : st1.Count > 0 ? st1.Peek() : -1;
            count--;
            return val;
        }

        public int Peek()
        {
            return front;
        }

        public bool Empty()
        {
            return count == 0;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}
