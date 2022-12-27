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
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l3;
            if (l1 != null || l2 != null)
                l3 = new();
            else
                return null;
            ChngLst(l1, l2, l3,0);
            return l3;
        }

        private static void ChngLst(ListNode l1, ListNode l2, ListNode l3, int car)
        {
            int n1 = 0, n2 = 0;
            if (l1 != null)
                n1 = l1.val;
            if (l2 != null)
                n2 = l2.val;
            int n3 = (n1 + n2) + car;
            l3.val = n3 % 10 ;
            car = n3 / 10 != 0 ? n3 / 10 : 0;
            l1 = l1?.next??null;
            l2 = l2?.next??null;
            if ((l1 != null || l2 != null) )
            {
                l3.next = new();
                ChngLst(l1, l2, l3.next, car);
            }
            else if(car != 0)
            {
                l3.next = new(car);
            }
        }
    }
}
