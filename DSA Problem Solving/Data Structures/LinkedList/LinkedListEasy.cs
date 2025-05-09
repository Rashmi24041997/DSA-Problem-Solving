using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures.LinkedList;

public class LinkedListEasy
{
    // Method to reverse a linked list iteratively
    // Time complexity: O(n)
    // Space complexity: O(1)
    public static ListNode? ReverseList(ListNode head)
    {
        if (head == null) return head; // If the list is empty, return null
        ListNode? l1 = head, l2 = l1.next, l3 = l2?.next;
        if (l2 == null)
        {
            l1.next = null; // If there's only one node, return it as the reversed list
            return l1;
        }
        if (l3 == null)
        {
            l2.next = l1; // If there are only two nodes, reverse them
            l1.next = null;
            return l2;
        }
        while (l3.next != null)
        {
            l2.next = l1; // Reverse the link
            l1 = l2; // Move to the next node
            l2 = l3;
            l3 = l3.next;
        }
        l3.next = head; // Reverse the last link
        l2.next = l1;
        l3.next = l2;
        head.next = null;
        return l3;
    }

    // Method to reverse a linked list using recursion
    // Time complexity: O(n)
    // Space complexity: O(n) due to the recursion stack
    public static ListNode ReverseListUsingStack(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head; // Base case: if the list is empty or has one node, return it
        }

        ListNode newHead = ReverseListUsingStack(head.next); // Recursive step: reverse the rest of the list

        ListNode front = head.next; // Save the next node
        front.next = head; // Reverse the link
        head.next = null; // Break the original link

        return newHead; // Return the new head of the reversed list
    }

    // Method to find the middle node of a linked list
    // Time complexity: O(n)
    // Space complexity: O(1)
    public static ListNode FindMiddle(ListNode head)
    {
        if (head == null) return head; // If the list is empty, return null
        if (head.next == null) return head; // If there's only one node, return it

        ListNode slow = head;
        ListNode fast = head.next;

        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next; // Move slow pointer one step
            fast = fast.next.next; // Move fast pointer two steps
        }
        return slow.next; // Return the middle node
    }

    public static ListNode? ReverseListRev(ListNode head)
    {
        if (head is null || head.next is null)
            return head;
        ListNode cur = head;
        ListNode nxt = cur.next;
        ListNode pre = null;

        while (cur != null)
        {
            cur.next = pre;
            pre = cur;
            cur = nxt;
            nxt = nxt?.next;
        }
        return pre;
    }
    public void DeleteNodeRev(ListNode node)
    {
        ListNode nxt1 = node.next;
        ListNode nxt2 = node.next.next;
        int temp = nxt1.val;
        nxt1.val = node.val;
        node.val = temp;
        node.next = nxt2;
        
    }

};
