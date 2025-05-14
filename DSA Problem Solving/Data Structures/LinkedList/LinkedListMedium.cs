using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Data_Structures.LinkedList;
public class LinkedListMedium
{
    // Merges two sorted linked lists into one sorted linked list
    // Time Complexity: O(n + m), where n and m are the lengths of the two lists
    // Space Complexity: O(1)
    public static ListNode MergeTwoLists(ListNode n1, ListNode n2)
    {
        ListNode temp, hd;
        hd = new(-1); // Dummy node to simplify edge cases
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
        temp.next = n1 ?? n2; // Append the remaining nodes
        return hd.next; // Return the merged list, skipping the dummy node
    }

    // Removes the Nth node from the end of the list
    // Time Complexity: O(L), where L is the length of the list
    // Space Complexity: O(1)
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

    // Removes the Nth node from the end of the list using two pointers
    // Time Complexity: O(L), where L is the length of the list
    // Space Complexity: O(1)
    public static ListNode RemoveNthFromEndOptimal(ListNode head, int N)
    {
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

    // Deletes a given node (except the tail) from the linked list
    // Time Complexity: O(1)
    // Space Complexity: O(1)
    public static void DeleteNode(ListNode given)
    {
        if (given is null) return;
        if (given.next is null)
            given = null;

        ListNode nxt1, nxt2;
        nxt1 = given.next;
        nxt2 = nxt1.next;

        given.val = nxt1.val; // Copy the value of the next node to the current node
        given.next = nxt2; // Bypass the next node
        nxt1 = null; // Delete the next node
    }

    // Finds the intersection node of two linked lists using brute force
    // Time Complexity: O(n * m), where n and m are the lengths of the two lists
    // Space Complexity: O(1)
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

    // Finds the intersection node of two linked lists using two pointers
    // Time Complexity: O(n + m), where n and m are the lengths of the two lists
    // Space Complexity: O(1)
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

    // Adds two numbers represented by linked lists
    // Time Complexity: O(max(n, m)), where n and m are the lengths of the two lists
    // Space Complexity: O(max(n, m)), for the result list
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

    // Detects if a cycle exists in the linked list using a hash set
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(n), for the hash set
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

    // Detects if a cycle exists in the linked list using slow and fast pointers
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(1)
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

    // Checks if a linked list is a palindrome
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(n), for the list of values
    public static bool IsPalindrome(ListNode head)
    {
        if (head is null || head.next is null) return true;

        bool isTru = true;
        ListNode copy = head;
        List<int> num = new();
        int cnt = 0;
        while (copy is not null)
        {
            num.Add(copy.val);
            copy = copy.next;
        }
        for (int i = 0; i < num.Count / 2; i++)
        {
            if (num[i] != num[num.Count - i - 1])
            {
                isTru = false;
                break;
            }
        }
        return isTru;
    }

    // Reverses a linked list using recursion
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(n), for the recursion stack
    public static ListNode reverseLinkedList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode newHead = reverseLinkedList(head.next);
        ListNode front = head.next;
        front.next = head;
        head.next = null;
        return newHead;
    }

    // Checks if a linked list is a palindrome using two pointers and reversing the second half
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(1)
    public static bool isPalindrome(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return true;
        }

        ListNode slow = head;
        ListNode fast = head;

        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode newHead = reverseLinkedList(slow.next);
        ListNode first = head;
        ListNode second = newHead;
        while (second != null)
        {
            if (first.val != second.val)
            {
                reverseLinkedList(newHead);
                return false;
            }
            first = first.next;
            second = second.next;
        }

        reverseLinkedList(newHead);
        return true;
    }

    // Rotates the linked list to the right by k places
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(1)
    public static ListNode RotateRight(ListNode head, int k)
    {
        if (head == null) return null;

        ListNode temp = head;
        int length = 1;
        while (temp.next != null)
        {
            ++length;
            temp = temp.next;
        }

        temp.next = head;
        k = k % length;
        int end = length - k;
        while (end-- != 0) temp = temp.next;

        head = temp.next;
        temp.next = null;

        return head;
    }

    // Rotates the linked list to the right by k places (alternative implementation)
    // Time Complexity: O(n), where n is the length of the list
    // Space Complexity: O(1)
    public static ListNode RotateRightMine(ListNode head, int k)
    {
        if (head == null) return null;

        int len = 1, lstNodIndx = 0;
        ListNode last = head, lstNod = head, newHead = null;
        while (last.next != null)
        {
            last = last.next;
            len++;
        }

        k = k % len;
        lstNodIndx = len - k - 1;
        if (k == 0) return head;

        while (lstNodIndx-- > 0)
        {
            lstNod = lstNod.next;
        }

        last.next = head;
        newHead = lstNod.next;
        lstNod.next = null;
        return newHead;
    }

    public static ListNode FirstNode(ListNode head)
    {
        // Initialize a slow and fast 
        // pointers to the head of the list
        ListNode slow = head;
        ListNode fast = head;

        // Phase 1: Detect the loop
        while (fast != null && fast.next != null)
        {
            // Move slow one step
            slow = slow.next;

            // Move fast two steps
            fast = fast.next.next;

            // If slow and fast meet,
            // a loop is detected
            if (slow == fast)
            {
                // Reset the slow pointer
                // to the head of the list
                slow = head;

                // Phase 2: Find the first node of the loop
                while (slow != fast)
                {
                    // Move slow and fast one step
                    // at a time
                    slow = slow.next;
                    fast = fast.next;

                    // When slow and fast meet again,
                    // it's the first node of the loop
                }

                // Return the first node of the loop
                return slow;
            }
        }

        // If no loop is found, return null
        return null;
    }

    //92. Reverse Linked List II
    public static ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || left == right)
            return head;

        // Step 1: Use a dummy node to simplify edge cases (like reversing from head)
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        // Step 2: Move `prev` to the node just before `left`
        ListNode prev = dummy;
        for (int i = 1; i < left; i++)
            prev = prev.next;

        // Step 3: Start reversing from `left` to `right`
        ListNode current = prev.next;
        for (int i = 0; i < right - left; i++)
        {
            ListNode nxt = current.next;
            current.next = nxt.next;
            nxt.next = prev.next;
            prev.next = nxt;
        }

        return dummy.next;
    }
}
