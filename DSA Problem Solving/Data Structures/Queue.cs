﻿using System;
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
            arr = new int[32];
            start = -1;
            end = -1;
            currSize = 0;
            maxSize = 32;
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
}
