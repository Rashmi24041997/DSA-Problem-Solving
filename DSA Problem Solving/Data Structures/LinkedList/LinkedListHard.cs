using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures.LinkedList
{
    public class LinkedListHard
    {
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head is null || head.next is null || k == 0)
            {
                return head;
            }
            ListNode result = head;
            ListNode thd = head, tEnd, tNxt;
            int tCnt = 0;
            while (thd != null)
            {
                tCnt++;
                if (tCnt % k != 0)
                {
                    thd = thd.next;
                }
                else
                {
                    tEnd = thd;
                    tNxt = thd.next;
                    ReversList(head);
                    //head.next = tNxt;
                    thd.next = null;
                    thd = tNxt;
                    head = tNxt;
                    if ((tCnt / k) == 1) result = head;
                }
            }
            return result;
        }

        private static ListNode ReversList(ListNode head)
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
            ListNode newHead = ReversList(head.next);

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


        // Function to reverse a linked list
        // using the 3-pointer approach
        public static ListNode reverseLinkedList(ListNode head)
        {
            // Initialize'temp' at
            // head of linked list
            ListNode temp = head;

            // Initialize pointer 'prev' to NULL,
            // representing the previous node
            ListNode prev = null;

            // Traverse the list, continue till
            // 'temp' reaches the end (NULL)
            while (temp != null)
            {
                // Store the next node in
                // 'front' to preserve the reference
                ListNode front = temp.next;

                // Reverse the direction of the
                // current node's 'next' pointer
                // to point to 'prev'
                temp.next = prev;

                // Move 'prev' to the current
                // node for the next iteration
                prev = temp;

                // Move 'temp' to the 'front' node
                // advancing the traversal
                temp = front;
            }

            // Return the new head of
            // the reversed linked list
            return prev;

        }

        // Function to get the Kth node from
        // a given position in the linked list
        static ListNode getKthNode(ListNode temp, int k)
        {
            // Decrement K as we already
            // start from the 1st node
            k -= 1;

            // Decrement K until it reaches
            // the desired position
            while (temp != null && k > 0)
            {
                // Decrement k as temp progresses
                k--;

                // Move to the next node
                temp = temp.next;
            }

            // Return the Kth node
            return temp;
        }

        // Function to reverse nodes in groups of K
        public static ListNode kReverse(ListNode head, int k)
        {
            
            // Initialize a temporary
            // node to traverse the list
            ListNode temp = head;

            // Initialize a pointer to track the
            // last node of the previous group
            ListNode prevLast = null;

            // Traverse through the linked list
            while (temp != null)
            {

                // Get the Kth node of the current group
                ListNode kThNode = getKthNode(temp, k);

                // If the Kth node is NULL
                // (not a complete group)
                if (kThNode == null)
                {

                    // If there was a previous group,
                    // link the last node to the current node
                    if (prevLast != null)
                    {
                        prevLast.next = temp;
                    }

                    // Exit the loop
                    break;
                }

                // Store the next node
                // after the Kth node
                ListNode nextNode = kThNode.next;

                // Disconnect the Kth node
                // to prepare for reversal
                kThNode.next = null;

                // Reverse the nodes from
                // temp to the Kth node
                reverseLinkedList(temp);

                // Adjust the head if the reversal
                // starts from the head
                if (temp == head)
                {
                    head = kThNode;
                }
                else
                {
                    // Link the last node of the previous
                    // group to the reversed group
                    prevLast.next = kThNode;
                }

                // Update the pointer to the
                // last node of the previous group
                prevLast = temp;

                // Move to the next group
                temp = nextNode;
            }

            // Return the head of the
            // modified linked list
            return head;
        }
    }
}
