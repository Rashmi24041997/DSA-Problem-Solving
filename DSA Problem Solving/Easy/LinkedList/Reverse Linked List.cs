using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Easy.LinkedList
{
    internal class Reverse_Linked_List
    {
        public static ListNode AddTwoNumbers(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode pre = null, crnt = head, nxt = head;

            //step 2
            while (crnt != null)
            {
                nxt = crnt.next;
                crnt.next = pre;

                pre = crnt;
                crnt = nxt;
            }

            head = pre; //step 3
            return head;
        }
    }
}
