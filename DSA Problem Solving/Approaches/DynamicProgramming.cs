using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Approaches;

public class DynamicProgramming
{
    public class Easy
    {
        public int UniquePathsWithObstacles(int[][] maze)
        {
            int m = maze.Length, n = maze[0].Length;
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = -1;

            return mazeObstacleUtil(m - 1, n - 1, maze, dp);
        }

        private int mazeObstacleUtil(int i, int j, int[][] maze, int[,] dp)
        {
            if (i >= 0 && j >= 0 && maze[i][j] == -1)
                return 0;
            if (i == 0 && j == 0)
                return 1;
            if (i < 0 || j < 0)
                return 0;
            if (dp[i, j] != -1)
                return dp[i, j];
            int up = mazeObstacleUtil(i - 1, j, maze, dp);
            int left = mazeObstacleUtil(i, j - 1, maze, dp);

            dp[i, j] = up + left;
            return dp[i, j];

        }
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

