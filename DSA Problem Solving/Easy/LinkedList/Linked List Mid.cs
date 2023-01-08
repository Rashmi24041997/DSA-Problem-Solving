using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Easy.LinkedList
{
    internal class Linked_List_Mid
    {
        public static ListNode Solution(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode mid = head.next;
            ListNode crnt = head.next;
            while (crnt != null)
            {
                if (crnt.next != null)
                {
                    mid = mid.next;
                    crnt = crnt.next.next;
                }
                else
                    break;
            }
            return mid;
        }

    }
}
