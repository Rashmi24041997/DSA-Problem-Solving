using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Approaches
{
    public class Sliding_Window_and_Two_pointers
    {
        public class Easy { }

        public class Medium
        {
            /*
             Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
                Example 1:                
                Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
                Output: 6
                Explanation: [1,1,1,0,0,1,1,1,1,1,1]
                Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
            */
            public static int LongestOnes(int[] nums, int k)
            {
                //if (k == 0) return nums[0] == 1 ? 1 : 0;

                int zs = k, maxLen = 0, cnt = 0, left = 0, right = 0;

                while (left <= right && right < nums.Length)
                {
                    int num = nums[right];
                    if (num == 0)
                    {
                        zs--;
                        if (zs < 0)
                        {
                            while (zs < 0 && left <= right)
                            {
                                num = nums[left];
                                if (num == 0)
                                {
                                    zs++;
                                    left++;
                                    break;
                                }
                                left++;
                            }
                            //cnt = 0;
                            //right++;
                            //continue;
                        }
                    }
                    cnt = right - left + 1;
                    maxLen = Math.Max(maxLen, cnt);
                    right++;
                }
                return maxLen;
            }
        }
        public class Hard
        {
            /*
             * Given an integer array nums and an integer k, return the number of good subarrays of nums.

                A good array is an array where the number of different integers in that array is exactly k.
                
                For example, [1,2,3,1,2] has 3 different integers: 1, 2, and 3.
                A subarray is a contiguous part of an array.
            */
            public static int SubarraysWithKDistinctBF(int[] nums, int k)
            {
                int cnt = 0, n = nums.Length, temp = k;
                HashSet<int> visited = new HashSet<int>();
                for (int i = 0; i < n; i++)
                {
                    visited = new();
                    int i1 = nums[i];
                    visited.Add(i1);
                    temp = k - 1;
                    if (!visited.Contains(i1))
                    {
                        visited.Add(i1);
                        temp--;
                        if (temp < 0) break;
                        if (temp == 0) cnt++;
                    }
                    else if (visited.Contains(i1) && temp == 0)
                    {
                        cnt++;
                    }
                    for (int j = i + 1; j < n; j++)
                    {
                        int j1 = nums[j];
                        if (!visited.Contains(j1))
                        {
                            visited.Add(j1);
                            temp--;
                            if (temp < 0) break;
                            if (temp == 0) cnt++;
                        }
                        else if (visited.Contains(j1) && temp == 0)
                        {
                            cnt++;
                        }
                    }
                }
                return cnt;
            }

            private static int Helper(int[] nums, int k)
            {
                int left = 0, right = 0, count = 0;
                Dictionary<int, int> map = new Dictionary<int, int>();

                while (right < nums.Length)
                {
                    if (!map.ContainsKey(nums[right]))
                    {
                        map[nums[right]] = 0;
                    }
                    map[nums[right]]++;

                    while (map.Count > k)
                    {
                        map[nums[left]]--;
                        if (map[nums[left]] == 0)
                        {
                            map.Remove(nums[left]);
                        }
                        left++;
                    }

                    count += right - left + 1;
                    right++;
                }

                return count;
            }

            public static int SubarraysWithKDistinct(int[] nums, int k)
            {
                return Helper(nums, k) - Helper(nums, k - 1);
            }
        }
    }
}
