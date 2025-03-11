using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures.Arrays.Easy
{
    public class ArrayEasy
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

        /*
         Given a binary array nums, return the maximum number of consecutive 1's in the array.
        */
        public static int FindMaxConsecutiveOnesBF(int[] nums)
        {
            int cnt = 0;
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    cnt++;
                    res = Math.Max(cnt, res);
                }
                else
                    cnt = 0;
            }
            return res;
        }

        public static bool Check(int[] nums)
        {
            bool sorted = true;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                    return false;
            }
            return true;
        }
        /*1752.
         * Check if Array Is Sorted and Rotated
        Given an array nums, return true if the array was originally sorted in non-decreasing order, then rotated some number of positions (including zero). Otherwise, return false.
        */
        public static bool CheckPracticeBF(int[] nums)
        {
            int n = nums.Length;
            List<int> lst = new(nums);
            lst.Sort();
            for (int i = 0; i < n; i++)
            {
                bool isRotan = true;
                int num = lst[0];
                lst.RemoveAt(0);
                lst.Add(num);
                for (global::System.Int32 j = 0; j < n; j++)
                {
                    if (nums[j] != lst[j])
                    {
                        isRotan = false;
                        break;
                    }
                }
                if (isRotan)
                    return isRotan;
            }
            return false;
        }
        public static bool CheckPracticeOpt(int[] nums)
        {
            int breaks = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > nums[i + 1])
                    breaks++;
                if (breaks > 1)
                    return false;
            }
            if (nums[^1] > nums[0])
                breaks++;
            if (breaks > 1)
                return false;
            return true;
        }
    }
    public static class ArrayHard
    {
        /*
            Given an integer array nums, return the number of reverse pairs in the array.

            A reverse pair is a pair (i, j) where:

            0 <= i < j < nums.length and
            nums[i] > 2 * nums[j].
         */
        public static int ReversePairsBF(int[] nums)
        {
            int n = nums.Length;
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (global::System.Int32 j = i + 1; j < n; j++)
                {
                    int l = nums[i];
                    int r = nums[j];
                    long chk = 2 * (long)r;
                    if (l > chk) cnt++;
                }
            }
            return cnt;
        }

        public static int ReversePairsOpt(int[] nums)
        {
            return MergeSort(nums, 0, nums.Length - 1);
        }

        private static int MergeSort(int[] nums, int left, int right)
        {
            if (left == right) return 0;

            int cnt = 0, mid = (left + right) / 2;

            cnt += MergeSort(nums, left, mid - 1);
            cnt += MergeSort(nums, mid + 1, right);
            cnt += CountPairs(nums, left, mid, right);
            Merge(nums, left, mid, right);
            return cnt;
        }

        private static void Merge(int[] nums, int left, int mid, int right)
        {
            int[] temp = new int[nums.Length];
            int low = left, high = mid + 1, i = 0;
            while (left <= mid && high <= right)
            {
                if (nums[left] <= nums[high])
                {
                    temp[i] = nums[left];
                    left++;
                }
                else
                {
                    temp[i] = nums[high];
                    high++;
                }
                i++;
            }
            while (high <= right)
            {
                temp[i] = nums[high];
                high++;
            }
            while (left <= mid)
            {
                temp[i] = nums[left];
                left++;
            }
            for (int j = left; j <= right; j++)
            {
                nums[j] = temp[i - left];
            }

        }

        private static int CountPairs(int[] nums, int left, int mid, int right)
        {
            int cnt = 0, crnt = mid + 1;
            for (int i = 0; i <= mid; i++)
            {
                int num = nums[i];
                int nxt = nums[crnt];
                while (crnt <= right && num > 2 * (long)nxt)
                {
                    cnt += (right - crnt);
                    crnt++;
                }
            }
            return cnt;
        }

        /*
         42. Trapping Rain Water
        Given n non-negative integers representing an elevation map where the width of each bar is 1,
        compute how much water it can trap after raining. 
         */
        /// <summary>
        /// For each index, we have to find the amount of water that can be stored and we have to sum it up.
        /// If we observe carefully the amount the water stored at a particular index is 
        /// the minimum of maximum elevation to the left and right of the index minus the elevation at that index.
        /// </summary>
        public static int TrapRainWaterBF(int[] height)
        {
            int n = height.Length;
            int cnt = 0;
            for (int i = 0; i < height.Length; i++)
            {
                int leftMax = 0, rightMax = 0, j = i;
                while (j >= 0)
                {
                    leftMax = Math.Max(leftMax, height[j]);
                    j--;
                }
                j = i;
                while (j <= n - 1)
                {
                    rightMax = Math.Max(rightMax, height[j]);
                    j++;
                }
                cnt += Math.Min(rightMax, leftMax) - height[i];
            }
            return cnt;
        }

        /*
         Intuition: We are taking O(N) for computing leftMax and rightMax at each index. 
        The complexity can be boiled down to O(1) if we precompute the leftMax and rightMax at each index.

        Approach: Take 2 array prefix and suffix array and precompute the leftMax and rightMax for each index beforehand. 
        Then use the formula min(prefix[I], suffix[i])-arr[i] to compute water trapped at each index.
         */
        public static int TrapRainWaterBtr(int[] height)
        {
            int cnt = 0;
            int n = height.Length;
            int[] leftMaxes = new int[n];
            int[] rightMaxes = new int[n];

            leftMaxes[0] = height[0];
            rightMaxes[n - 1] = height[n - 1];

            for (int i = 1; i < n; i++)
            {
                leftMaxes[i] = Math.Max(leftMaxes[i - 1], height[i]);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                rightMaxes[i] = Math.Max(rightMaxes[i + 1], height[i]);
            }

            for (int i = 0; i < n; i++)
            {
                cnt += Math.Min(leftMaxes[i], rightMaxes[i]) - height[i];
            }
            return (cnt);
        }

        /*
         Intuition: We need a minimum of leftMax and rightMax.So if we take the case when height[l]<=height[r] we increase l++, so we can surely say that there is a block with a height more than height[l] to the right of l. And for the same reason when height[r]<=height[l] we can surely say that there is a block to the left of r which is at least of height[r]. So by traversing these cases and using two pointers approach the time complexity can be decreased without using extra space.
         */
        public static int TrapRainWaterOpt(int[] height)
        {
            int cnt = 0;
            int n = height.Length;
            int left = 0, right = n - 1, leftMax = height[0], rightMax = height[n - 1];
            while (left < right)
            {
                int numLeft = height[left];
                int numRight = height[right];
                if (numLeft <= numRight)
                {
                    if (numLeft >= leftMax)
                        leftMax = numLeft;
                    else
                        cnt += leftMax - numLeft;
                    left++;
                }
                else
                {
                    if (numRight >= rightMax)
                        rightMax = numRight;
                    else
                        cnt += rightMax - numRight;
                    right--;
                }
            }
            return cnt;
        }

        public static double FindMedianSortedArraysBF(int[] nums1, int[] nums2)
        {
            int[] arr = MergeArrays(nums1, nums2);
            int len = nums1.Length + nums2.Length, mid = len / 2;
            double result;
            if (len % 2 == 0)
            {
                result = ((double)arr[mid] + arr[--mid]) / 2;
                return result;
            }
            else
                return arr[mid];
        }

        private static int[] MergeArrays(int[] nums1, int[] nums2)
        {
            int p1 = 0, p2 = 0, i = 0, n = nums1.Length, m = nums2.Length;
            int[] arr = new int[n + m];
            while (p1 < n && p2 < m)
            {
                int num1 = nums1[p1];
                int num2 = nums2[p2];
                if (num1 <= num2)
                {
                    arr[i] = num1;
                    p1++;
                }
                else
                {
                    arr[i] = num2;
                    p2++;
                }
                i++;
            }
            if (p1 < n)
            {
                for (int j = p1; j < n; j++)
                {
                    arr[i] = nums1[j];
                    p1++; i++;
                }
            }
            if (p2 < m)
            {
                for (int j = p2; j < m; j++)
                {
                    arr[i] = nums2[j];
                    p2++; i++;
                }
            }
            return arr;
        }

        public static double FindMedianSortedArraysOpt(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length, n2 = nums2.Length;
            if (n1 > n2) return FindMedianSortedArraysOpt(nums2, nums1);

            int len = (n1 + n2);

            int req = (len + 1) / 2;//length of left half

            int low = 0, high = n1;
            while (low <= high)
            {
                int mid1 = (low + high) / 2;
                int mid2 = req - mid1;
                //calculate l1, l2, r1 and r2;

                int l1 = mid1 > 0 ? nums1[mid1 - 1] : int.MinValue;
                int l2 = mid2 > 0 ? nums2[mid2 - 1] : int.MinValue;
                int r1 = mid1 < n1 ? nums1[mid1] : int.MaxValue;
                int r2 = mid2 < n2 ? nums2[mid2] : int.MaxValue;

                if (l1 <= r2 && l2 <= r1)
                {
                    if (len % 2 == 0)
                    {
                        int maxL = Math.Max(l1, l2);
                        int minR = Math.Min(r1, r2);
                        return (double)(maxL + minR) / 2;
                    }
                    else
                        return Math.Max(l1, l2);
                }
                else if (l1 > r2)
                    high = mid1 - 1;
                else
                    low = mid1 + 1;
            }
            return 0.0;
        }
    }

}
