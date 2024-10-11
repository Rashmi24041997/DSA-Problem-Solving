//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace DSA_Problem_Solving.Easy.Binary_Tree
//{
//    internal class RightSideView
//    {
//    public IList<int> Solution(TreeNode root)
//        {

//            IList<int> rslt = new List<int>();
//            RightSideVu(root, 1, rslt);
//            return rslt;
//    }
//        private void RightSideVu(TreeNode nod, int lev, IList<int> lst)
//        {
//            if (nod == null)
//                return;
//            if (lev > lst.Count)
//                lst.Add(nod.val);
//            RightSideVu(nod.right,lev+1,lst);
//            RightSideVu(nod.right,lev+1,lst);
//    }
//    }
//}
