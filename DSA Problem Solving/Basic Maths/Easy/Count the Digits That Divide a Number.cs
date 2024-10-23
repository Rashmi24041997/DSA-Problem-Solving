using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Basic_Maths.Easy
{
    public static class Count_the_Digits_That_Divide_a_Number
    {
        /*
         2520. Count the Digits That Divide a Number
Given an integer num, return the number of digits in num that divide num.

An integer val divides nums if nums % val == 0.

 

Example 1:

Input: num = 7
Output: 1
Explanation: 7 divides itself, hence the answer is 1.*/
        public static int CountDigits(int num)
        {
            if (num > -4 && num < 4) return num;
            int div = num;
            int rest = 0;
            int cnt = 0;
            while (div > 0)
            {
                rest = div % 10;
                Console.WriteLine(rest);
                div = div / 10;
                if (rest <= 1) continue;
                if (num % rest == 0)
                    cnt++;

            }
            return cnt;
        }
    }

    public static class CheckPalindrome
    {
        public static bool Sol(int div)
        {
            if (div < 0) return false;
            if (div >= 0 && div <= 9) return true;
            int revNum = 0;
            int n = div;
            // Start a while loop to reverse the
            // digits of the input integer.
            while (n != 0)
            {
                // Extract the last digit of
                // 'n' and store it in 'ld'.
                int ld = n % 10;
                revNum = (revNum * 10) + ld;
                // Remove the last digit from 'n'.
                n = n / 10;
            }
            return revNum == div;
        }
    }

    public static class FindGCD
    {
        public static long Sol(long n1, long n2)
        {
            while (n1 > 0 && n2 > 0)
            {
                if (n1 > n2)
                    n1 = n1 % n2;
                if (n2 > n1)
                    n2 = n2 % n1;
            }
            if (n1 == 0) return n2;
            return n1;
        }
    }
    public static class IsArmstrong
    {
        public static bool Sol(int n)
        {
            int d = n; int cnt = 0;
            int sum = 0;
            List<int> digs = new();
            while (d > 0)
            {
                int r = d % 10;
                digs.Add(r);
                cnt++;
                d = d / 10;
            }
            digs.ForEach(i => sum += (int)Math.Pow(i, cnt));
            return sum == n;
        }
    }
}
