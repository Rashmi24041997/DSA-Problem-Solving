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
    }

}
