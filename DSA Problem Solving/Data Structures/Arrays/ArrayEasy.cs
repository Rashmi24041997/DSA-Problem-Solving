using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures.Arrays.Easy
{
    public static class ArrayEasy
    {
        public static int MaxProfit(int[] prices)
        {
            if (!(prices?.Length > 0)) return 0;
            int max = 0, min = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                //try to find the min price to buy
                min = Math.Min(min, prices[i]);
                int diff = prices[i] - min;

                //find the max profit
                max = Math.Max(max, diff);
            }
            return max;
        }
    }

}
