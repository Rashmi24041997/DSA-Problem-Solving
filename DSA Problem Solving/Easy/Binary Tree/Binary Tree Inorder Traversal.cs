using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Easy.Binary_Tree
{
    internal class Binary_Tree_Inorder_Traversal
    {
        public static IList<int> Solution(TreeNode node)
        {
            IList<int> lst = new List<int>();
            Stack<TreeNode> st = new Stack<TreeNode>();
            TreeNode crnt = node;
            TreeNode temp = null;
            while (crnt != null && st.Count > 0)
            {
                //Traversing the left subtree
                if (crnt != null)
                {
                    //push in the stack so that when we come to it later, we can mark it as traversed
                    st.Push(crnt);

                    //go on for left subtree
                    crnt = crnt.left;
                }
                else {

                    temp = st.Peek().right;

                    if (temp != null)
                        crnt = temp;
                    else
                    {
                        crnt = st.Peek();
                        st.Pop();
                        lst.Add(crnt.val);
                        while (st.Count != 0 && temp == st.Peek().right)
                        { 
                            temp = st.Peek();
                            st.Pop();
                            lst.Add(temp.val);
                        }
                    }
                }
            }
            return lst;
            /*
    // Strategy 1: Recursion O(N)
    public IList<int> PostorderTraversal(TreeNode root) {
        if (root is null)
        {
            return new List<int>();
        }
        var res = new List<int>();
        if (root.left != null)
        {
            res.AddRange(PostorderTraversal(root.left));
        }
        if (root.right != null)
        {
            res.AddRange(PostorderTraversal(root.right));
        }
        res.Add(root.val);
        return res;
    }
             */
        }
    }
}
