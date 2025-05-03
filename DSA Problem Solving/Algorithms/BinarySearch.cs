using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            public static int[] getFloorAndCeil(int[] a, int n, int x)
            {
                int left = 0, right = n - 1, mid = 0, maxFloor = -1, minCeil = -1;
                int[] ans = new int[2] { maxFloor, minCeil };
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (a[mid] == x)
                    {
                        return new int[] { a[mid], a[mid] };
                    }
                    if (x > a[mid])
                    {
                        maxFloor = a[mid];
                        minCeil = a[mid + 1] >= x ? a[mid + 1] : -1;
                        left = mid + 1;
                    }
                    else
                    {
                        maxFloor = a[mid - 1] <= x ? a[mid - 1] : -1;
                        minCeil = a[mid];
                        right = mid - 1;
                    }
                }
                return new int[] { maxFloor, minCeil }; // If no floor and ceil found  
            }

            public static int MySqrtBF(int n)
            {
                int max = 2;
                if (n == 0)
                    return 0;
                if (n < 4)
                    return 1;
                for (int i = 2; i < n / 2; i++)
                {
                    long p = i * (long)i;
                    if (p == n)
                        return i;
                    if (p > n) break;
                    max = Math.Max(max, i);
                }
                return max;
            }

            public static int MySqrt(int n)
            {
                if (n == 0)
                    return 0;
                if (n < 4)
                    return 1;
                int left = 2, right = n / 2;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    long p = mid * (long)mid;
                    if (mid * mid == n)
                        return mid;
                    if (p > n)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return right;
            }

        }

        public static class Medium
        {
            public static int FindMin(int[] nums)
            {
                int n = nums.Length - 1;
                int left = 0, right = n;
                int min = int.MaxValue;
                while (left <= right)
                {
                    int mid = (right - left) / 2 + left;
                    int ln = nums[left], rn = nums[right], mn = nums[mid];
                    //if (ln > mn && rn > mn)
                    //{
                    //    return mn;
                    //}
                    if (ln <= mn && mn <= rn)
                    {
                        min = Math.Min(min, ln);
                    }
                    if (ln > mn)
                    {
                        min = Math.Min(min, mn);
                        right = mid - 1;
                    }
                    else
                    {
                        min = Math.Min(min, mn);
                        left = mid + 1;
                    }
                }
                return min;
            }

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

            public static int SingleNonDuplicateRev(int[] nums)
            {
                int left = 0, right = nums.Length - 1;
                while (left <= right)
                {
                    if (left == right) return nums[left];
                    int mid = (left + right) / 2;
                    int ln = nums[mid - 1], rn = nums[mid + 1], mn = nums[mid];
                    if (ln != mn && rn != mn)
                    {
                        return mn;
                    }
                    if (ln == mn)
                    {
                        if ((mid - left - 1) % 2 != 0)
                            right = mid - 2;
                        else
                            left = mid + 1;
                    }
                    else
                    {
                        if ((right - mid + 1) % 2 != 0)
                            left = mid + 2;
                        else
                            right = mid - 1;
                    }
                }
                return -1;
            }

            public static bool SearchMatrix(int[][] mat, int target)
            {
                int m = mat.Length - 1, n = mat[0].Length - 1;
                int sro = -1;
                for (int i = 0; i <= m; i++)
                {
                    if (mat[i][n] == target) return true;
                    if (mat[i][n] > target)
                    {
                        sro = i;
                        break;
                    }
                }
                if (sro == -1)
                    return false;

                int left = 0, right = n, mid = 0;
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    int ln = mat[sro][left], rn = mat[sro][right], mn = mat[sro][mid];
                    if (mn == target)
                        return true;
                    if (mn < target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                int num = mat[sro][mid];
                int col = mid, ro = sro + 1;
                while (col <= n && ro <= m && col >= 0 && ro >= 0)
                {
                    int cn = mat[ro][col];
                    if (cn == target)
                        return true;
                    if (cn < target)
                        ro++;
                    else
                        col--;
                }
                return false;
            }

            public static int MinEatingSpeed(int[] piles, int h)
            {
                int sum = piles.Sum();
                int fixSum = sum, fixH = h;
                int n = piles.Length;
                int[] piles2 = new int[n];
                Array.Sort(piles);
                piles.CopyTo(piles2, 0);
                int min = (sum / h) + 1;
                int ans = min;

                while (sum != 0)
                {
                    while (h != 0)
                    {
                        for (int i = n - 1; i >= 0; i--)
                        {
                            int e = piles[i];
                            if (e != 0)
                            {
                                int q = piles[i] / min;
                                sum -= q == 0 ? piles[i] : piles[i] - (piles[i] % min);
                                h -= q == 0 ? 1 : q;
                                piles[i] = q == 0 ? 0 : piles[i] % min;
                            }
                        }
                        if (sum == 0)
                            return min;
                    }
                    ans = Math.Min(ans, min);
                    sum = fixSum;
                    h = fixH;
                    piles = piles2;
                    min++;
                }
                return min;

            }
        }
    }
}







