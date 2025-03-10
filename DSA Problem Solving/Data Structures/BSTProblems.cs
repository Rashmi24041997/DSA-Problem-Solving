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
    }
}

