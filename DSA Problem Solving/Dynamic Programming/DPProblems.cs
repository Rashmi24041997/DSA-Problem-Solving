using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Dynamic_Programming;

public class DPProblems
{
    public class Easy
    {
    }
    public class Medium
    {
        public int Rob(int[] nums)
        {
            int pre1 = nums[0], pre2 = nums[1], sum = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                sum = Math.Max(pre1, pre2 + nums[i]);
                pre2 = pre1;
                pre1 = sum;
            }
            return pre1;
        }

        //213. House Robber II
        public static int RobII(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            int sum1 = RobHelper(nums, 0, nums.Length - 1);
            int sum2 = RobHelper(nums, 1, nums.Length);
            return Math.Max(sum1, sum2);
        }

        private static int RobHelper(int[] nums, int strt, int end)
        {
            int pre1 = 0, pre2 = 0, sum = 0;
            for (int i = strt; i < end; i++)
            {
                sum = Math.Max(pre1, pre2 + nums[i]);
                pre2 = pre1;
                pre1 = sum;
            }
            return pre1;
        }
    }
    public class Hard
    {
    }
}

