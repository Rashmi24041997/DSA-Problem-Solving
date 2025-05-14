using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms
{
    public static class GreedyAlgo
    {
        static class Easy
        {
            public class Meeting
            {
                public int End, Start, Pos;
                public Meeting(int end, int start, int pos)
                {
                    End = end;
                    Start = start;
                    Pos = pos;
                }
            }

            public class MeetingComparer : IComparer<Meeting>
            {
                int IComparer<Meeting>.Compare(Meeting? x, Meeting? y)
                {
                    if (x == null || y == null)
                        return 0;
                    if (x.Equals(y))
                        return 0;
                    if (x.End < y.End)
                        return 1;
                    else if (x.End > y.End)
                        return -1;
                    else if (x.Pos < y.Pos)
                        return 1;
                    else
                        return -1;
                }
            }

            // Function to find the maximum number of meetings that can be attended
            // Time Complexity: O(n log n) due to sorting
            // Space Complexity: O(n) for storing meetings
            public static int MaxMeetings(int[] start, int[] end)
            {
                if (start == null || end == null || start.Length == 0 || end.Length == 0)
                    return 0;

                int limit;

                // Create a list of meetings
                List<Meeting> meetings = new();

                // Populate the list with meeting objects
                for (int i = 0; i < end.Length; i++)
                {
                    meetings.Add(new Meeting(end[i], start[i], i + 1));
                }

                // Sort the meetings based on their end times
                meetings.Sort(new MeetingComparer());

                // Initialize the result list with the first meeting
                List<Meeting> result = new() { meetings[0] };

                // Set the limit to the end time of the first meeting
                limit = meetings[0].End;

                // Iterate through the sorted meetings
                for (int i = 1; i < end.Length; i++)
                {
                    Meeting meeting = meetings[i];
                    // If the start time of the current meeting is greater than the limit
                    if (meeting.Start > limit)
                    {
                        // Add the meeting to the result list
                        result.Add(meeting);
                        // Update the limit to the end time of the current meeting
                        limit = meeting.End;
                    }
                }
                // Return the count of meetings that can be attended
                return result.Count;
            }

            // Function to calculate the maximum value of items that can be carried in a knapsack
            // Time Complexity: O(n log n) due to sorting
            // Space Complexity: O(n) for storing ratios
            public static double FractionalKnapsack(List<int> val, List<int> wt, int capacity)
            {
                if (val is null || wt is null || val.Count == 0 || wt.Count == 0)
                {
                    return 0;
                }

                // Create a list of value-to-weight ratios
                List<(double ratio, int index)> rates = new();
                for (int i = 0; i < val.Count; i++)
                {
                    rates.Add(((double)val[i] / wt[i], i));
                }

                // Sort the ratios in descending order
                rates.Sort((a, b) => b.ratio.CompareTo(a.ratio));

                double totalValue = 0;

                // Iterate through the sorted ratios
                for (int i = rates.Count - 1; i >= 0; i--)
                {
                    int index = rates[i].index;
                    // If the weight of the current item is less than or equal to the remaining capacity
                    if (wt[index] <= capacity)
                    {
                        // Subtract the weight from the capacity
                        capacity -= wt[index];
                        // Add the value to the total value
                        totalValue += val[index];
                    }
                    else
                    {
                        // Calculate the value of the fractional part of the item
                        double rate = rates[i].ratio;
                        totalValue = rate * capacity;
                        break;
                    }
                }
                // Return the total value of items that can be carried
                return totalValue;
            }

            // Class to represent an item with a value and a weight
            internal class Item
            {
                public int Value { get; set; } // Value of the item
                public int Weight { get; set; } // Weight of the item

                public Item(int value, int weight)
                {
                    Value = value;
                    Weight = weight;
                }
            }

            // Comparator class to compare items based on their value-to-weight ratio
            class ItemComparator : IComparer<Item>
            {
                public int Compare(Item a, Item b)
                {
                    // Calculate the value-to-weight ratio for both items
                    double r1 = (double)a.Value / a.Weight;
                    double r2 = (double)b.Value / b.Weight;

                    // Sort in descending order of the ratio
                    if (r1 < r2) return 1;   // If r1 < r2, item b should come before item a
                    else if (r1 > r2) return -1; // If r1 > r2, item a should come before item b
                    else return 0;            // If r1 == r2, maintain current order
                }
            }

            // Function to calculate the maximum value we can get with the given weight capacity
            // Time Complexity: O(n log n) due to sorting
            // Space Complexity: O(1)
            public static double FractionalKnapsackSpaceOptimal(int W, Item[] arr)
            {
                // Sort the items based on value-to-weight ratio
                Array.Sort(arr, new ItemComparator());

                int currentWeight = 0;    // Current total weight in the knapsack
                double finalValue = 0.0;  // Total value of items in the knapsack

                // Iterate through each item
                for (int i = 0; i < arr.Length; i++)
                {
                    // If adding the current item doesn't exceed capacity, add it entirely
                    if (currentWeight + arr[i].Weight <= W)
                    {
                        currentWeight += arr[i].Weight; // Add item's weight to current total
                        finalValue += arr[i].Value;     // Add item's value to total value
                    }
                    else
                    {
                        // If adding the entire item exceeds capacity, add the fractional part
                        int remain = W - currentWeight; // Remaining weight capacity
                        finalValue += ((double)arr[i].Value / arr[i].Weight) * remain;
                        break; // Since the knapsack is full, break out of the loop
                    }
                }

                return finalValue; // Return the total value accumulated
            }
            /*
                Assume you are an awesome parent and want to give your children some cookies. But, you should give each child at most one cookie.
                Each child i has a greed factor g[i], which is the minimum size of a cookie that the child will be content with; and each cookie j has a size s[j]. If s[j] >= g[i], we can assign the cookie j to the child i, and the child i will be content. Your goal is to maximize the number of your content children and output the maximum number.

                Example 1:                
                Input: g = [1,2,3], s = [1,1]
                Output: 1
             */
            public static int FindContentChildren(int[] g, int[] s)
            {
                // If there are no cookies, return 0 as no child can be content
                if (s.Length == 0) return 0;

                int cnt = 0; // Initialize the count of content children to 0

                // Sort the greed factors of children in ascending order
                Array.Sort(g);

                // Sort the sizes of cookies in ascending order
                Array.Sort(s);

                // Initialize two pointers for children and cookies
                for (int i = 0, j = 0; i < g.Length && j < s.Length;)
                {
                    int ch = g[i]; // Get the greed factor of the current child
                    int co = s[j]; // Get the size of the current cookie

                    // If the current cookie can satisfy the current child
                    if (ch <= co)
                    {
                        cnt++; // Increment the count of content children
                        i++;   // Move to the next child
                    }
                    j++; // Move to the next cookie
                }

                // Return the total number of content children
                return cnt;
            }
            public static int FindContentChildrenRev(int[] g, int[] s)
            {
                Array.Sort(g);
                Array.Sort(s);
                int ans = 0;
                int p1 = 0, p2 = 0;
                while (p1 < g.Length && p2 < s.Length)
                {
                    if (g[p1] <= s[p2])
                    {
                        ans++;
                        p1++;
                    }
                    p2++;
                }
                return ans;
            }
        }

        public static class Medium
        {
            //45. Jump Game II

            public static int JumpII(int[] nums)
            {
                int lIndx = nums.Length - 1;
                if (nums.Length == 0) { return 0; }
                int target = 0, jump = 0;
                while (lIndx != 0)
                {
                    while (lIndx - target > nums[target])
                    {
                        target++;
                    }
                    jump++;
                    lIndx = target;
                    target = 0;
                }
                return jump;
            }
        }
        public static class Hard
        {
        }
    }
}
