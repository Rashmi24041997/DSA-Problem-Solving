using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures.LinkedList;

public class LinkedListEasy
{
    public static ListNode? ReverseList(ListNode head)
    {
        if (head == null) return head;
        ListNode? l1 = head, l2 = l1.next, l3 = l2?.next;
        if (l2 == null)
        {
            l1.next = null;
            return l1;
        }
        if (l3 == null)
        {
            l2.next = l1;
            l1.next = null;
            return l2;
        }
        while (l3.next != null)
        {
            l2.next = l1;
            l1 = l2;
            l2 = l3;
            l3 = l3.next;
        }
        l3.next = head;
        l2.next = l1;
        l3.next = l2;
        head.next = null;
        return l3;

    }

    public static ListNode ReverseListUsingStack(ListNode head)
    {
        // Base case:
        // If the linked list is empty or has only one node,
        // return the head as it is already reversed.
        if (head == null || head.next == null)
        {
            return head;
        }

        // Recursive step:
        // Reverse the linked list starting
        // from the second node (head.next).
        ListNode newHead = ReverseListUsingStack(head.next);

        // Save a reference to the node following
        // the current 'head' node.
        ListNode front = head.next;

        // Make the 'front' node point to the current
        // 'head' node in the reversed order.
        front.next = head;

        // Break the link from the current 'head' node
        // to the 'front' node to avoid cycles.
        head.next = null;

        // Return the 'newHead,' which is the new
        // head of the reversed linked list.
        return newHead;
    }

    public static ListNode FindMiddle(ListNode head)
    {
        if (head == null) return head;
        if (head.next == null) return head;
        //if (fast is null) return head.next;

        ListNode slow = head;
        ListNode fast = head.next;

        int cnt = 0;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow.next;
    }

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

};
