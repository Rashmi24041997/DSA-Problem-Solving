using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures;
/**
* Definition for a binary tree node.
*/
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTreeProblems
{
    public class Easy
    {
        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> lst = new List<int>();
            InorderTraversalHelper(root, lst);
            return lst;
        }

        public static void InorderTraversalHelper(TreeNode root, IList<int> lst)
        {
            if (root is null)
                return;

            InorderTraversalHelper(root.left, lst);

            lst.Add(root.val);

            InorderTraversalHelper(root.right, lst);
        }

        public static IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> lst = new List<int>();
            PreorderTraversalHelper(root, lst);
            return lst;
        }
        public static void PreorderTraversalHelper(TreeNode root, IList<int> lst)
        {
            if (root is null)
                return;

            lst.Add(root.val);

            PreorderTraversalHelper(root.left, lst);

            PreorderTraversalHelper(root.right, lst);
        }

        public static IList<int> MorrisInorderTraversal(TreeNode root)
        {

            IList<int> lst = new List<int>();
            TreeNode cur = root;
            while (cur != null)
            {
                lst.Add(cur.val);
                if (cur.left == null)
                {
                    cur = cur.right;
                }
                else
                {
                    TreeNode prev = cur.left;

                    while (prev.right != null && prev.right != cur)
                    {
                        prev = prev.right;
                    }
                    if (prev.right == null)
                    {
                        prev.right = cur;
                        cur = cur.left;
                    }
                    else
                    {
                        prev.right = null;
                        //lst.Add(cur.val);
                        cur = cur.right;
                    }
                }
            }
            return lst;
        }

        public static List<int> leftView(TreeNode root)
        {
            List<int> lst = new();
            leftViewHelper(root, lst, 0);
            return lst;
        }
        public static void leftViewHelper(TreeNode root, List<int> lst, int level)
        {
            if (root is null) return;
            if (lst.Count == level) lst.Add(root.val);
            leftViewHelper(root.left, lst, ++level);
            leftViewHelper(root.right, lst, ++level);
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Queue<TreeNode> que = new();

            que.Enqueue(root);

            while (que.Count != 0)
            {
                int cnt = que.Count;
                List<int> lvlNods = new();

                for (int i = 0; i < cnt; i++)
                {
                    TreeNode lvlNod = que.Dequeue();
                    lvlNods.Add(lvlNod.val);
                    if (lvlNod.left != null)
                        que.Enqueue(lvlNod.left);
                    if (lvlNod.right != null)
                        que.Enqueue(lvlNod.right);
                }
                ans.Add(lvlNods);
            }
            return ans;
        }
        /*
         257. Binary Tree Paths
            Given the root of a binary tree, return all root-to-leaf paths in any order.

            A leaf is a node with no children.
         */
        public static List<List<int>> Paths(TreeNode root)
        {
            List<List<int>> ans = new();
            PathsHelper(root, ans, new List<int>());
            return ans;
        }

        private static void PathsHelper(TreeNode root, List<List<int>> ans, List<int> list)
        {
            list.Add(root.val);
            if (root.left is null && root.right is null)
                ans.Add(new List<int>(list));
            else
            {
                if (root.left is not null)
                    PathsHelper(root.left, ans, list);
                if (root.right is not null)
                    PathsHelper(root.right, ans, list);
            }
            list.RemoveAt(list.Count - 1);
        }
        /*
         104. Maximum Depth of Binary Tree
            Given the root of a binary tree, return its maximum depth.
            
            A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
         */
        public static int MaxDepth(TreeNode root)
        {
            int cnt = 0;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            cnt++;
            while (que.Count > 0)
            {
                int qCnt = que.Count;
                for (global::System.Int32 i = 0; i < qCnt; i++)
                {
                    TreeNode nod = que.Dequeue();
                    if (nod.left is not null)
                        que.Enqueue(nod.left);
                    if (nod.right is not null)
                        que.Enqueue(nod.right);
                }
                if (que.Count > 0)
                    cnt++;
            }
            return cnt;
        }

        public static int MaxDepthOpt(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }

            var left = MaxDepth(root.left);
            var right = MaxDepth(root.right);

            return 1 + Math.Max(left, right);
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int max = int.MinValue;
            DiameterOfBinaryTree(root, ref max);
            return max - 1;
        }
        private static int DiameterOfBinaryTree(TreeNode root, ref int max)
        {
            if (root is null) return 0;

            int leftMax = DiameterOfBinaryTree(root.left, ref max);
            int rightMax = DiameterOfBinaryTree(root.right, ref max);
            max = Math.Max(leftMax + rightMax + 1, max);
            return Math.Max(leftMax, rightMax) + 1;
        }


        // Function to build a binary tree
        // from preorder and inorder traversals
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {

            // Create a map to store indices
            // of elements in the inorder traversal
            Dictionary<int, int> inMap = new();

            // Populate the map with indices
            // of elements in the inorder traversal
            for (int i = 0; i < inorder.Length; i++)
            {
                inMap.Add(inorder[i], i);
            }
            // Call the private helper function
            // to recursively build the tree
            return BuildTree(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1, inMap);
        }

        // Recursive helper function to build the tree
        private static TreeNode BuildTree(int[] preorder, int[] inorder, int preStrt, int preEnd, int inStrt, int inEnd, Dictionary<int, int> inMap)
        {
            // Base case: If the start indices
            // exceed the end indices, return null
            if (preStrt > preEnd || inStrt > inEnd)
                return null;

            // Create a new TreeNode with value
            // at the current preorder index
            TreeNode root = new(preorder[preStrt]);

            // Find the index of the current root
            // value in the inorder traversal
            int indx = inMap[root.val];

            // Calculate the number of
            // elements in the left subtree
            int numsLeft = indx - inStrt;

            // Recursively build the left subtree
            root.left = BuildTree(preorder, inorder, preStrt + 1, preStrt + numsLeft, inStrt, indx - 1, inMap);

            // Recursively build the right subtree
            root.right = BuildTree(preorder, inorder, preStrt + numsLeft + 1, preEnd, indx + 1, inEnd, inMap);

            // Return the current root node
            return root;
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            bool isSame = true;
            IsSameTreeHelper(p, q, ref isSame);
            return isSame;
        }

        private static void IsSameTreeHelper(TreeNode p, TreeNode q, ref bool isSame)
        {
            if (!isSame) return;
            if (p is null && q is null)
                return;
            if (p is null ^ q is null)
            {
                isSame = false;
                return;
            }
            if (p.val != q.val)
            {
                isSame = false;
                return;
            }
            IsSameTreeHelper(p.left, q.left, ref isSame);
            IsSameTreeHelper(p.right, q.right, ref isSame);
        }


    }
    public class Medium
    {
        public static bool IsBalanced(TreeNode root)
        {
            // Check if the tree's height difference
            // between subtrees is less than 2
            // If not, return false; otherwise, return true
            return DfsHeight(root) != -1;
        }

        // Recursive function to calculate
        // the height of the tree
        public static int DfsHeight(TreeNode root)
        {
            // Base case: if the current node is NULL,
            // return 0 (height of an empty tree)
            if (root == null) return 0;

            // Recursively calculate the
            // height of the left subtree
            int leftHeight = DfsHeight(root.left);

            // If the left subtree is unbalanced,
            // propagate the unbalance status
            if (leftHeight == -1)
                return -1;

            // Recursively calculate the
            // height of the right subtree
            int rightHeight = DfsHeight(root.right);

            // If the right subtree is unbalanced,
            // propagate the unbalance status
            if (rightHeight == -1)
                return -1;

            // Check if the difference in height between
            // left and right subtrees is greater than 1
            // If it's greater, the tree is unbalanced,
            // return -1 to propagate the unbalance status
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            // Return the maximum height of left and
            // right subtrees, adding 1 for the current node
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static List<int> BottomView(TreeNode root)
        {
            List<int> lst = new();
            // Code here
            if (root is null) return lst;

            SortedDictionary<int, int> pairs = new();
            Queue<(TreeNode, int)> que = new();

            que.Enqueue((root, 0));
            while (que.Count > 0)
            {
                int cnt = que.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var item = que.Dequeue();
                    TreeNode nod = item.Item1;
                    int level = item.Item2;
                    if (!pairs.ContainsKey(level))
                        pairs.Add(level, nod.val);
                    else
                        pairs[level] = nod.val;
                    if (nod.left is not null)
                        que.Enqueue((nod.left, level - 1));
                    if (nod.right is not null)
                        que.Enqueue((nod.right, level + 1));
                }
            }
            return pairs.Values.ToList();
        }

        public static List<int> TopView(TreeNode root)
        {
            if (root is null) return new List<int>();

            Queue<(TreeNode, int)> que = new Queue<(TreeNode, int)>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();

            que.Enqueue((root, 0));
            while (que.Count > 0)
            {
                int cnt = que.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var pair = que.Dequeue();
                    TreeNode nod = pair.Item1;
                    int lvl = pair.Item2;
                    if (!map.ContainsKey(lvl))
                        map.Add(lvl, nod.val);
                    if (nod.left != null)
                        que.Enqueue((nod.left, lvl - 1));
                    if (nod.right != null)
                        que.Enqueue((nod.right, lvl + 1));
                }
            }
            return map.Values.ToList();
        }

        public static List<List<int>> GetTreeTraversal(TreeNode root)
        {
            // Write your code here.
            List<int> pre = new();
            List<int> @in = new();
            List<int> post = new();
            GetTreeTraversal(root, pre, @in, post);
            return new List<List<int>>() { pre, @in, post };
        }
        private static void GetTreeTraversal(TreeNode root, List<int> pre, List<int> @in, List<int> post)
        {
            if (root is null) return;

            @in.Add(root.val);
            GetTreeTraversal(root.left, pre, @in, post);
            pre.Add(root.val);
            GetTreeTraversal(root.right, pre, @in, post);
            post.Add(root.val);
        }

        public static int WidthOfBinaryTree(TreeNode root)
        {
            Queue<(TreeNode, int)> que = new();

            int ans = 0;
            que.Enqueue((root, 1));
            while (que.Count > 0)
            {
                int cnt = que.Count;
                int fst = 0, last = 0;
                for (int i = 0; i < cnt; i++)
                {
                    var pair = que.Dequeue();
                    TreeNode nod = pair.Item1;
                    int indx = pair.Item2 * 2;

                    if (i == 0) fst = pair.Item2;
                    if (i == cnt - 1) last = pair.Item2;

                    if (nod.left is not null)
                        que.Enqueue((nod.left, indx));
                    if (nod.right is not null)
                        que.Enqueue((nod.right, indx + 1));
                }
                ans = Math.Max(ans, last - fst);
            }
            return ans + 1;
        }
        /*662. Maximum Width of Binary Tree
        Given the root of a binary tree, return the maximum width of the given tree.

        The maximum width of a tree is the maximum width among all levels.*/
        public static int WidthOfBinaryTreeOpt(TreeNode root)
        {
            if (root == null) return 0;
            List<int> leftNodes = new List<int>();
            int MaxWidth = 1;
            void DFS(TreeNode node, int level, int pos)
            {
                if (leftNodes.Count == level) leftNodes.Add(pos);
                if (node.left != null) DFS(node.left, level + 1, 2 * pos);
                if (node.right != null) DFS(node.right, level + 1, 2 * pos + 1);
                MaxWidth = Math.Max(pos - leftNodes[level] + 1, MaxWidth);
            }
            DFS(root, 0, 0);
            return MaxWidth;
        }
    }

    public static class Hard
    {
        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            Queue<(TreeNode, int, int)> que = new Queue<(TreeNode, int, int)>();
            SortedDictionary<int, SortedDictionary<int, List<int>>> map = new();
            IList<IList<int>> ans = new List<IList<int>>();

            que.Enqueue((root, 0, 0));
            while (que.Count > 0)
            {
                int cnt = que.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var pair = que.Dequeue();

                    TreeNode nod = pair.Item1;
                    int vLvl = pair.Item2;
                    int hLvl = pair.Item3;

                    map.TryAdd(vLvl, new SortedDictionary<int, List<int>>());
                    map[vLvl].TryAdd(hLvl, new List<int>());
                    map[vLvl][hLvl].Add(nod.val);

                    if (nod.left != null)
                        que.Enqueue((nod.left, vLvl - 1, hLvl + 1));
                    if (nod.right != null)
                        que.Enqueue((nod.right, vLvl + 1, hLvl + 1));
                }
            }
            foreach (var item in map.Values)
            {
                List<int> vals = new();
                foreach (var lst in item.Values)
                {
                    lst.Sort();
                    lst.ForEach(i => vals.Add(i));
                }
                ans.Add(vals);
            }
            return ans;
        }
        /*
         124. Binary Tree Maximum Path Sum
            A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.

            The path sum of a path is the sum of the node's values in the path.

            Given the root of a binary tree, return the maximum path sum of any non-empty path.
         */

        public static int MaxPathSum(TreeNode root)
        {
            int maxSum = 0, curMax = 0;
            MaxPathSumHelper(root, ref maxSum);
            return maxSum;
        }

        private static int MaxPathSumHelper(TreeNode root, ref int maxSum)
        {
            if (root is null)
                return 0;
            int leftSum = MaxPathSumHelper(root.left, ref maxSum);
            int rightSum = MaxPathSumHelper(root.right, ref maxSum);
            maxSum = Math.Max(maxSum, leftSum + rightSum + root.val);
            return Math.Max(leftSum, rightSum) + root.val;
        }

    }
}


