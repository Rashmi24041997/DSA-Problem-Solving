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
            IList<int> rslt = new List<int>();
            Stack<TreeNode> st = new Stack<TreeNode>();
            TreeNode nod = node;
            TreeNode temp = null;
            while (true)
            {
                //Traversing the left subtree
                if (nod != null)
                {
                    //push in the stack so that when we come to it later, we can mark it as traversed
                    st.Push(nod);

                    //go on for left subtree
                    nod = nod.left;
                }
                else {
                    temp = st.Peek();
                    if (temp != null)
                        rslt.Add(temp.val);

                    //if stack is empty means all parent nodes are popped out and enlisted
                    if (st.Count == 0)
                        break;

                    //pop the latest parent and enlist its value to mark it as traversed
                    nod = st.Pop();
                    rslt.Add(nod.val);

                    //Continue for popped nod's right subtree
                    nod= nod.right;
                }
            }
            return rslt;
        }
    }
}
