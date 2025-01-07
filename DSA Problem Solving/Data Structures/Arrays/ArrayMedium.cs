﻿using System;
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

    public static int MaxSubArray(int[] nums)
    {
        int max = int.MinValue;

        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (sum > max) { max = sum; }
            if (sum < 0) { sum = 0; }
        }
        return max;
    }

    public static IList<IList<int>> PascalTriangle(int numRows)
    {

        if (numRows < 0) return null;
        IList<IList<int>> lst = new List<IList<int>>();
        if (numRows >= 1)
        {
            lst.Add(new List<int>() { 1 });
        }
        if (numRows >= 2)
        {
            lst.Add(new List<int>() { 1, 1 });
        }
        if (numRows >= 3)
        {
            for (int i = 2; i < numRows; i++)
            {
                List<int> c = new();
                List<int> p = (List<int>)lst.ElementAt(i - 1);
                c.Add(1);

                for (int j = 1; j <= p.Count - 1; j++)
                {
                    c.Add(p[j - 1] + p[j]);
                }
                c.Add(1);
                lst.Add(c);
            }
        }
        return lst;
    }

    public static int[] TwoSumBtr(int[] lst, int t)
    {
        List<int> res = new List<int>();
        HashSet<int> set = new HashSet<int>();

        foreach (int i in lst)
        {
            int r = t - i;
            if (set.Contains(r))
            {
                res.Add(i);
                res.Add(r);
                return res.ToArray();
            }
            set.Add(i);
        }
        return new int[] { -1, -1 };
    }

    public static int[] TwoSumOpt(int[] nums, int target)
    {
        int j = nums.Length - 1; int i = 0;
        Array.Sort(nums);
        while (i != j)
        {
            int l = nums[i];
            int r = nums[j];
            int sum = l + r;
            if (sum == target)
            {
                return new int[] { i, j };
            }
            else if (sum >= target) { j--; }
            else if (sum <= target) { i++; }
        }
        return new int[] { -1, -1 };
    }

    public static int LongestConsecutive(int[] nums)
    {
        if (nums is null || nums.Length == 0) return 0;

        int longestSeqLen = 1, crntSeqLen = 0, min = int.MinValue;

        HashSet<int> set = new();

        // put all the array elements into set
        foreach (int i in nums)
            if (!set.Contains(i))
                set.Add(i);

        // Find the longest sequence
        foreach (int item in set)
        {
            // if 'item' is a starting number
            if (!set.Contains(item - 1))
            {
                // find consecutive numbers
                crntSeqLen = 1;
                int x = item;
                while (set.Contains(x + 1))
                {
                    //keep increment the number
                    x++;
                    //keep increment the sequence length
                    crntSeqLen++;
                }
            }
            longestSeqLen = Math.Max(longestSeqLen, crntSeqLen);
        }
        return longestSeqLen;
    }

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length, m = matrix[0].Length;
        int low = 0, high = n * m - 1;
        //apply binary search:
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int row = mid / m, col = mid % m;
            int itm = matrix[row][col];
            if (itm == target)
            {
                return true;
            }
            if (target < itm)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return false;
    }
}
