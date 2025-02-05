using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures.Arrays;

public static class ArrayMedium
{
    // Brute force approach to set matrix zeroes
    // Time Complexity: O(m*n)
    // Space Complexity: O(m+n)
    public static int[][]? SetMatrixZeroes(int[][] matrix)
    {
        int[][] mat = matrix;
        List<List<int>> list = new List<List<int>>();
        if (mat.Length == 0) return null;

        // Find all zeroes in the matrix
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

        // Set rows and columns to zero based on the found zeroes
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

    // Optimized approach to set matrix zeroes
    // Time Complexity: O(m*n)
    // Space Complexity: O(1)
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

    // Brute force approach to sort colors
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public static int[] SortColorsBtr(int[] nums)
    {
        int[] save = nums;
        if (nums is null || nums.Length < 2) return nums;
        int i = 0, os = 0, ts = 0, zs = 0;

        // Count the number of 0s, 1s, and 2s
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

        // Overwrite the array with the counted numbers
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

    // Optimized approach to sort colors
    // Time Complexity: O(n)
    // Space Complexity: O(1)
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

    // Kadane's algorithm to find the maximum subarray sum
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public static int MaxSubArray(int[] nums)
    {
        int max = int.MinValue;
        int sum = 0;

        // Traverse the array and calculate the maximum subarray sum
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (sum > max) { max = sum; }
            if (sum < 0) { sum = 0; }
        }
        return max;
    }

    // Generate Pascal's Triangle
    // Time Complexity: O(numRows^2)
    // Space Complexity: O(numRows^2)
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

    // Brute force approach to find two sum
    // Time Complexity: O(n)
    // Space Complexity: O(n)
    public static int[] TwoSumBtr(int[] lst, int t)
    {
        List<int> res = new List<int>();
        HashSet<int> set = new HashSet<int>();

        // Traverse the array and find the two numbers that add up to the target
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

    // Optimized approach to find two sum
    // Time Complexity: O(n log n)
    // Space Complexity: O(1)
    public static int[] TwoSumOpt(int[] nums, int target)
    {
        int j = nums.Length - 1; int i = 0;
        Array.Sort(nums);

        // Use two pointers to find the two numbers that add up to the target
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

    // Find the longest consecutive sequence
    // Time Complexity: O(n)
    // Space Complexity: O(n)
    public static int LongestConsecutive(int[] nums)
    {
        if (nums is null || nums.Length == 0) return 0;

        int longestSeqLen = 1, crntSeqLen = 0, min = int.MinValue;
        HashSet<int> set = new();

        // Put all the array elements into set
        foreach (int i in nums)
            if (!set.Contains(i))
                set.Add(i);

        // Find the longest sequence
        foreach (int item in set)
        {
            // If 'item' is a starting number
            if (!set.Contains(item - 1))
            {
                // Find consecutive numbers
                crntSeqLen = 1;
                int x = item;
                while (set.Contains(x + 1))
                {
                    // Keep incrementing the number
                    x++;
                    // Keep incrementing the sequence length
                    crntSeqLen++;
                }
            }
            longestSeqLen = Math.Max(longestSeqLen, crntSeqLen);
        }
        return longestSeqLen;
    }

    // Search in a 2D matrix
    // Time Complexity: O(log(m*n))
    // Space Complexity: O(1)
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length, m = matrix[0].Length;
        int low = 0, high = n * m - 1;

        // Apply binary search
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

    public static int FindDuplicate(int[] nums)
    {
        int slow = nums[0], fast = nums[0];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }
        return slow;
    }

    /*
      Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
    */
    public static int[][] MergeIntervalsBF(int[][] arr)
    {
        int n = arr.Length;
        // Sort the intervals based on the start time
        Array.Sort(arr, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> ans = new List<int[]>();

        for (int i = 0; i < n; i++)
        {
            int start = arr[i][0];
            int end = arr[i][1];

            // Skip merged intervals
            if (ans.Count > 0 && end <= ans[^1][1])
            {
                continue;
            }

            // Merge overlapping intervals
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j][0] <= end)
                {
                    end = Math.Max(end, arr[j][1]);
                }
                else
                {
                    break;
                }
            }

            ans.Add(new int[] { start, end });
        }

        return ans.ToArray();
    }

    public static int[][] MergeIntervalsOptimal(int[][] arr)
    {
        Array.Sort(arr, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> ans = new();

        for (int i = 0; i < arr.Length; i++)
        {
            if (ans.Count == 0 || arr[i][0] > ans[ans.Count - 1][1])
                ans.Add(arr[i]);
            else
                ans[^1][1] = Math.Max(ans[^1][1], arr[i][1]);
        }
        return ans.ToArray();
    }

    /*
     You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

     Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    
     The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
    */
    public static void MergeSortedArraysBF(int[] arr1, int m, int[] arr2, int n)
    {
        if (n == 0) return;
        if (m == 0)
        {
            Array.Resize(ref arr1, n);
            for (int i = 0; i < n; i++)
            {
                arr1[i] = arr2[i];
            }
            return;
        }
        for (int i = 0; i < n; i++)
        {
            arr1[m + i] = arr2[i];
        }
        Array.Sort(arr1);
    }

    public static void MergeSortedArraysOptimal(int[] nums1, int m, int[] nums2, int n)
    {
        int a = m - 1;
        int b = n - 1;
        int c = m + n - 1;

        while (b >= 0)
        {
            if (a >= 0 && nums1[a] > nums2[b])
            {
                nums1[c] = nums1[a];
                a--;
            }
            else
            {
                nums1[c] = nums2[b];
                b--;
            }
            c--;
        }
    }

    /*
     Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
    */
    public static int[] TopKFrequentBF(int[] nums, int k)
    {
        if (nums.Length == 0) return Array.Empty<int>();
        if (nums.Length == 1) return new int[1] { nums[0] };
        if (k == 0) return Array.Empty<int>();

        Dictionary<int, int> frequencyDict = new Dictionary<int, int>();

        // Count the frequency of each element
        foreach (int num in nums)
        {
            if (frequencyDict.ContainsKey(num))
            {
                frequencyDict[num]++;
            }
            else
            {
                frequencyDict[num] = 1;
            }
        }
        frequencyDict = frequencyDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = frequencyDict.ElementAt(i).Key;
        }
        return result;
    }

    // Brute force approach to calculate power
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public static double MyPowBF(double x, int n)
    {
        // If the exponent is 0, return 1
        if (n == 0) return 1.0;

        // If the base is 0 and exponent is positive, return 0
        if (x == 0.0 && n > 0) return 0.0;

        // If the base is 1, return 1
        if (x == 1.0) return x;

        // If the base is -1, return -1 or 1 based on the parity of the exponent
        if (x == -1.0) return (n % 2) == 0 ? x * -1 : x;

        // If the exponent is the minimum value of int, return 0
        if (n == int.MinValue) return 0.0;

        double res = x;
        long pow = Math.Abs((long)n);

        // Multiply the base 'x' 'pow' times
        for (long i = 1; i < pow; i++)
        {
            res *= x;
        }

        // If the exponent is positive, return the result
        // If the exponent is negative, return the reciprocal of the result
        return n > 0 ? res : 1 / res;
    }

    // Optimized approach to calculate power
    // Time Complexity: O(log n)
    // Space Complexity: O(1)
    /*
     4^6 = (4^2)^3 = 16^3, res = 1, x = 16, pow = 3
     16^3 = 16*(16^2), res = 16, x = 16, pow = 2
     16^2 = (16*16)^1 = 256^1, res = 16, x = 256, pow = 1
     256^1 = 256*256^0 , res = 256, x = 256, pow = 0
     */
    public static double MyPowOptimal(double x, int n)
    {
        // If the exponent is 0, return 1
        if (n == 0) return 1.0;

        // If the base is 0 or 1, return the base
        if (x == 0.0 || x == 1.0) return x;

        // If the base is -1, return -1 or 1 based on the parity of the exponent
        if (x == -1.0) return (n % 2) == 0 ? x * -1 : x;

        // If the exponent is the minimum value of int, return 0
        if (n == int.MinValue) return 0.0;

        double res = 1.0;
        long pow = Math.Abs((long)n);

        // Use exponentiation by squaring to calculate the power
        while (pow > 0)
        {
            // If the exponent is even, square the base and halve the exponent
            if (pow % 2 == 0)
            {
                x *= x;
                pow /= 2;
            }
            // If the exponent is odd, multiply the result by the base and decrement the exponent
            else
            {
                res = res * x;
                pow--;
            }
        }

        // If the exponent is positive, return the result
        // If the exponent is negative, return the reciprocal of the result
        return n > 0 ? res : 1 / res;

    }
}
