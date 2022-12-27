using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Medium
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class AddTwoNumbers_LinkedList
    {

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            bool nul1 = l1 == null;
            bool nul2 = l2 == null;
            if (nul1 && nul2)
                return null;
            ListNode l3 = new();
            ChngLst(l1, l2, l3);
            return l3;
        }

        private void ChngLst(ListNode l1, ListNode l2, ListNode l3)
        {
            if (l1 != null || l2 != null)
            {
                int n1 = 0, n2 = 0;
                if (l1 != null)
                    n1 = l1.val;
                if (l2 != null)
                    n2 = l2.val;
                int n3 = n1 + n2;
                n3 = Int16.Parse(n3.ToString().Last().ToString());
                l3.val = n3;
                l3.next = new ListNode(0);
                ChngLst(l1.next??null, l2.next?null, l3.next?.null);
            }
        }
    }
}
