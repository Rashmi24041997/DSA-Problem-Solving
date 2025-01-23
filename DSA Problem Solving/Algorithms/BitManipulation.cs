using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms;

public class BitManipulation
{
    public class Easy
    {
        /// <summary>
        /// Given a number n and a bit number k, check if the kth index bit of n is set or not. A bit is called set if it is 1. 
        /// The position of set bit '1' should be indexed starting with 0 from the LSB side in the binary representation of the number.
        /// Note: Index is starting from 0. You just need to return true or false.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="k">The bit position to check.</param>
        /// <returns>True if the kth bit is set, otherwise false.</returns>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        public static bool checkKthBit(int n, int k)
        {
            // Left shift 1 by k positions to create a mask with only the kth bit set.
            // Perform bitwise AND with n to check if the kth bit is set.
            return (n & (1 << k)) != 0;
        }

        /// <summary>
        /// Given an integer n, return true if it is a power of two. Otherwise, return false.
        /// An integer n is a power of two, if there exists an integer x such that n == 2^x.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <returns>True if n is a power of two, otherwise false.</returns>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        public bool IsPowerOfTwo(int n)
        {
            // If n is less than 1, it can't be a power of 2.
            if (n < 1) return false;

            // If n is a power of 2, it will have only 1 bit set. So, n & (n-1) will be 0.
            return (n & (n - 1)) == 0;
        }

        /// <summary>
        /// Count the number of set bits (1s) in the binary representation of a number.
        /// </summary>
        /// <param name="n">The number to count set bits in.</param>
        /// <returns>The count of set bits.</returns>
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        public static int countSetBits(int n)
        {
            int cnt = 0;
            // Iterate until n becomes 1.
            while (n != 1)
            {
                int p = n;
                // Count the number of 1s in the binary representation of p.
                while (p != 1)
                {
                    if (p % 2 == 1) cnt++;
                    p /= 2;
                }
                cnt++;
                n -= 1;
            }
            return ++cnt;
        }

        /// <summary>
        /// Check if a number is even.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <returns>True if the number is even, otherwise false.</returns>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        public static bool isEven(int n)
        {
            // Check the least significant bit. If it is 0, the number is even.
            return (n & 1) == 0;
        }

        /// <summary>
        /// Set the rightmost unset bit of a number.
        /// </summary>
        /// <param name="n">The number to modify.</param>
        /// <returns>The number with the rightmost unset bit set.</returns>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        public static int setBit(int n)
        {
            // Set the rightmost unset bit by performing bitwise OR with n + 1.
            return n | (n + 1);
        }

        /// <summary>
        /// Unset the rightmost set bit of a number.
        /// </summary>
        /// <param name="n">The number to modify.</param>
        /// <returns>The number with the rightmost set bit unset.</returns>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        public static int UnsetBit(int n)
        {
            // Unset the rightmost set bit by performing bitwise AND with n - 1.
            return n & (n - 1);
        }

        /// <summary>
        /// Swap two numbers without using a temporary variable.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>A list containing the swapped numbers.</returns>
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        public static List<int> get(int a, int b)
        {
            // Swap a and b using XOR.
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            return new List<int>() { a, b };
        }
    }

    public class Medium
    {
        /// <summary>
        /// Generate all possible subsets of a given set of numbers.
        /// </summary>
        /// <param name="nums">The array of numbers.</param>
        /// <returns>A list of all possible subsets.</returns>
        /// Time Complexity: O(2^n)
        /// Space Complexity: O(2^n)
        public static IList<IList<int>> Subsets(int[] nums)
        {
            if (nums == null) return null;
            IList<IList<int>> subsets = new List<IList<int>>() { };
            double n = Math.Pow(2, nums.Length);

            // Iterate through all possible combinations.
            for (int i = 0; i < n; i++)
            {
                List<int> list = new();
                // Check each bit to determine if the corresponding element should be included in the subset.
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                        list.Add(nums[j]);
                }
                subsets.Add(list);
            }
            return subsets;
        }

        /// <summary>
        /// Calculate the minimum number of bit flips required to convert one number to another.
        /// </summary>
        /// <param name="start">The starting number.</param>
        /// <param name="goal">The goal number.</param>
        /// <returns>The minimum number of bit flips required.</returns>
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        public static int MinBitFlips(int start, int goal)
        {
            // Return 0 if both numbers are equal.
            if (start == goal) return 0;

            // Get the maximum number of bits to cover by choosing the maximum of both numbers.
            int max = Math.Max(start, goal) * 2;

            int cnt = 0, i = 0;

            // Iterate from the rightmost to the leftmost bit.
            while (max != 1)
            {
                // Check if the ith bit of start needs to be flipped to reach the goal.
                if (((start & (1 << i)) ^ (goal & (1 << i))) != 0)
                    cnt++;

                i++;
                max /= 2;
            }
            return cnt;
        }

        /// <summary>
        /// Divide two integers without using multiplication, division, and mod operator.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The quotient after division.</returns>
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        public static int Divide(int dividend, int divisor)
        {
            if (dividend == divisor) return 1; // Special case: if dividend equals divisor, return 1

            // Determine the sign of the result.
            bool sign = (dividend >= 0) == (divisor >= 0);

            // Convert to long to handle overflow and use absolute values.
            long n = Math.Abs((long)dividend);
            long d = Math.Abs((long)divisor);

            long quotient = 0; // Initialize quotient.

            // Perform division using bit manipulation.
            while (n >= d)
            {
                int cnt = 0; // Count the number of left shifts.

                // Find the largest power of 2 of divisor that fits in dividend.
                while (n >= (d << (cnt + 1)))
                {
                    cnt++;
                }

                quotient += (1L << cnt); // Add the calculated power of 2 to the quotient.
                n -= (d << cnt); // Subtract the calculated value from dividend.
            }

            // Handle overflow cases.
            if (quotient > int.MaxValue)
            {
                return sign ? int.MaxValue : int.MinValue;
            }

            return sign ? (int)quotient : (int)-quotient; // Apply the correct sign and return.
        }
    }
}
