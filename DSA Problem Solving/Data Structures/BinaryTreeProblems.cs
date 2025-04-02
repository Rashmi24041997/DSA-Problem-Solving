using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
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
        /*
         94. Binary Tree Morris Inorder Traversal
             Given the root of a binary tree, return the inorder traversal of its nodes' values.
         */
        public static IList<int> MorrisInorderTraversal(TreeNode root)
        {
            // Initialize the list to store the inorder traversal
            IList<int> lst = new List<int>();

            // Start with the root node
            TreeNode cur = root;

            // Continue until there are no more nodes to process
            while (cur != null)
            {
                // If there is no left child, visit the current node and move to the right child
                if (cur.left == null)
                {
                    lst.Add(cur.val);
                    cur = cur.right;
                }
                else
                {
                    // Find the inorder predecessor of the current node
                    TreeNode prev = cur.left;
                    while (prev.right != null && prev.right != cur)
                    {
                        prev = prev.right;
                    }
                    // If the right child of the predecessor is null, establish a temporary link to the current node
                    if (prev.right == null)
                    {
                        prev.right = cur;
                        cur = cur.left;
                    }
                    else
                    {
                        // If the right child of the predecessor is the current node, remove the temporary link and visit the current node
                        prev.right = null;
                        lst.Add(cur.val);
                        cur = cur.right;
                    }
                }
            }
            // Return the inorder traversal list
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
            // Initialize the depth counter
            int cnt = 0;
            // Initialize a queue to perform level order traversal
            Queue<TreeNode> que = new Queue<TreeNode>();
            // Enqueue the root node
            que.Enqueue(root);
            // Increment the depth counter
            cnt++;
            // Continue traversal until the queue is empty
            while (que.Count > 0)
            {
                // Get the number of nodes at the current level
                int qCnt = que.Count;
                // Traverse all nodes at the current level
                for (int i = 0; i < qCnt; i++)
                {
                    // Dequeue a node from the front of the queue
                    TreeNode nod = que.Dequeue();
                    // Enqueue the left child if it exists
                    if (nod.left is not null)
                        que.Enqueue(nod.left);
                    // Enqueue the right child if it exists
                    if (nod.right is not null)
                        que.Enqueue(nod.right);
                }
                // Increment the depth counter if there are more nodes to process
                if (que.Count > 0)
                    cnt++;
            }
            // Return the maximum depth
            return cnt;
        }

        public static int MaxDepthOpt(TreeNode root)
        {
            // Base case: if the current node is null, return 0
            if (root == null)
            {
                return 0;
            }

            // Recursively calculate the depth of the left subtree
            var left = MaxDepth(root.left);
            // Recursively calculate the depth of the right subtree
            var right = MaxDepth(root.right);

            // Return the maximum depth between the left and right subtrees, adding 1 for the current node
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

        /*
         100. Same Tree
            Given the roots of two binary trees p and q, write a function to check if they are the same or not.
            
            Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
         */
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

    public static class Medium
    {
        public static bool IsSymmetricBF(TreeNode root)
        {
            Queue<(TreeNode, int)> que = new();

            que.Enqueue((root, 0));
            while (que.Count > 0)
            {
                int cnt = que.Count;
                List<(int, bool)> lstL = new(new (int, bool)[cnt]);
                List<(int, bool)> lstR = new(new (int, bool)[cnt]);

                for (int i = 0; i < cnt; i++)
                {
                    var pair = que.Dequeue();
                    TreeNode nod = pair.Item1;
                    int dir = pair.Item2;
                    int val = nod.val;

                    //if (dir == -1)
                    //    lstL[i] = (val, true);
                    //else if (dir == 1)
                    //    lstR[cnt - i - 1] = (val, true);

                    if (nod.left is not null)
                        que.Enqueue((nod.left, -1));
                    lstL[i] = (nod.left is null ? -101 : nod.left.val, true);

                    if (nod.right is not null)
                        que.Enqueue((nod.right, 1));
                    lstR[cnt - i - 1] = (nod.right is null ? -101 : nod.right.val, true);

                }
                if (lstL.Count != lstR.Count)
                    return false;

                for (int i = 0; i < lstL.Count; i++)
                {
                    if (lstL[i] != lstR[i])
                        return false;
                }
            }
            return true;
        }
        public static bool IsSymmetric(TreeNode root)
        {
            if (root is null) return true;
            return IsMirror(root.left, root.right);
        }

        private static bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 is null && t2 is null) return true;
            if (t1 is null || t2 is null || t1.val != t2.val) return false;

            return IsMirror(t1.left, t2.right) && IsMirror(t1.right, t2.left);
        }

        // Function to build a binary tree
        // from preorder and inorder traversals
        public static TreeNode BuildTreePreIn(int[] preorder, int[] inorder)
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

        public static bool IsBalanced(TreeNode root)
        {
            // Check if the tree's height difference
            // between subtrees is less than 2
            // If not, return false; otherwise, return true
            return DfsHeight(root) != -1;
        }

        // Recursive function to calculate
        // the height of the tree
        private static int DfsHeight(TreeNode root)
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

        /*
         Given a binary tree, return an array where elements represent the bottom view of the binary tree from left to right.

        Note: If there are multiple bottom-most nodes for a horizontal distance from the root, then the latter one in the level traversal is considered. 
         */
        public static List<int> BottomView(TreeNode root)
        {
            // Initialize the list to store the bottom view elements
            List<int> lst = new();

            // Check if the root is null, return the empty list
            if (root is null) return lst;

            // Initialize a sorted dictionary to store the horizontal distance and corresponding node value
            SortedDictionary<int, int> pairs = new();

            // Initialize a queue to perform level order traversal
            Queue<(TreeNode, int)> que = new();

            // Enqueue the root node with initial horizontal distance as 0
            que.Enqueue((root, 0));

            // Continue traversal until the queue is empty
            while (que.Count > 0)
            {
                // Get the number of nodes at the current level
                int cnt = que.Count;

                // Traverse all nodes at the current level
                for (int i = 0; i < cnt; i++)
                {
                    // Dequeue a node from the front of the queue
                    var item = que.Dequeue();

                    // Get the node and its horizontal distance
                    TreeNode nod = item.Item1;
                    int level = item.Item2;

                    // Update the dictionary with the current node's value for the horizontal distance
                    if (!pairs.ContainsKey(level))
                        pairs.Add(level, nod.val);
                    else
                        pairs[level] = nod.val;

                    // Enqueue the left child with updated horizontal distance
                    if (nod.left is not null)
                        que.Enqueue((nod.left, level - 1));

                    // Enqueue the right child with updated horizontal distance
                    if (nod.right is not null)
                        que.Enqueue((nod.right, level + 1));
                }
            }

            // Return the values in the dictionary as a list
            return pairs.Values.ToList();
        }

        /*
         You are given a binary tree, and your task is to return its top view. The top view of a binary tree is the set of nodes visible when the tree is viewed from the top.
         */
        public static List<int> TopView(TreeNode root)
        {
            // Check if the root is null, return an empty list
            if (root is null) return new List<int>();

            // Initialize a queue to perform level order traversal
            Queue<(TreeNode, int)> que = new Queue<(TreeNode, int)>();

            // Initialize a sorted dictionary to store nodes based on their horizontal distance
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();

            // Enqueue the root node with initial horizontal distance as 0
            que.Enqueue((root, 0));

            // Continue traversal until the queue is empty
            while (que.Count > 0)
            {
                // Get the number of nodes at the current level
                int cnt = que.Count;

                // Traverse all nodes at the current level
                for (int i = 0; i < cnt; i++)
                {
                    // Dequeue a node from the front of the queue
                    var pair = que.Dequeue();

                    // Get the node and its horizontal distance
                    TreeNode nod = pair.Item1;
                    int lvl = pair.Item2;

                    // If the horizontal distance is not already in the map, add the node's value
                    if (!map.ContainsKey(lvl))
                        map.Add(lvl, nod.val);

                    // Enqueue the left child with updated horizontal distance
                    if (nod.left != null)
                        que.Enqueue((nod.left, lvl - 1));

                    // Enqueue the right child with updated horizontal distance
                    if (nod.right != null)
                        que.Enqueue((nod.right, lvl + 1));
                }
            }

            // Return the values in the map as a list
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

        /*
            Given the root of a binary tree, return the maximum width of the given tree.

            The maximum width of a tree is the maximum width among all levels.
         */
        public static int WidthOfBinaryTree(TreeNode root)
        {
            // Initialize a queue to perform level order traversal
            Queue<(TreeNode, int)> que = new();

            // Initialize the variable to store the maximum width
            int ans = 0;

            // Enqueue the root node with initial position as 1
            que.Enqueue((root, 1));

            // Continue traversal until the queue is empty
            while (que.Count > 0)
            {
                // Get the number of nodes at the current level
                int cnt = que.Count;

                // Initialize variables to store the first and last positions at the current level
                int fst = 0, last = 0;

                // Traverse all nodes at the current level
                for (int i = 0; i < cnt; i++)
                {
                    // Dequeue a node from the front of the queue
                    var pair = que.Dequeue();

                    // Get the node and its position
                    TreeNode nod = pair.Item1;
                    int indx = pair.Item2 * 2;

                    // Update the first position at the current level
                    if (i == 0) fst = pair.Item2;

                    // Update the last position at the current level
                    if (i == cnt - 1) last = pair.Item2;

                    // Enqueue the left child with updated position
                    if (nod.left is not null)
                        que.Enqueue((nod.left, indx));

                    // Enqueue the right child with updated position
                    if (nod.right is not null)
                        que.Enqueue((nod.right, indx + 1));
                }

                // Update the maximum width
                ans = Math.Max(ans, last - fst);
            }

            // Return the maximum width
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

        /*
         103. Binary Tree Zigzag Level Order Traversal
            Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).
         */
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            // Check if the root is null, return an empty result
            if (root == null)
            {
                return result;
            }

            // Queue to perform level order traversal
            Queue<TreeNode> nodesQueue = new Queue<TreeNode>();
            nodesQueue.Enqueue(root);

            // Flag to determine the direction of traversal (left to right or right to left)
            bool leftToRight = true;

            // Continue traversal until the queue is empty
            while (nodesQueue.Count > 0)
            {
                // Get the number of nodes at the current level
                int size = nodesQueue.Count;

                // List to store the values of nodes at the current level
                List<int> row = new List<int>(new int[size]);

                // Traverse nodes at the current level
                for (int i = 0; i < size; i++)
                {
                    // Get the front node from the queue
                    TreeNode node = nodesQueue.Dequeue();

                    // Determine the index to insert the node's value based on the traversal direction
                    int index = leftToRight ? i : (size - 1 - i);

                    // Insert the node's value at the determined index
                    row[index] = node.val;

                    // Enqueue the left and right children if they exist
                    if (node.left != null)
                    {
                        nodesQueue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        nodesQueue.Enqueue(node.right);
                    }
                }

                // Switch the traversal direction for the next level
                leftToRight = !leftToRight;

                // Add the current level's values to the result list
                result.Add(row);
            }

            // Return the final result of zigzag level order traversal
            return result;
        }
    }

    public static class Hard
    {
        public static TreeNode BuildTreeInNPost(int[] inorder, int[] postorder)
        {
            Dictionary<int, int> inMap = new();
            for (int i = 0; i < inorder.Length; i++)
            {
                inMap.Add(inorder[i], i);
            }

            return BuildTreeInNPost(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1, inMap);
        }

        private static TreeNode BuildTreeInNPost(int[] inOrder, int[] postOrder, int inStrt, int inEnd, int posStrt, int posEnd, Dictionary<int, int> inMap)
        {
            if (inStrt > inEnd || posStrt > posEnd)
                return null;
            int val = postOrder[posEnd];
            TreeNode root = new(val);
            int indx = inMap[val];
            int leftCount = indx - inStrt;
            root.left = BuildTreeInNPost(inOrder, postOrder, inStrt, indx - 1, posStrt, posStrt + leftCount - 1, inMap);
            root.right = BuildTreeInNPost(inOrder, postOrder, indx + 1, inEnd, posStrt + leftCount, posStrt - 1, inMap);
            return root;
        }

        /*
        987. Vertical Order Traversal of a Binary Tree
        Given the root of a binary tree, calculate the vertical order traversal of the binary tree.

        For each node at position (row, col), its left and right children will be at positions (row + 1, col - 1) and (row + 1, col + 1) respectively. The root of the tree is at (0, 0).

        The vertical order traversal of a binary tree is a list of top-to-bottom orderings for each column index starting from the leftmost column and ending on the rightmost column. There may be multiple nodes in the same row and same column. In such a case, sort these nodes by their values.

        Return the vertical order traversal of the binary tree*/
        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            // Initialize a queue to perform level order traversal
            Queue<(TreeNode, int, int)> que = new Queue<(TreeNode, int, int)>();

            // Initialize a sorted dictionary to store nodes based on their vertical and horizontal levels
            SortedDictionary<int, SortedDictionary<int, List<int>>> map = new();

            // Initialize the result list to store the final vertical order traversal
            IList<IList<int>> ans = new List<IList<int>>();

            // Enqueue the root node with initial vertical and horizontal levels as 0
            que.Enqueue((root, 0, 0));

            // Continue traversal until the queue is empty
            while (que.Count > 0)
            {
                // Get the number of nodes at the current level
                int cnt = que.Count;
                // Traverse all nodes at the current level
                for (int i = 0; i < cnt; i++)
                {
                    // Dequeue a node from the front of the queue
                    var pair = que.Dequeue();

                    TreeNode nod = pair.Item1;
                    int vLvl = pair.Item2;
                    int hLvl = pair.Item3;

                    // Add the node to the map based on its vertical and horizontal levels
                    map.TryAdd(vLvl, new SortedDictionary<int, List<int>>());
                    map[vLvl].TryAdd(hLvl, new List<int>());
                    map[vLvl][hLvl].Add(nod.val);

                    // Enqueue the left child with updated vertical and horizontal levels
                    if (nod.left != null)
                        que.Enqueue((nod.left, vLvl - 1, hLvl + 1));
                    // Enqueue the right child with updated vertical and horizontal levels
                    if (nod.right != null)
                        que.Enqueue((nod.right, vLvl + 1, hLvl + 1));
                }
            }
            // Traverse the map to build the final result list
            foreach (var item in map.Values)
            {
                List<int> vals = new();
                foreach (var lst in item.Values)
                {
                    // Sort the nodes at the same position by their values
                    lst.Sort();
                    lst.ForEach(i => vals.Add(i));
                }
                ans.Add(vals);
            }
            // Return the final vertical order traversal
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
            // Recursive function to find the maximum path sum
            // The variable 'maxSum' is a reference parameter
            // updated to store the maximum path sum encountered

            if (root is null)
                return 0;

            // Calculate the maximum path sum for the left and right subtrees
            int leftSum = MaxPathSumHelper(root.left, ref maxSum);
            int rightSum = MaxPathSumHelper(root.right, ref maxSum);

            // Update the overall maximum path sum including the current node
            maxSum = Math.Max(maxSum, leftSum + rightSum + root.val);

            // Return the maximum sum considering only one branch (either left or right)
            // along with the current node
            return Math.Max(leftSum, rightSum) + root.val;
        }


        // Encodes a tree to a single string.
        public static string serialize(TreeNode root)
        {
            if (root == null) return "";

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<string> result = new List<string>();

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                {
                    result.Add("null");
                }
                else
                {
                    result.Add(node.val.ToString());
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }

            return string.Join(",", result);
        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            string[] vals = data.Split(",");
            TreeNode root = new(Convert.ToInt32(vals[0]));
            queue.Enqueue(root);
            for (int i = 1; i < vals.Length; i++)
            {
                TreeNode parent = queue.Dequeue();
                if (vals[i] != "null")
                {
                    parent.left = new TreeNode(Convert.ToInt32(vals[i]));
                    queue.Enqueue(parent.left);
                }
                if ((++i < vals.Length) && vals[i] != "null")
                {
                    parent.right = new TreeNode(Convert.ToInt32(vals[i]));
                    queue.Enqueue(parent.right);
                }
            }
            return root;
        }
    }
}


