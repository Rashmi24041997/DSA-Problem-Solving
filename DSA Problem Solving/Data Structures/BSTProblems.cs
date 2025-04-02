using DSA_Problem_Solving.Easy.Binary_Tree;
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

        public static int FindCeil(TreeNode node, int x)
        {
            int ans = -1;
            while (node != null)
            {
                if (node.val == x)
                {
                    return x;
                }
                if (node.val < x)
                    node = node.right;
                else
                {
                    ans = node.val;
                    node = node.left;
                }
            }
            return ans;
        }
        public static int KthGreatest(TreeNode? root, int k)
        {
            int temp = k, ans = -1;
            KthGreatestHelper(root, ref temp, ref ans);
            return ans;
        }

        private static void KthGreatestHelper(TreeNode? root, ref int temp, ref int ans)
        {
            if (root is null || temp == 0)
                return;
            KthGreatestHelper(root.right, ref temp, ref ans);
            temp--;
            if (temp == 0)
            {
                ans = root.val;
                return;
            }
            KthGreatestHelper(root.left, ref temp, ref ans);
        }


        public static bool FindTargetBF(TreeNode root, int k)
        {
            if (root is null)
                return false;
            List<int> inOrder = new();
            InOrder(root, inOrder);
            int i = 0, j = inOrder.Count - 1;
            while (i <= j)
            {
                int sum = inOrder[i] + inOrder[j];
                if (sum == k)
                    return true;
                if (sum > k) j--;
                else i++;
            }
            return false;
        }

        public static void InOrder(TreeNode? root, List<int> inOrder)
        {
            if (root is null)
                return;
            InOrder(root.left, inOrder);
            inOrder.Add(root.val);
            InOrder(root.right, inOrder);
        }
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

        private static void KthSmallestHelper(TreeNode? root, ref int temp, ref int ans)
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
            // Base case: if the start index is greater than the end index, return null (no tree to construct)
            if (strt > end)
                return null;

            // Get the current root value from the preorder array using the start index
            int num = preorder[strt];

            // Create a new TreeNode with the current root value
            TreeNode root = new TreeNode(num);

            // If the start index is equal to the end index, return the root (single node tree)
            if (strt == end)
                return root;

            // Initialize the left and right subtree start indices
            int leftStrt = preMap[num] - 1, rightStrt = preMap[num] + 1;

            // Initialize a variable to track the left subtree root value
            int left = 0;

            // Iterate through the preMap to find the correct indices for left and right subtrees
            foreach (KeyValuePair<int, int> item in preMap)
            {
                // Check if the current item index is within the range of start and end indices
                if (item.Value >= strt && item.Value <= end)
                {
                    // If left is not set and the current item key is less than the root value, set left and leftStrt
                    if (left == 0 && item.Key < num)
                    {
                        left = item.Key;
                        leftStrt = item.Value;
                    }
                    // If rightStrt is not set and the current item key is greater than the root value, set rightStrt
                    if (rightStrt == 0 && item.Key > num)
                        rightStrt = item.Value;
                }
                // If both left and rightStrt are set, break the loop
                if (left > 0 && rightStrt > 0)
                    break;
            }

            // Calculate the end index for the left subtree
            int leftEnd = rightStrt - 1;

            // The end index for the right subtree is the same as the original end index
            int rightEnd = end;

            // Recursively construct the left subtree
            root.left = BstFromPreorderBF(preorder, leftStrt, leftEnd, preMap);

            // Recursively construct the right subtree
            root.right = BstFromPreorderBF(preorder, rightStrt, rightEnd, preMap);

            // Return the constructed root node
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
            // If the current index is equal to the length of the preorder array or the current value exceeds the bound, return null.
            if (indx == len || preorder[indx] > bound)
                return null;

            // Create a new TreeNode with the current value from the preorder array.
            TreeNode root = new(preorder[indx]);

            // Increment the index to move to the next value in the preorder array.
            indx++;

            // Recursively construct the left subtree with the current value as the new bound.
            root.left = BstFromPreorderOpt(preorder, len, root.val, ref indx);

            // Recursively construct the right subtree with the original bound.
            root.right = BstFromPreorderOpt(preorder, len, bound, ref indx);

            // Return the constructed root node.
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


        //173. Binary Search Tree Iterator
        public class BSTIteratorBF
        {
            List<int> inOrder;
            int currIndx = 0;
            public BSTIteratorBF(TreeNode root)
            {
                InOrder(root, inOrder);
            }

            private static void InOrder(TreeNode? root, List<int> inOrder)
            {
                if (root is null)
                    return;
                InOrder(root.left, inOrder);
                inOrder.Add(root.val);
                InOrder(root.right, inOrder);
            }
            public int Next()
            {
                return inOrder[currIndx++];
            }

            public bool HasNext()
            {
                return currIndx > -1 && currIndx < inOrder.Count;
            }
        }

        public class BSTIterator
        {
            Stack<TreeNode> InOrder;
            bool Reverse;
            public BSTIterator(TreeNode root)
            {
                InOrder = new();
                PushNodes(root, InOrder, false);
            }
            public BSTIterator(TreeNode root, bool reverse)
            {
                Reverse = reverse;
                InOrder = new();
                PushNodes(root, InOrder, reverse);
            }

            private static void PushNodes(TreeNode? root, Stack<TreeNode> inOrder, bool reverse)
            {
                while (root is not null)
                {
                    inOrder.Push(root);
                    root = reverse ? root.right : root.left;
                }
            }

            public int Next()
            {
                TreeNode nod = InOrder.Pop();
                PushNodes(Reverse ? nod.left : nod.right, InOrder, Reverse);
                return nod.val;
            }

            public bool HasNext()
            {
                return InOrder.Count != 0;
            }
        }

        public static bool FindTarget(TreeNode root, int k)
        {
            BSTIterator bstLeft = new(root);
            BSTIterator bstRight = new(root, true);

            int left = bstLeft.Next();
            int right = bstRight.Next();
            int sum = left + right;
            while (left < right)
            {
                if (sum == k)
                    return true;
                if (sum < k)
                    left = bstLeft.Next();
                else
                    right = bstRight.Next();
                sum = left + right;
            }
            return false;
        }

    }
}

