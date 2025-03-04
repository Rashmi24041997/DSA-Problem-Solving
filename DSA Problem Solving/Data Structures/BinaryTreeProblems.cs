using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures
{/**
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
        }
        public class Medium
        {
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
        }

        public class Hard
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
        }
    }
}



