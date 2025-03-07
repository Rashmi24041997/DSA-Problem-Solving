using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    // Time Complexity: O(n/2)
    // Space Complexity: O(1)
    public static int[] SortColorsOpt(int[] nums)
    {
        // Initialize pointers for low, mid, and high
        int low = 0, mid = 0, high = nums.Length - 1;

        // Iterate until mid pointer crosses high pointer
        while (mid <= high)
        {
            // Use switch-case to handle the value at mid pointer
            switch (nums[mid])
            {
                // If the value is 0, swap it with the value at low pointer
                case 0:
                    {
                        (nums[mid], nums[low]) = (nums[low], nums[mid]);
                        // Increment both mid and low pointers
                        mid++;
                        low++;
                    }
                    break;

                // If the value is 1, just move the mid pointer
                case 1:
                    {
                        mid++;
                    }
                    break;

                // If the value is 2, swap it with the value at high pointer
                case 2:
                    {
                        (nums[mid], nums[high]) = (nums[high], nums[mid]);
                        // Decrement the high pointer
                        high--;
                    }
                    break;
            }
        }
        // Return the sorted array
        return nums;
    }

    /// <summary>
    /// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
    /// topics:sliding window
    /// </summary>
    public static int MaxSubArray(int[] nums)
    {
        int max = int.MinValue;
        int sum = 0;

        // Traverse the array and calculate the maximum subarray sum
        for (int i = 0; i < nums.Length; i++)
        {
            // Add the current element to the sum
            sum += nums[i];

            // Update the maximum sum if the current sum is greater than the maximum sum
            if (sum > max) { max = sum; }

            // If the current sum is less than 0, reset the sum to 0
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

        List<int[]> ans = new();

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

    /*
     Given an array nums of size n, return the majority element.
    The majority element is the element that appears more than ⌊n / 2⌋ times.
    You may assume that the majority element always exists in the array.
    Follow-up: Could you solve the problem in linear time and in O(1) space?
     */
    /// <summary>
    /// Keep track of the frequency of each item and return the item as soon as its frequency crosses n/2 
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public static int MajorityElementBFHashTbl(int[] nums)
    {
        if (nums == null || nums.Length == 0) return -1;
        if (nums.Length == 1) return nums[0];

        int res = -1;
        Dictionary<int, int> freqTbl = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int itm = nums[i];
            if (freqTbl.ContainsKey(itm))
            {
                freqTbl[itm]++;
                int freq = freqTbl[itm];
                if (freq > nums.Length / 2)
                {
                    res = itm;
                    break;
                }
            }
            else
                freqTbl[itm] = 1;
        }
        return res;
    }

    /// <summary>
    /// Keep track of the frequency of each item and return the item as soon as its frequency crosses n/2 
    /// Time Complexity: O(n*logn)+O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public static int MajorityElementSort(int[] nums)
    {
        if (nums == null || nums.Length == 0) return -1;
        if (nums.Length == 1) return nums[0];

        int res = -1;
        Array.Sort(nums);
        int cnt = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                cnt++;
                if (cnt > nums.Length / 2)
                {
                    res = nums[i];
                    break;
                }
            }
            else
            {
                cnt = 1;
            }
        }
        return res;
    }

    public static int MajorityElementSortBtr(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        int half = nums.Length / 2;
        Array.Sort(nums);
        int mid = (nums.Length - 1) / 2, cnt = 1;
        int left = mid - 1, right = mid + 1;
        while (left > -1)
        {
            if (nums[mid] == nums[left])
            {
                if (++cnt > half)
                    return nums[mid];
                left--;
            }
            else
                left = -1;
        }
        while (right < nums.Length)
        {
            if (nums[mid] == nums[right])
            {
                if (++cnt > half)
                    return nums[mid];
                right++;
            }
            else
                right = nums.Length;
        }

        return -1;
    }

    public static int MajorityElementOpt(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int cnt = 0, ele = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (cnt > 0)
            {
                if (ele == nums[i])
                    cnt++;
                else
                    cnt--;
            }
            else
            {
                ele = nums[i];
                cnt++;
            }
        }
        if (cnt > 0) return ele;
        return -1;
    }

    /*
     Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.
     */
    public static IList<int> MajorityElementN3SortBF(int[] nums)
    {
        if (nums.Length == 1) return new List<int>() { nums[0] };

        IList<int> res = new List<int>();
        Array.Sort(nums);
        int cnt = 0, indx = 0;
        if (nums.Length == 2)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                cnt++;
                if (cnt > nums.Length / 3)
                {
                    if (!res.Contains(nums[i]))
                        res.Add(nums[i]);
                    indx++;
                    if (indx > 1) break;
                }
            }
            return res;
        }
        cnt = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            int itm = nums[i];
            if (itm == nums[i - 1])
            {
                cnt++;
                if (cnt > nums.Length / 3)
                {
                    if (!res.Contains(itm))
                    {
                        res.Add(itm);
                        indx++;
                        if (indx > 1) break;
                    }
                    //cnt = 0;
                }
            }
            else
                cnt = 1;
        }
        return res;
    }

    public static IList<int> MajorityElementN3(int[] nums)
    {
        IList<int> res = new List<int>();
        int cnt1 = 0, cnt2 = 0, e1 = int.MinValue, e2 = int.MinValue;
        int n = nums.Length;

        // applying the Extended Boyer Moore's Voting Algorithm:
        for (int i = 0; i < n; i++)
        {
            int val = nums[i];
            if (cnt1 == 0 && val != e2)
            {
                cnt1++;
                e1 = val;
            }
            else if (cnt2 == 0 && val != e1)
            {
                cnt2++;
                e2 = val;
            }
            else if (val == e1)
            {
                cnt1++;
            }
            else if (val == e2)
                cnt2++;
            else
            {
                cnt1--;
                cnt2--;
            }
        }

        // Manually check if the stored elements in
        // el1 and el2 are the majority elements:
        cnt1 = 0; cnt2 = 0;

        for (int i = 0; i < n; i++)
        {
            int val = nums[i];
            if (val == e1) cnt1++;
            if (val == e2) cnt2++;
        }
        if (cnt1 > n / 3)
            res.Add(e1);
        if (cnt2 > n / 3)
            res.Add(e2);
        return res;
    }

    public static int UniquePaths(int m, int n)
    {
        BigInteger m1 = Factorial(m - 1);
        BigInteger n1 = Factorial(n - 1);
        BigInteger mn1 = Factorial(m + n - 2);

        var res = mn1 / (m1 * n1);

        return (int)res;
    }

    static BigInteger Factorial(int n)
    {
        BigInteger result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    /*
     There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

        Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.
        
        The test cases are generated so that the answer will be less than or equal to 2 * 109.
     */
    public static int UniquePathsOpt(int right, int down)
    {
        int n = right + down - 2;
        int r = right - 1;
        if (r == 0 || r == n) return 1;

        double res = 1;

        for (int i = 1; i <= r; i++)
        {
            res = res * (n - r + i) / (i);
        }
        return (int)res;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        int cnt = 1, n = nums.Length;
        int prev = nums[0];
        for (int i = 1; i < n; i++)
        {
            int num = nums[i];
            if (num != prev)
            {
                cnt++;
                nums[cnt - 1] = num;
            }

            if (cnt - 1 != i)
                nums[i] = -101;
            prev = num;
        }
        //for (int i = cnt; i < n; i++)
        //{
        //    nums[i] = -101;
        //}
        return cnt;
    }

    public static int RemoveDuplicatesBtr(int[] nums)
    {
        int i = 0;
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[i] != nums[j])
            {
                i++;
                nums[i] = nums[j];
            }
        }
        return i;
    }

    /*
     Given an integer array nums, 
     return all the triplets [nums[i], nums[j], nums[k]] 
    such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    Solution set must not contain duplicate triplets.
     */
    //public static IList<IList<int>> ThreeSum(int[] nums)
    //{
    //    int i1, i2, i3;
    //    int n = nums.Length;
    //    Dictionary<int, int> set = new();
    //    IList<IList<int>> res = new List<IList<int>>();
    //    for (int i = 0; i < n; i++)
    //    {
    //        int num = nums[i];
    //        if (!set.Contains(num))
    //            set.Add(num);
    //    }
    //    for (int i = 0; i < n - 2; i++)
    //    {
    //        i1 = nums[i];
    //        for (int j = 1; j < n; j++)
    //        {
    //            i2 = nums[j];
    //            i3 = 0 - (i1 + i2);

    //            if (set.Contains(i3))
    //            {
    //                List<int> lst = new() { i1, i2, i3 };
    //                if (!res.Contains(lst))
    //                    res.Add(lst);
    //            }
    //        }
    //    }
    //    return res;
    //}

    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        int i1, i2, i3;
        int n = nums.Length;
        Array.Sort(nums);
        var res = new Dictionary<string, IList<int>>();

        for (int i = 0; i < n - 2; i++)
        {
            //first no.
            i1 = nums[i];
            for (int j = i + 1; j < n; j++)
            {
                //consider next element to nums[i] as second 
                i2 = nums[j];
                //Calculate the 3rd element:
                i3 = 0 - (i1 + i2);

                //Find the element in the array:
                if (BinarySearch(nums, j + 1, n - 1, i3) != -1)
                {
                    //if found, store the triplet uniquely so that it cannot be repeated 
                    List<int> lst = new() { i1, i2, i3 };
                    lst.Sort();
                    string key = string.Join("", lst);
                    if (!res.ContainsKey(key))
                        res.Add(key, lst);
                }
            }
        }
        return res.Values.ToList();
    }

    private static int BinarySearch(int[] arr, int low, int high, int target)
    {
        int mid = (low + high) / 2;
        while (low <= high)
        {
            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
            mid = (low + high) / 2;
        }
        return -1;
    }

    /*
     Given an array of N integers, your task is to find unique triplets that add up to give a sum of zero. In short, you need to return an array of all the unique triplets [arr[a], arr[b], arr[c]] such that i!=j, j!=k, k!=i, and their sum is equal to zero.
    */
    // Time Complexity: O(NlogN)+O(N2), where N = size of the array.
    //Space Complexity: O(no. of triplets),
    public static IList<IList<int>> ThreeSumOpt(int[] nums)
    {
        //First, we will sort the entire array.
        Array.Sort(nums);
        int n = nums.Length;
        IList<IList<int>> res = new List<IList<int>>();

        // i will represent the fixed pointer.
        for (int i = 0; i < n - 2; i++)
        {
            int i1 = nums[i];

            //check if the current and the previous element is the same and if it is we will do nothing and continue to the next value of i.
            if (i != 0 && i1 == nums[i - 1]) continue;

            int left = i + 1; int right = n - 1;
            while (left < right)
            {
                int i2 = nums[left];
                int i3 = nums[right];
                int sum = i1 + i2 + i3;
                //If the sum is equal to the target, we will simply insert the triplet i.e. arr[i], arr[left], arr[right], into our answer and move the pointers left and right skipping the duplicate elements.
                if (sum == 0)
                {
                    res.Add(new List<int> { i1, nums[left], nums[right] });
                    left++;
                    right--;

                    while (left < right && nums[left - 1] == nums[left])
                        left++;
                    while (left < right && nums[right] == nums[right - 1])
                        right--;
                }
                else if (sum < 0)//If the sum is lesser than the target, we need a bigger value and so we will increase the value of j (i.e. left++). 
                    left++;
                else //If the sum is greater, then we need lesser elements and so we will decrease the value of k(i.e. right--). 
                    right--;
            }
        }
        return res;
    }

    /*
     Given an array of N integers, your task is to find unique triplets that add up to give a sum of zero. In short, you need to return an array of all the unique triplets [arr[a], arr[b], arr[c]] such that i!=j, j!=k, k!=i, and their sum is equal to zero.
    */
    // Time Complexity: O(NlogN)+O(N3), where N = size of the array.
    //Space Complexity: O(no. of quadruplets),
    public static IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (nums.Length < 4) return res;
        Array.Sort(nums);
        int n = nums.Length;

        for (int i = 0; i < n - 3; i++)
        {
            long i1 = nums[i];

            // avoid the duplicates while moving i:
            if (i > 0 && i1 == nums[i - 1])
                continue;

            for (int j = i + 1; j < n - 2; j++)
            {
                long i2 = nums[j];

                // avoid the duplicates while moving j:
                if (j > i + 1 && i2 == nums[j - 1])
                    continue;

                // 2 pointers:
                int left = j + 1, right = n - 1;

                while (left < right)
                {
                    long i3 = nums[left];
                    long i4 = nums[right];
                    long sum = i1 + i2 + i3 + i4;

                    if (sum == target)
                    {
                        res.Add(new List<int>() { nums[i], nums[j], nums[left], nums[right] });
                        left++;
                        right--;
                        // skip the duplicates:
                        while (left < right && nums[left - 1] == nums[left])
                            left++;
                        while (left < right && nums[right] == nums[right + 1])
                            right--;
                    }
                    else if (sum > target)
                        right--;
                    else
                        left++;
                }
            }
        }
        return res;
    }

    /*
     * search an item in sorted array possibly rotated
     */

    //Calculate the ‘mid’
    //
    public static int SearchOpt(int[] nums, int target)
    {
        //Place the 2 pointers i.e. left and right  
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int l = nums[left], r = nums[right], m = nums[mid];
            //Check if arr[mid] == target:
            if (m == target)
            {
                return mid;
            }
            // ensure that the left part is sorted
            if (l <= m)
            {
                if (l == target)
                {
                    return left;
                }
                // the target is in this sorted half. So, we will eliminate the right half (right = mid-1).
                if (l < target && target < m)
                {
                    right = mid - 1;
                }
                //the target does not exist in the sorted half. So, we will eliminate this left half by doing left = mid+1.
                else
                    left = mid + 1;
            }
            //Otherwise, if the right half is sorted
            // the target is in this sorted right half. So, we will eliminate the left half (left = mid+1).
            else if (m < target && target <= r)
            {
                if (r == target)
                {
                    return right;
                }
                //the target does not exist in this sorted half. So, we will eliminate this right half by doing right = mid-1.
                else
                    left = mid + 1;
            }
            else
                right = mid - 1;

        }
        return -1;
    }


    public static int SubarraySum(int[] nums, int k)
    {
        int ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int sum = nums[i];
            if (sum == k)
            {
                ans++;
            }
            //if (sum < k)
            for (int j = i + 1; j < n; j++)
            {
                sum += nums[j];
                if (sum == k)
                {
                    ans++;
                }
            }
        }
        return ans;
    }


    /*
Create an integer arrayrightMaxof lengthn.

Set rightMax[n - 1] to nums[n - 1], set suffixSum to nums[n - 1].

Iterate over i from n - 2 to 0

Increase suffixSum by nums[i]
Update rightMax[i] to max(rightMax[i + 1], suffixSum)
Set maxSum and prefixSum to nums[0].

Iterate over i from 0 to n - 2

Increase prefixSum by nums[i]
Update specialSum to max(specialSum, prefixSum + rightMax[i + 1]).
Calculate the normalsum, maxSum using Kadane's algorithm.

Return max(maxSum, specialSum)
Time complexity:O(N).
Space complexity:O(N).
*/
    public static int MaxSubarraySumCircular(int[] nums)
    {
        int n = nums.Length;
        int[] rightMax = new int[n];
        rightMax[n - 1] = nums[n - 1];
        int suffixSum = nums[n - 1];

        for (int i = n - 2; i >= 0; --i)
        {
            suffixSum += nums[i];
            rightMax[i] = Math.Max(rightMax[i + 1], suffixSum);
        }

        int maxSum = nums[0];
        int specialSum = nums[0];
        int curMax = 0;
        for (int i = 0, prefixSum = 0; i < n; ++i)
        {
            // This is Kadane's algorithm.
            curMax = Math.Max(curMax, 0) + nums[i];
            maxSum = Math.Max(maxSum, curMax);

            prefixSum += nums[i];
            if (i + 1 < n)
            {
                specialSum = Math.Max(specialSum, prefixSum + rightMax[i + 1]);
            }
        }
        return Math.Max(maxSum, specialSum);
    }

    public static int MaxSubarraySumCircularOpt(int[] nums)
    {
        int curMax = 0;
        int curMin = 0;
        int maxSum = nums[0];
        int minSum = nums[0];
        int totalSum = 0;
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            // Normal Kadane's
            curMax = Math.Max(curMax, 0) + num;
            maxSum = Math.Max(curMax, maxSum);

            // Kadane's but with min to find minimum subarray
            curMin = Math.Min(curMin, 0) + num;
            minSum = Math.Min(curMin, minSum);

            totalSum += num;
        }
        if (totalSum == minSum)
            return maxSum;
        ans = Math.Max(maxSum, totalSum - minSum);
        return ans;
    }


    public static int CountArrays(int[] original, int[][] bounds)
    {
        int cnt = 0;
        int n = original.Length;
        List<List<int>> temp = new(n);
        for (int i = 1; i < n; i++)
        {
            int diff = original[i] - original[i - 1];
            List<int> lst = new();
            int lB = bounds[i - 1][0];
            int uB = bounds[i][1];
            int strt = lB + diff;
            if (diff > bounds[i][1])
                return 0;
            for (int j = Math.Max(strt, lB), k = 0; j <= uB; j++, k++)
            {
                if (i == 1)
                    lst = new();
                else if (temp.Count - 1 >= k)
                    lst = temp[k];
                else
                    continue;

                if (lst.Count > i - 1)
                {
                    int p = lst[i - 1];
                    if (p + diff == j)
                        lst.Add(j);
                }
                else
                {
                    int p = j - diff;
                    if (p > bounds[i - 1][1]) break;
                    if (p >= bounds[i - 1][0])
                    {
                        lst.Add(p);
                        lst.Add(j);
                    }
                }
                if (i == 1 && lst.Count > 1)
                    temp.Add(lst);
                if (lst.Count == n)
                    cnt++;
            }
            if (temp.Count == 0) return 0;
        }
        return cnt;
    }


    public static int LargestInteger(int[] nums, int k)
    {
        Dictionary<int, int> set = new();
        int ans = -1;
        for (int i = 0; i <= nums.Length - k; i++)
        {
            for (global::System.Int32 j = i; j < i + k; j++)
            {
                int num = nums[j];
                if (!set.ContainsKey(num))
                    set.Add(num, 1);
                else if (i > 0)
                    set[num]++;
            }
        }
        foreach (KeyValuePair<int, int> item in set)
        {
            if (item.Value == 1)
            {
                ans = Math.Max(ans, item.Key);
            }
        }
        return ans;
    }


    public static int CountArraysCopy(int[] original, int[][] bounds)
    {
        int n = original.Length;
        int ans = int.MaxValue;
        int preMin = bounds[0][0], preMax = bounds[0][1], currLB, currUB;
        for (int i = 1; i < n; i++)
        {
            int diff = original[i] - original[i - 1];
            if (diff > bounds[i][1])
                return 0;
            int strt = preMin + diff;
            int end = preMax + diff;
            currUB = Math.Min(bounds[i][1], end);
            currLB = Math.Max(strt, bounds[i][0]);
            if (currLB > currUB) return 0;
            ans = Math.Min(currUB - currLB + 1, ans);
            preMin = currLB;
            preMax = currUB;
        }
        return ans;
    }

    public static int CountArraysCopyVks(int[] original, int[][] bounds)
    {
        List<int> meriList = new List<int>();
        for (int j = bounds[0][0]; j <= bounds[0][1]; j++)
        {
            int newValue = j + (original[1] - original[0]);
            if (newValue >= bounds[1][0] && newValue <= bounds[1][1])
            {
                meriList.Add(newValue);
            }
        }

        for (int i = 2; i < original.Length; i++)
        {
            List<int> answer = new List<int>();
            foreach (int j in meriList)
            {
                int newValue = j + (original[i] - original[i - 1]);
                if (newValue >= bounds[i][0] && newValue <= bounds[i][1])
                {
                    answer.Add(newValue);
                }
            }
            meriList = answer;
        }
        return meriList.Count;
    }

    public static int MaxLen(List<int> arr)
    {
        int maxLen = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            int subArrSum = 0;
            int subArrLen = 0;
            for (int j = i; j < arr.Count; j++)
            {
                subArrSum += arr[j];
                subArrLen++;
                if (subArrSum == 0)
                    maxLen = Math.Max(maxLen, subArrLen);
            }
        }
        return maxLen;
    }
}


