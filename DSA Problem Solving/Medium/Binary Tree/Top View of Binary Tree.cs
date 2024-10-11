//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace DSA_Problem_Solving.Easy.Binary_Tree
//{
//    internal class Top_View_of_Binary_Tree
//    {

//        //public List<int> topView(Node root)
//        //{
//        //    List<int> lst = new List<int>();
//        //    Node nod = root;
//        //    TrackLeft(nod, lst);
//        //    TrackRight(nod.right, lst);
//        //    return lst;
//        //    //Your code here
//        //}
//        //private void TrackLeft(Node nod, List<int> lst)
//        //{
//        //    if (nod == null)
//        //        return;

//        //    TrackLeft(nod.left, lst);
//        //    lst.Add(nod.data);
//        //}
//        //private void TrackRight(Node nod, List<int> lst)
//        //{
//        //    if (nod == null)
//        //        return;

//        //    lst.add(nod.data);
//        //    TrackRight(nod.right, lst);
//        //}

//        public static List<int> TopView(TreeNode root)
//        {
//            try
//            {
//                List<int> lst = new List<int>();
//                if (root == null) return lst;
//                TreeNode nod = root;
//                Queue<KeyValuePair<int, TreeNode>> que = new();
//                Dictionary<int, int> map = new();
//                KeyValuePair<int, TreeNode> pr = new KeyValuePair<int, TreeNode>(0, nod);
//                que.Enqueue(pr);
//                while (que.Count != 0)
//                {
//                    pr = que.Dequeue();
//                    int n = pr.Key;
//                    nod = pr.Value;
//                    if (!map.ContainsKey(n)) map.Add(n, nod.val);
//                    if (nod.left != null)
//                    {
//                        pr = new KeyValuePair<int, TreeNode>(n - 1, nod.left);
//                        que.Enqueue(pr);
//                    }
//                    if (nod.right != null)
//                    {
//                        pr = new KeyValuePair<int, TreeNode>(n + 1, nod.right);
//                        que.Enqueue(pr);
//                    }
//                }
//               int[] arr =  map.Keys.ToArray<int>();
//                Array.Sort(arr);
//                foreach (int k in arr)
//                {
//                    lst.Add(Convert.ToInt32(map[k]));
//                }
//                return lst;
//            }
//            catch (Exception ex) { return null; }
//        }
//    }
//}
