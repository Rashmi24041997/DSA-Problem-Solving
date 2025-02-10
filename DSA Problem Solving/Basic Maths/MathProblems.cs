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
