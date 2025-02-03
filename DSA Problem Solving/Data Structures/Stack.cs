using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    public class Stack<T>
    {
        private int[] Arr;
        private int top;

        public Stack()
        {
            Arr = new int[100];
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
            public static List<int> PrevSmaller(List<int> A)
            {
                int n = A.Count;
                List<int> ans = new(n) { -1 };

                for (int i = 1; i < n; i++)
                {
                    int low = -1;
                    int num = A[i];
                    for (int j = i - 1; j >=0; j--)
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
            public static int[] NextGreaterElement(int[] nums1, int[] nums2)
            {
                int[] ans = new int[5];
                Dictionary<int, int> tbl = new Dictionary<int, int>();
                int[] result = new int[nums1.Length];
                for (int i = 0; i < nums1.Length; i++)
                {
                    tbl.Add(nums1[i], i);
                }

                for (int i = 0; i < nums2.Length; i++)
                {
                    int val = nums2[i];
                    if (tbl.ContainsKey(val))
                    {
                        tbl.TryGetValue(val, out int indx);
                        if (i == nums2.Length - 1 || nums2[i + 1] <= val)
                        {
                            result[indx] = -1;
                        }
                        else
                            result[indx] = nums2[i + 1];
                    }
                }
                return result;
            }

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

            public static void SortStack(DSA_Problem_Solving.Data_Structures.Stack<int> stack)
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

        }
    }
}
