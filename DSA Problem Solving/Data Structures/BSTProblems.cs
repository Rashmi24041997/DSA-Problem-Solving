using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures;

public static class BSTProblems
{
    public static class Easy
    {
        public static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root is null) return null;
            if (root.val == val) return root;

            if (root.val > val)
                return SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);
        }

        // Function to find the minimum element in the given BST.
        public static int minValue(TreeNode root)
        {
            if (root == null) return -1;
            int min = int.MaxValue;
            TreeNode temp = root;
            while (temp.left != null)
            {
                temp = temp.left;
            }
            min = Math.Min(temp.val, min);
            return min;
        }
    }
    public static class Medium
    {
        public static int KthSmallest(TreeNode root, int k)
        {
            int ans = -1;
            if (root is null) return ans;
            int temp = k;
            KthSmallestHelper(root, ref temp, ref ans);
            return ans;
        }

        private static void KthSmallestHelper(TreeNode root, ref int temp, ref int ans)
        {
            if (root == null || ans > -1)
                return;
            KthSmallestHelper(root.left, ref temp, ref ans);
            temp--;
            if (temp == 0)
            {
                ans = root.val;
                return;
            }
            KthSmallestHelper(root.right, ref temp, ref ans);
        }

        /*
         1008. Construct Binary Search Tree from Preorder Traversal
            Given an array of integers preorder, which represents the preorder traversal of a BST (i.e., binary search tree), construct the tree and return its root.
         */
        public static TreeNode? BstFromPreorderBF(int[] preorder)
        {
            Dictionary<int, int> preMap = new();
            for (int i = 0; i < preorder.Length; i++)
            {
                preMap.Add(preorder[i], i);
            }
            return BstFromPreorderBF(preorder, 0, preorder.Length - 1, preMap);
        }

        private static TreeNode? BstFromPreorderBF(int[] preorder, int strt, int end, Dictionary<int, int> preMap)
        {
            if (strt > end)
                return null;
            int num = preorder[strt];
            TreeNode root = new TreeNode(num);
            if (strt == end)
                return root;
            int leftStrt = preMap[num] - 1, rightStrt = preMap[num] + 1;
            int left = 0;
            foreach (KeyValuePair<int, int> item in preMap)
            {
                if (item.Value >= strt && item.Value <= end)
                {
                    if (left == 0 && item.Key < num)
                    {
                        left = item.Key;
                        leftStrt = item.Value;
                    }
                    if (rightStrt == 0 && item.Key > num)
                        rightStrt = item.Value;
                }
                if (left > 0 && rightStrt > 0)
                    break;
            }
            int leftEnd = rightStrt - 1;
            int rightEnd = end;
            root.left = BstFromPreorderBF(preorder, leftStrt, leftEnd, preMap);
            root.right = BstFromPreorderBF(preorder, rightStrt, rightEnd, preMap);
            return root;
        }

        public static TreeNode? BstFromPreorderBtr(int[] preorder)
        {
            int n = preorder.Length;
            Dictionary<int, int> inMap = new();
            int[] inOrder = new int[n];
            preorder.CopyTo(inOrder, 0);
            Array.Sort(inOrder);
            for (int i = 0; i < n; i++)
            {
                inMap.Add(inOrder[i], i);
            }
            TreeNode? root = BstFromPreorderBtr(preorder, inOrder, 0, n - 1, 0, n - 1, inMap);
            return root;
        }

        private static TreeNode? BstFromPreorderBtr(int[] preorder, int[] inOrder, int preStrt, int preEnd, int inStrt, int inEnd, Dictionary<int, int> inMap)
        {
            if (preEnd < preStrt || inEnd < inStrt)
                return null;
            int num = preorder[preStrt];
            TreeNode root = new TreeNode(num);
            int indx = inMap[num];
            int leftCount = indx - inStrt;
            root.left = BstFromPreorderBtr(preorder, inOrder, preStrt + 1, preStrt + leftCount, inStrt, indx - 1, inMap);
            root.right = BstFromPreorderBtr(preorder, inOrder, preStrt + leftCount + 1, preEnd, indx + 1, inEnd, inMap);
            return root;
        }
        public static TreeNode? BstFromPreorderOpt(int[] preorder)
        {
            int indx = 0;
            TreeNode root = BstFromPreorderOpt(preorder, preorder.Length, long.MaxValue, ref indx);
            return root;
        }

        public static TreeNode? BstFromPreorderOpt(int[] preorder, int len, long bound, ref int indx)
        {
            if (indx == len || preorder[indx] > bound)
                return null;
            TreeNode root = new(preorder[indx]);
            indx++;
            root.left = BstFromPreorderOpt(preorder, len, root.val, ref indx);
            root.right = BstFromPreorderOpt(preorder, len, bound, ref indx);
            return root;
        }

        public static bool IsValidBST(TreeNode root)
        {
            if (root is null)
                return true;

            bool isBST = IsValidBST(root, long.MinValue, long.MaxValue);
            return isBST;
        }
        /// <summary>
        /// let's set the limits in which each nod value should be.
        /// if any nod exceeds either of the UB or LB, tree is not BST.
        /// </summary>
        private static bool IsValidBST(TreeNode? root, long min, long max)
        {
            if (root is null)
                return true;
            if (root.val < min || root.val > max)
                return false;
            bool left = IsValidBST(root.left, min, root.val - 1);
            bool right = IsValidBST(root.right, root.val + 1, max);
            return left && right;
        }
    }
}

