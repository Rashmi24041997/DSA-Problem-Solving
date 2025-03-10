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
        ListNode? l1 = head, l2 = l1.Next, l3 = l2?.Next;
        if (l2 == null)
        {
            l1.Next = null; // If there's only one node, return it as the reversed list
            return l1;
        }
        if (l3 == null)
        {
            l2.Next = l1; // If there are only two nodes, reverse them
            l1.Next = null;
            return l2;
        }
        while (l3.Next != null)
        {
            l2.Next = l1; // Reverse the link
            l1 = l2; // Move to the next node
            l2 = l3;
            l3 = l3.Next;
        }
        l3.Next = head; // Reverse the last link
        l2.Next = l1;
        l3.Next = l2;
        head.Next = null;
        return l3;
    }

    // Method to reverse a linked list using recursion
    // Time complexity: O(n)
    // Space complexity: O(n) due to the recursion stack
    public static ListNode ReverseListUsingStack(ListNode head)
    {
        if (head == null || head.Next == null)
        {
            return head; // Base case: if the list is empty or has one node, return it
        }

        ListNode newHead = ReverseListUsingStack(head.Next); // Recursive step: reverse the rest of the list

        ListNode front = head.Next; // Save the next node
        front.Next = head; // Reverse the link
        head.Next = null; // Break the original link

        return newHead; // Return the new head of the reversed list
    }

    // Method to find the middle node of a linked list
    // Time complexity: O(n)
    // Space complexity: O(1)
    public static ListNode FindMiddle(ListNode head)
    {
        if (head == null) return head; // If the list is empty, return null
        if (head.Next == null) return head; // If there's only one node, return it

        ListNode slow = head;
        ListNode fast = head.Next;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next; // Move slow pointer one step
            fast = fast.Next.Next; // Move fast pointer two steps
        }
        return slow.Next; // Return the middle node
    }
};
