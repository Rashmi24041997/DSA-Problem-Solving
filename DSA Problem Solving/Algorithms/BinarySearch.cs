using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms
{
    public class BinarySearch
    {
        public class Easy
        {
            /*
             Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums.
              If target exists, then return its index. Otherwise, return -1.
            You must write an algorithm with O(log n) runtime complexity.
             */
            public static int Search(int[] nums, int target)
            {
                int left = 0, right = nums.Length - 1, mid;
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    int i = nums[mid];
                    if (i == target)
                        return mid;
                    else if (i > target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                return -1;
            }
            // Method to find the nth root of m using binary search
            // Time Complexity: O(log(m))
            // Space Complexity: O(1)
            public static int NthRoot(int n, int m)
            {
                // If n is 1 or m is 1, the nth root of m is m
                if (n == 1 || m == 1)
                {
                    return m;
                }
                // If m is 0, the nth root of m is 0
                if (m == 0)
                {
                    return 0;
                }
                // Initialize low to 0 and high to m/2
                int low = 0, high = m / 2, mid = 0;

                // Binary search to find the nth root
                while (low != high)
                {
                    // Calculate mid
                    mid = (low + high) / 2;
                    // Calculate mid^n and compare it with m
                    int res = power(mid, n, m);
                    // If mid^n is equal to m, return mid
                    if (res == 1)
                        return mid;
                    // If mid^n is greater than m, search in left part, adjust high
                    if (res == 2)
                        high = mid - 1;
                    // If mid^n is less than m, search in right part, adjust low
                    else if (res == -1)
                        low = mid + 1;
                }
                // If no integer nth root is found, return -1
                return -1;
            }

            // Helper method to calculate x^n and compare it with m
            // Time Complexity: O(n)
            // Space Complexity: O(1)
            static int power(int x, int n, int m)
            {
                // If n is 0, x^n is 1
                if (n == 0)
                    return 1;
                // Calculate x^n
                while (x <= m && n > 0)
                {
                    x *= x;
                    n--;
                }
                // If x^n is greater than m, return 2
                // If x^n is less than m, return -1
                // If x^n is equal to m, return 1
                return x > m ? 2 : x < m ? -1 : 1;
            }
        }

        public class Medium
        {
            /*
                You are given a sorted array consisting of only integers where every element appears exactly twice,
                except for one element which appears exactly once.
                Return the single element that appears only once. Your solution must run in O(log n) time and O(1) space.
            */
            public static int SingleNonDuplicate(int[] nums)
            {
                if (nums is null)
                    return 0;
                if (nums.Length == 0) return 0;
                if (nums.Length == 1) return nums[0];
                int i = 0;
                while (i < nums.Length)
                {
                    if (i + 1 < nums.Length)
                    {
                        if (nums[i] != nums[i + 1])
                            return nums[i];
                        i += 2;
                    }
                    else return nums[i];
                }
                return -1;
            }
            public static int SingleNonDuplicateLogN(int[] nums)
            {
                if (nums is null)
                    return 0;
                int n = nums.Length;
                if (n == 0) return 0;
                if (n == 1) return nums[0];
                int low = 0, high = n - 1;

                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    //if mid is even, mid ^ 1 gives next odd index
                    //else it gives previous even index
                    //so if condition fulfils, we are in left part of the answer 
                    if (nums[mid] == nums[mid ^ 1])
                    {
                        low = mid + 1; //search in right part
                    }
                    //else we are in right part of the answer
                    else
                        high = mid - 1;//search in left part
                }
                return nums[low];
            }
        }
    }
}







