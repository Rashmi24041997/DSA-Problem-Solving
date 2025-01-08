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
        public static bool checkKthBit(int n, int k)
        {
            //left shift 1 kth times, that makes its kth bit 1 and all other bits 0. if n's kth bit is 1, '&' will return 1 else 0
            return (n & (1 << k)) != 0;
        }

        /// <summary>
        /// Given an integer n, return true if it is a power of two. Otherwise, return false.
        /// An integer n is a power of two, if there exists an integer x such that n == 2x.
        /// </summary>
        public bool IsPowerOfTwo(int n)
        {
            //if n is less than 1, it can't be a power of 2
            if (n < 1) return false;

            //if n is a power of 2, it will have only 1 bit set. So, n & (n-1) will be 0
            return (n & (n - 1)) == 0;
        }

        public static int countSetBits(int n)
        {
            int cnt = 0;
            while (n != 1)
            {
                int p = n;
                while (p != 1)
                {
                    if (p % 2 == 1) cnt++;
                    p /= 2;
                }
                cnt++;
                n -= 1;
            }
            return ++cnt;
            // Your code here

        }

        public static bool isEven(int n)
        {
            // code here
            return (n & 1) == 0;
        }

        public static int setBit(int n)
        {
            // code here
            return n | (n + 1);
        }

        public static int UnsetBit(int n)
        {
            // code here
            return n & (n - 1);
        }

        public static List<int> get(int a, int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            return new List<int>() { a, b };
        }
    }

    public class Medium
    {

        public static IList<IList<int>> Subsets(int[] nums)
        {
            if (nums == null) return null;
            IList<IList<int>> subsets = new List<IList<int>>() { };
            double n = Math.Pow(2, nums.Length);

            for (int i = 0; i < n; i++)
            {
                List<int> list = new();
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                        list.Add(nums[j]);
                }
                subsets.Add(list);
            }
            return subsets;
        }


        public static int MinBitFlips(int start, int goal)
        {
            //return 0 if both are equal
            if (start == goal) return 0;

            //get max no. of bits to cover by choosing max of both. Multiply the max by 2 to cover the last bit too.
            int max = Math.Max(start, goal) * 2;

            //cnt is the count of flips, i is the index of the bit we are covering
            int cnt = 0, i = 0;

            //cover till last bit
            while (max != 1)
            {
                //left shifting 1 by ith index will cover each index. '&' gives us the bit at index i
                //i.e 0 & 1 = 1, 1 & 1 = 1, 110 & 1 = 110
                //then perform xor to check if bit should be flipped,
                //i. e., 1^0 = 1 !=0 =>flip, 1^1 or 0^0 == 0 ==0=> not flip
                //this way will check that ith bit of start needs to be flipped or not to reach the goal
                if (((start & (1 << i)) ^ (goal & (1 << i))) != 0)
                    cnt++;

                i++;
                max /= 2;

            }
            return cnt;
        }
    }
}
