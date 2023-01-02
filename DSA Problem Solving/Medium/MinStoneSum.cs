using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Medium
{
    public class MinStoneSum

    {
        public static int Solution(int[] piles, int k)
        {
            Array.Sort(piles);
            int sum = 0, sub = 0, t = 0;
            bool flag = false;
            while (t < k)
            {
                for (int i = piles.Length - 1; i >= 0; i--)
                {
                    if (!flag) sum += piles[i];
                    if ((t < k) && (piles[i] != 1 || piles[i] != -1))
                    {
                        int min = (int)Math.Floor(Convert.ToDecimal(piles[i] / 2));
                        piles[i] -= min;
                        sub += min;
                        t++;
                    }
                }
                flag = true;
            }
            return sum - sub;
        }
    }
}
