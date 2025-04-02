using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Basic_Maths
{
    public class MathProblems
    {
        public class Easy
        {
            // Complete this function
            public static long sumOfDivisors(long n)
            {
                long sum = 1;
                for (long i = 2; i <= n; i++)
                {
                    long currSum = 1;

                    for (long j = 2; j <= i; j++)
                        if (i % j == 0)
                            currSum += j;

                    sum += currSum;
                }
                return sum;
            }


            public static int[] lcmAndGcd(int a, int b)
            {
                int cmn = 1;
                int max = Math.Max(a, b);
                int min = Math.Min(a, b);
                if (max % min == 0) return new int[2] { max, min };

                int[] ans = new int[2] { 1, 1 };
                ans[0] = CalculateLCM(max, min);
                ans[1] = CalculateHCF(max, min);
                return ans;
            }

            private static int CalculateLCM(int max, int min)
            {
                for (int i = min * ((max / min) + 1); i <= max * min; i += min)
                {
                    if (i % max == 0)
                        return i;
                }
                return 1;
            }

            private static int CalculateHCF(int max, int min)
            {
                for (int i = min / 2; i > 1; i++)
                {
                    if (max % i == 0 && min % i == 0)
                        return i;
                }
                return 1;
            }

            //Given an integer n, return the number of prime numbers that are strictly less than n.
            //TC: O(n*Sqrt(n)) SC:O(1)
            public static int CountPrimesBF(int n)
            {
                if (n < 3) return 0;
                if (n == 3) return 1;
                int cnt = 1;
                //CHECKING For only odd numbers as even no. except 2 are non-prime
                for (int i = 3; i < n; i += 2)
                {
                    bool isPrime = true;
                    //if the no. is divisible by less than its square root, it is non-prime.
                    //square root of odd no. will always be odd, so check with odd no. only
                    for (int j = 3; j * j <= i; j += 2)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                        cnt++;
                }
                return cnt;
            }

            public static int CountPrimesOpt(int n)
            {

                // Create a boolean array "prime[0..n]" and initialize all entries it as true.
                // A value in prime[i] will finally be false if i is Not a prime, else true.
                if (n < 3) return 0;
                if (n == 3) return 1;
                int cnt = 0;
                bool[] prime = new bool[n + 1];

                for (int i = 0; i <= n; i++)
                    prime[i] = true;

                for (int p = 2; p * p <= n; p++)
                {
                    // If prime[p] is not changed,
                    // then it is a prime
                    if (prime[p] == true)
                    {
                        // Update all multiples of p
                        for (int i = p * p; i <= n; i += p)
                            prime[i] = false;
                    }
                }

                // Print all prime numbers
                for (int i = 2; i < n; i++)
                {
                    if (prime[i] == true)
                        cnt++;
                }
                return cnt;
            }
        }
    }
}
