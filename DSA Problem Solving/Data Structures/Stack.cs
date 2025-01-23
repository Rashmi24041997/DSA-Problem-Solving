using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    public class Stack
    {
        private int[] Arr;
        private int top;

        public Stack()
        {
            Arr = new int[1000];
            top = -1;
        }

        public void Push(int value)
        {
            top++;
            if (top > Arr.Length - 1)
            {
                throw new Exception("Stack Overflow");
            }
            Arr[top] = value;
        }

        public int Pop()
        {
            if(top == -1)
            {
                throw new Exception("Stack Underflow");
            }
            int result = Arr[top];
            return result;
        }

        public int Top()
        {
            return top == -1 ? -1: Arr[top];
        }

        public int Size()
        {
            return top + 1;
        }
    }
}
