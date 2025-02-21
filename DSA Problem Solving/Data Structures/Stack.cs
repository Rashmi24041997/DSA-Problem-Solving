using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    public class MyStack<T>
    {
        private int[] Arr;
        private int top;

        public MyStack()
        {
            Arr = new int[10000];
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
            if (top == -1)
            {
                throw new Exception("Stack Underflow");
            }
            int result = Arr[top];
            return result;
        }

        public int Top()
        {
            return top == -1 ? -1 : Arr[top];
        }

        public int Size()
        {
            return top + 1;
        }
    }

    public class StackProblems
    {
        public class Easy
        {
            /*
             Problem: Given a list of integers, find the previous smaller element for each element in the list.
             If there is no smaller element, return -1 for that position.
             Time Complexity: O(n^2)
             Space Complexity: O(n)
             */
            public static List<int> PrevSmallerBf(List<int> A)
            {
                int n = A.Count;
                List<int> ans = new(n) { -1 };

                for (int i = 1; i < n; i++)
                {
                    int low = -1;
                    int num = A[i];
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (num > A[j])
                        {
                            low = A[j];
                            break;
                        }
                    }
                    ans.Add(low);
                }
                return ans;
            }

            /*
             Problem: Given two arrays nums1 and nums2, find the next greater element for each element in nums1 in nums2 using brute force.
             If there is no greater element, return -1 for that position.
             Time Complexity: O(n * m)
             Space Complexity: O(n)
             */
            public static int[] NextGreaterElementBF(int[] nums1, int[] nums2)
            {
                int[] result = new int[nums1.Length];

                for (int i = 0; i < nums1.Length; i++)
                {
                    int val = nums1[i];
                    for (int j = 0; j < nums2.Length; j++)
                    {
                        bool succes = false;
                        if (nums2[j] == val)
                        {
                            for (int k = j + 1; k < nums2.Length; k++)
                            {
                                int ele = nums2[k];
                                if (ele > val)
                                {
                                    result[i] = ele;
                                    succes = true;
                                    break;
                                }
                            }
                            if (!succes)
                            {
                                result[i] = -1;
                            }
                            break;
                        }
                    }
                }
                return result;
            }

            /*
             Problem: Given a stack, sort the elements in ascending order.
             Time Complexity: O(n log n)
             Space Complexity: O(n)
             */
            public static void SortStack(MyStack<int> stack)
            {
                int[] arr = new int[stack.Size()];
                int i = 0;
                while (stack.Top() != -1)
                {
                    arr[i] = stack.Pop();
                    i++;
                }
                Array.Sort(arr);
                for (int j = 0; j < arr.Length; j++)
                {
                    stack.Push(arr[j]);
                }
            }

            /*
             Problem: Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
             An input string is valid if:
             - Open brackets must be closed by the same type of brackets.
             - Open brackets must be closed in the correct order.
             - Every close bracket has a corresponding open bracket of the same type.
             Time Complexity: O(n)
             Space Complexity: O(n)
             */
            public static bool IsValidParenthesis(string s)
            {
                int n = s.Length;
                if (n % 2 != 0) return false;

                char f = s[0], l = s[n - 1];
                if (f == ')' || f == '}' || f == ']' || l == '(' || l == '{' || l == '[') return false;

                System.Collections.Generic.Stack<char> stack = new();
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    char p;
                    char c = s[i];
                    switch (c)
                    {
                        case '(':
                            if (stack.Count < 1 || stack.Pop() != ')')
                                return false;
                            break;
                        case ')':
                            stack.Push(c);
                            break;
                        case '{':
                            if (stack.Count < 1 || stack.Pop() != '}')
                                return false;
                            break;
                        case '}':
                            stack.Push(c);
                            break;
                        case '[':
                            if (stack.Count < 1 || stack.Pop() != ']')
                                return false;
                            break;
                        case ']':
                            stack.Push(c);
                            break;
                    }
                }
                return stack.Count < 1;
            }

            public static List<int> PrevSmallerOpt(List<int> A)
            {
                List<int> pse = new(A.Count);
                Stack<int> st = new();
                for (int i = 0; i < A.Count; i++)
                {
                    int num = A[i];
                    while (st.Count != 0 && st.Peek() >= num)
                    {
                        st.Pop();
                    }
                    pse.Add(st.Count == 0 ? -1 : st.Peek());
                    st.Push(num);
                }
                return pse;
            }
        }

        public class Medium
        {
            /*
             Problem: Given two arrays nums1 and nums2, find the next greater element for each element in nums1 in nums2.
             If there is no greater element, return -1 for that position.
             Time Complexity: O(n * m)
             Space Complexity: O(n)
             */
            public static int[] NextGreaterElement(int[] nums1, int[] nums2)
            {
                int n1 = nums1.Length;
                int n2 = nums2.Length;
                //int[] bkup = new int[n2];
                int[] ans = new int[n1];
                Dictionary<int, int> tbl = new();
                System.Collections.Generic.Stack<int> st = new();
                //st.Push(-1);
                for (int i = n2 - 1; i >= 0; i--)
                {
                    int val = nums2[i];
                    while (st.Count != 0 && st.Peek() <= nums2[i])
                    {
                        st.Pop();
                    }
                    int nge = st.Count != 0 ? st.Peek() : -1;
                    if (!tbl.ContainsKey(val))
                        tbl.Add(val, nge);
                    st.Push(val);
                    //if(!tbl.ContainsKey(val))
                    //    tbl.Add(val, bkup[i]);
                }
                for (int i = 0; i < n1; i++)
                {
                    int num = nums1[i];
                    int val = tbl[num];
                    ans[i] = val;
                }
                return ans;
            }


            /*
             Problem: Implement a stack that supports push, pop, top, and retrieving the minimum element in constant time.
             Time Complexity: O(1) for each operation
             Space Complexity: O(n)
             */
            public class MinStackBF
            {
                private Stack<(int, int)> st = new();
                private int top;
                public int Count => top + 1;
                public bool IsEmpty => top == -1;

                public MinStackBF()
                {
                    top = -1;
                }

                public void Push(int val)
                {
                    top++;
                    if (st.Count == 0)
                        st.Push((val, val));
                    else
                        st.Push((val, Math.Min(val, st.Peek().Item2)));
                }

                public void Pop()
                {
                    if (top == -1)
                        throw new InvalidOperationException("Stack is empty.");
                    st.Pop();
                    top--;
                }

                public int Top()
                {
                    if (top == -1)
                        throw new InvalidOperationException("Stack is empty.");

                    return st.Peek().Item1;
                }

                public int GetMin()
                {
                    return st.Peek().Item2;
                }
            }

            public class MinStack
            {
                // take a variable that stores the minimum number. So whenever a push operation comes in just take that number put it in the stack and update the variable to the number.
                private long min;
                private Stack<long> st;

                public MinStack()
                {
                    st = new();
                    min = long.MaxValue;
                }

                // check whether that number is less than the min number.
                // If it is smaller than min we will push a modified value which is a push(2 * Val - min) into the stack
                // and will update min to the value of the original number. If it’s not then we will just push it as it is.
                public void Push(int val)
                {
                    long cval = val;
                    if (st.Count == 0)
                    {
                        st.Push(cval);
                        min = cval;
                    }
                    else if (cval < min)
                    {
                        long newVal = (2 * cval - min);
                        min = cval;
                        st.Push(newVal);
                    }
                    else
                        st.Push(cval);
                }

                // check if the top value is lesser than min,
                // If it is then we must update our min to its previous value.
                // In order to do that min = (2 * min) - (modified value) and we will pop the element.
                public void Pop()
                {
                    if (st.Count == 0)
                        return;
                    long val = st.Pop();
                    if (val < min)
                        min = 2 * min - val;
                }

                // check if the top value is lesser than min,
                // If it is then it is modified and we will return the min as the top value.
                public int Top()
                {
                    long val = st.Peek();
                    if (val >= min)
                        return (int)val;

                    return (int)min;
                }

                public int GetMin()
                {
                    return (int)min;
                }
            }

            /**
             * Your MinStack object will be instantiated and called as such:
             * MinStack obj = new MinStack();
             * obj.Push(val);
             * obj.Pop();
             * int param_3 = obj.Top();
             * int param_4 = obj.GetMin();
             */

            public static int[] NextGreaterElementsIIBF(int[] nums)
            {
                int n = nums.Length;
                int[] ans = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int num = nums[i];
                    ans[i] = -1;
                    for (global::System.Int32 j = i + 1; j < i + n - 1; j++)
                    {
                        int indx = j % n;
                        if (nums[indx] > num)
                        {
                            ans[i] = nums[indx];
                            break;
                        }
                    }
                }
                return ans;
            }

            public static int[] NextGreaterElementsIIOpt(int[] nums)
            {
                int n = nums.Length;
                int[] ans = new int[n];
                Stack<int> st = new Stack<int>();

                for (int i = 2 * n - 1; i >= 0; i--)
                {
                    int indx = i % n;
                    int num = nums[indx];

                    while (st.Count != 0 && st.Peek() <= num)
                        st.Pop();

                    ans[i] = st.Count == 0 ? -1 : st.Peek();
                    st.Push(num);
                }
                return ans;
            }


            public int SumSubarrayMinsBF(int[] arr)
            {
                int n = arr.Length;
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    int min = arr[i];
                    sum += min;
                    for (global::System.Int32 j = i; j < n; j++)
                    {
                        min = Math.Min(min, arr[j]);
                        sum += min;
                    }
                }
                return (int)(sum % (Math.Pow(10.0, 9.0) + 7));
            }


        }
    }
}
}

