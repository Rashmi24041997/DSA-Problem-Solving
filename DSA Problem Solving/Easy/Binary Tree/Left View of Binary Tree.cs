using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Easy.Binary_Tree
{
    internal class Left_View_of_Binary_Tree
    {
        public static List<int> Solution(TreeNode root)
        {

            List<int> rslt = new List<int>();
            LeftSideVu(root, 1, rslt);
            return rslt;
        }
        private static void LeftSideVu(TreeNode nod, int lev, IList<int> lst)
        {
            if (nod == null)
                return;
            if (lev > lst.Count)
                lst.Add(nod.val);
            LeftSideVu(nod.left, lev + 1, lst);
            LeftSideVu(nod.right, lev + 1, lst);
        }
    }
}
