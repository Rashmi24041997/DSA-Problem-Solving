using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures.LinkedList
{
    public class LinkedListMedium
    {
        public static ListNode MergeTwoLists(ListNode n1, ListNode n2)
        {

            ListNode temp, hd;
            hd = new(-1);
            temp = hd;
            while (n1 != null && n2 != null)
            {
                if (n1.val <= n2.val)
                {
                    temp.next = n1;
                    n1 = n1.next;
                }
                else
                {
                    temp.next = n2;
                    n2 = n2.next;
                }
                temp = temp.next;
            }
            temp.next = n1 ?? n2;
            return hd.next;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int N)
        {
            if (head == null)
            {
                return null;
            }
            int cnt = 0;
            ListNode temp = head;

            // Count the number of nodes in the linked list
            while (temp != null)
            {
                cnt++;
                temp = temp.next;
            }

            // If N equals the total number of nodes, delete the head
            if (cnt == N)
            {
                ListNode newhead = head.next;
                head = null;
                return newhead;
            }

            // Calculate the position of the node to delete (res)
            int res = cnt - N;
            temp = head;

            // Traverse to the node just before the one to delete
            while (temp != null)
            {
                if (res == 1)
                {
                    break;
                }
                temp = temp.next;
                res--;
            }

            // Delete the Nth node from the end
            ListNode delNode = temp.next;
            temp.next = temp.next.next;
            delNode = null;
            return head;
        }

        public static ListNode RemoveNthFromEndOptimal(ListNode head, int N)
        {
            // Create two pointers, fastp and slowp
            ListNode fastp = head;
            ListNode slowp = head;

            // Move the fastp pointer N nodes ahead
            for (int i = 0; i < N; i++)
                fastp = fastp.next;

            // If fastp becomes null, the Nth node from the end is the head
            if (fastp == null)
                return head.next;

            // Move both pointers until fastp reaches the end
            while (fastp.next != null)
            {
                fastp = fastp.next;
                slowp = slowp.next;
            }

            // Delete the Nth node from the end
            ListNode delNode = slowp.next;
            slowp.next = slowp.next.next;
            delNode = null;
            return head;
        }

        //public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        //{
        //    if (l1 is null) return l1;
        //    if (l2 is null) return l2;

        //    ListNode nod, nxt, temp, hd;
        //    nod = l1.val < l2.val ? l1 : l2;
        //    temp = l1.val < l2.val ? l2 : l1;
        //    hd = nod;
        //    nxt = nod.next;
        //    while (temp != null && nxt != null)
        //    {
        //        //ListNode low = ;
        //        if (temp.val <= nxt.val)
        //        {
        //            nod.next = temp;
        //            temp = nxt;
        //            nxt = temp.next;
        //        }
        //        else
        //        {
        //            nod.next = nxt;
        //            nxt = nxt.next;
        //        }
        //        nod = nod.next;
        //    }
        //    if (temp != null)
        //    {
        //        nod.next = temp;
        //    }
        //    else if (nxt != null)
        //    {
        //        nod.next = nxt;
        //    }
        //    return hd;
        //}

        public static void DeleteNode(ListNode given)
        {
            if (given is null) return;
            if (given.next is null)
                given = null;

            ListNode nxt1, nxt2;
            nxt1 = given.next;
            nxt2 = nxt1.next;

            given.val = nxt1.val;

            given.next = nxt2;
            nxt1 = null;
        }

        public static ListNode GetIntersectionNodeBruteForce(ListNode headA, ListNode headB)
        {
            ListNode l1 = headA; ListNode l2 = headB;
            while (l1.next != null)
            {
                while (l2.next != null)
                {
                    if (l2.next == l1)
                    {
                        return l1;
                    }
                }
                l1 = l1.next;
            }
            return null;
        }

        /// <summary>
        /// travel both of the head nodes by d1, d2 till they're equal
        // keep pointing them to their opposite list's head when they are null
        //this way at 3rd iteration, they will start at same length n will reach to same node either common or null  
        /// </summary>
        public static ListNode GetIntersectionNodeOptiml(ListNode headA, ListNode headB)
        {
            ListNode l1 = headA; ListNode l2 = headB;
            while (l1 != l2)
            {
                l1 = l1 is null ? headB : l1.next;
                l2 = l2 is null ? headA : l2.next;
            }
            return l1;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode n1 = l1, n2 = l2;
            int sum, carry = 0;
            ListNode res = null, temp = null;
            while (n1 != null || n2 != null)
            {
                sum = (n1?.val ?? 0) + (n2?.val ?? 0) + carry;
                if (res == null)
                {
                    res = new ListNode(sum % 10);
                    temp = res;
                }
                else
                {
                    res.next = new ListNode(sum % 10);
                    res = res.next;
                }
                carry = sum / 10;
                n1 = n1?.next; n2 = n2?.next;
            }
            if (carry > 0)
            {
                res.next = new ListNode(carry);
            }
            return temp;
        }

        public static bool HasCycle(ListNode head)
        {
            HashSet<ListNode> nodes = new();
            while (head != null)
            {
                if (nodes.Contains(head)) return true;
                nodes.Add(head);
                head = head.next;
            }
            return false;
        }

        /// <summary>
        /// Apply slow and fast pointer approach.
        /// move the pointer by 2 nodes.
        /// </summary>
        public static bool HasCycleOpt(ListNode head)
        {

            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                if (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                else
                    return true;
            }
            return false;

        }
    }
}
