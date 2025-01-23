using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms
{
    internal class BinarySearch
    {
        class Easy
        {
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
                    // If mid^n is greater than m, adjust high
                    if (res == 2)
                        high = mid - 1;
                    // If mid^n is less than m, adjust low
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
    }
}







