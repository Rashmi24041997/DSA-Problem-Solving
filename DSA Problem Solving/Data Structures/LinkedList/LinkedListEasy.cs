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

};
