using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

    public static void RotateImg(int[][] a)
    {
        int[][] s = a;
        a = s;
        int n = a.Length, ni, nj;
        try
        {
            if (a is null || a.Length <= 1) return;
            for (int r = a.Length - 1; r > 0; r -= 2)
            {
                for (int k = ((n - r - 1) / 2); k <= r; k++)
                {
                    int i = r;
                    int j = k;
                    int temp = a[i][j], save = 0;

                    for (int m = 1; m < 5; m++)
                    {
                        ni = j; nj = (n - 1) - i;
                        save = a[ni][nj];
                        a[ni][nj] = temp;
                        temp = save;
                        i = ni; j = nj; ni = j; nj = (n - 1) - i;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
        }
    }

    public static int[][] RotateImgOpt(int[][] a)
    {
        int n = a.Length, n1 = n - 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int temp = a[i][j];
                a[i][j] = a[j][i];
                a[j][i] = temp;
            }
        }

        for (int i = 0; i < n ; i++)
        {
            for (int j = 0; j < n/ 2; j++)
            {
                int temp = a[i][j];
                a[i][j] = a[i][n1 - j];
                a[i][n1 - j] = temp;
            }
        }
        return a;
    }
    private static void Swap(int n, int i, int j, int ni, int nj, int[][] a)
    {

    }
}
