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

    public static class ReverseBits
    {
        public static int Sol(int div)
        {
            if (div >= -9 && div <= 9) return div;
            int revNum = 0;
            int n =div;
            int mx = Int32.MaxValue;
            int mn = Int32.MinValue;
            // Start a while loop to reverse the
            // digits of the input integer.
            while (n != 0)
            {
                // Extract the last digit of
                // 'n' and store it in 'ld'.
                int ld = n % 10;
                // Multiply the current reverse number
                // by 10 and add the last digit.
                if (revNum > 0 && (revNum > (mx / 10) || (revNum == mx / 10 && ld > 7)))
                {
                    return 0;
                }
                if (revNum < (mn / 10) || (revNum == mn / 10 && ld < -8))
                {
                    return 0;
                }
                revNum = (revNum * 10) + ld;
                // Remove the last digit from 'n'.
                n = n / 10;
            }
            return revNum ;
        }
    }
}
