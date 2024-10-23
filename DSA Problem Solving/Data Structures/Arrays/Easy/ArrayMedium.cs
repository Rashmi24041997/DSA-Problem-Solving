using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures.Arrays.Easy;

public static class ArrayMedium
{
    public static int[][]? SetMatrixZeroes(int[][] matrix)
    {
        int[][] mat = matrix;
        int[,] save = new int[mat.Length, 2];
        if (mat.Length == 0) return null;

        for (int i = 0, a = 0; i < mat.Length; i++, a++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    save[a, 0] = i;
                    save[a, 1] = j;
                }
                else
                {
                    save[a, 0] = -1;
                    save[a, 1] = -1;
                }
            }
        }
        for (int a = 0; a < save.Length; a++)
        {
            int r = save[a, 0];
            int c = save[a, 1];
            int i = 0, j = 0;
            while (i < mat.Length && j < mat[0].Length)
            {
                mat[r][j] = 0;
                mat[i][c] = 0;
                i++; j++;
            }
        }
        return mat;
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
