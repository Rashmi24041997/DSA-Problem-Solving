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
        // Function to reverse nodes in k-group
        // Time Complexity: O(n)
        // Space Complexity: O(1)
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

        // Helper function to reverse a linked list recursively
        // Time Complexity: O(n)
        // Space Complexity: O(n) due to recursion stack
        private static ListNode ReversList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode newHead = ReversList(head.next);
            ListNode front = head.next;
            front.next = head;
            head.next = null;
            return newHead;
        }

        // Function to reverse a linked list using the 3-pointer approach
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        public static ListNode reverseLinkedList(ListNode head)
        {
            ListNode temp = head;
            ListNode prev = null;
            while (temp != null)
            {
                ListNode front = temp.next;
                temp.next = prev;
                prev = temp;
                temp = front;
            }
            return prev;
        }

        // Function to get the Kth node from a given position in the linked list
        // Time Complexity: O(k)
        // Space Complexity: O(1)
        static ListNode getKthNode(ListNode temp, int k)
        {
            k -= 1;
            while (temp != null && k > 0)
            {
                k--;
                temp = temp.next;
            }
            return temp;
        }

        // Function to reverse nodes in groups of K
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        public static ListNode kReverse(ListNode head, int k)
        {
            ListNode temp = head;
            ListNode prevLast = null;
            while (temp != null)
            {
                ListNode kThNode = getKthNode(temp, k);
                if (kThNode == null)
                {
                    if (prevLast != null)
                    {
                        prevLast.next = temp;
                    }
                    break;
                }
                ListNode nextNode = kThNode.next;
                kThNode.next = null;
                reverseLinkedList(temp);
                if (temp == head)
                {
                    head = kThNode;
                }
                else
                {
                    prevLast.next = kThNode;
                }
                prevLast = temp;
                temp = nextNode;
            }
            return head;
        }
    }
}
