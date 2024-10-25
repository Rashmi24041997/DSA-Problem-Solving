using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures.Arrays;

public static class ArrayMedium
{
    public static int[][]? SetMatrixZeroes(int[][] matrix)
    {
        int[][] mat = matrix;
        List<List<int>> list = new List<List<int>>();
        if (mat.Length == 0) return null;

        for (int i = 0, a = 0; i < mat.Length; i++, a++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    list.Add(new List<int> { i, j });
                }
            }
        }
        foreach (List<int> cos in list)
        {
            int r = cos[0];
            int c = cos[1];
            int i = 0, j = 0;
            while (i < mat.Length || j < mat[0].Length)
            {
                if (j < mat[0].Length)
                {
                    mat[r][j] = 0;
                    j++;
                }
                if (i < mat.Length)
                {
                    mat[i][c] = 0;
                    i++;
                }
            }
        }
        return mat;
    }

    public static int[][]? SetMatrixZeroesOpt(int[][] matrix)
    {
        int col0 = 1;
        int n = matrix.Length, m = matrix[0].Length;
        // Step 1: Traverse the matrix and mark the 1st row & column accordingly
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i][j] == 0)
                {
                    // Mark i-th row
                    matrix[i][0] = 0;

                    // Mark j-th column
                    if (j != 0)
                        matrix[0][j] = 0;
                    else
                        col0 = 0;
                }
            }
        }

        // Step 2: Mark with 0 from (1,1) to (n-1, m-1)
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                if (matrix[i][j] != 0)
                {
                    // Check for col & row
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        // Step 3: Finally mark the 1st row and then the 1st column
        if (matrix[0][0] == 0)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[0][j] = 0;
            }
        }

        if (col0 == 0)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i][0] = 0;
            }
        }

        return matrix;
    }

    public static int[] SortColorsBtr(int[] nums)
    {
        int[] save = nums;
        if (nums is null || nums.Length < 2) return nums;
        int i = 0, os = 0, ts = 0, zs = 0;

        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] == 0)
            {
                zs++;
            }
            else if (nums[j] == 1)
            {
                os++;
            }
            else if (nums[j] == 2)
            {
                ts++;
            }
        }
        for (int j = 0; zs > 0 && j < nums.Length; j++)
        {
            nums[j] = 0;
            i++; zs--;
        }
        for (int j = i; os > 0 && j < nums.Length; j++)
        {
            nums[j] = 1;
            i++; os--;
        }
        for (int j = i; ts > 0 && j < nums.Length; j++)
        {
            nums[j] = 2;
            i++; ts--;
        }
        return nums;
    }

    public static int[] SortColorsOpt(int[] nums)
    {
        int low = 0, mid = 0, high = nums.Length - 1;
        while (mid <= high)
        {
            switch (nums[mid])
            {
                case 0:
                    {
                        (nums[mid], nums[low]) = (nums[low], nums[mid]);
                        mid++; low++;
                    }
                    break;
                case 1:
                    {
                        mid++;
                    }
                    break;
                case 2:
                    {
                        (nums[mid], nums[high]) = (nums[high], nums[mid]);
                        high--;
                    }
                    break;
            }
        }
        return nums;
    }

    private static void Method()
    { }

}

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
