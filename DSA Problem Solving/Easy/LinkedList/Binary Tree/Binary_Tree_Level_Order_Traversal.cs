//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DSA_Problem_Solving.Easy.Binary_Tree
//{
//    internal class Binary_Tree_Level_Order_Traversal
//    {
//        public static IList<IList<int>> LevelOrder(TreeNode root)
//        {
//            IList<IList<int>> rslt = new List<IList<int>>();

//            Queue<TreeNode> que = new Queue<TreeNode>();

//            if (root != null) que.Enqueue(root);

//            while (que.Count != 0)
//            {
//                int cnt = que.Count;
//                List<int> lst = new List<int>();
//                for (int i = 0; i < cnt; i++)
//                {
//                    TreeNode nod = que.Dequeue();
//                    lst.Add(nod.val);
//                    if (nod.left != null) que.Enqueue(nod.left);
//                    if (nod.right != null) que.Enqueue(nod.right);
//                }
//                rslt.Add(lst);
//            }
//            return rslt;
//        }
//    }
//}
