using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Problem_Solving.Algorithms
{
    public class RecursionMedium
    {
        // Method to calculate all subset sums of an array
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static List<int> SubsetSums(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return new List<int>();

            List<int> subsetSums = new();
            SubsetSumsHelper(0, 0, arr.Length, arr, subsetSums);
            return subsetSums;
        }

        // Helper method to recursively calculate subset sums
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static void SubsetSumsHelper(int ind, int sum, int len, int[] arr, List<int> subsetSums)
        {
            if (ind == len)
            {
                subsetSums.Add(sum);
                return;
            }
            SubsetSumsHelper(ind + 1, sum + arr[ind], len, arr, subsetSums);
            SubsetSumsHelper(ind + 1, sum, len, arr, subsetSums);
        }

        // Method to find all unique subsets of an array with duplicates
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            if (nums is null)
                return null;

            if (nums.Length < 1)
                return new List<IList<int>>();

            Array.Sort(nums);

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            i++;
            IList<IList<int>> ansList = new List<IList<int>>();
            FindSubsets(0, nums, i, new List<int>(), ansList);
            return ansList;
        }

        // Helper method to recursively find subsets
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        private static void FindSubsets(int ind, int[] nums, int len, List<int> subset, IList<IList<int>> subsetList)
        {
            subsetList.Add(new List<int>(subset));

            for (int i = ind; i < len; i++)
            {
                subset.Add(nums[i]);
                FindSubsets(i + 1, nums, len, subset, subsetList);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        // Method to find all unique subsets of an array with duplicates
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static void findSubsets(int ind, int[] nums, List<int> ds, IList<IList<int>> ansList)
        {
            ansList.Add(new List<int>(ds));
            for (int i = ind; i < nums.Length; i++)
            {
                if (i != ind && nums[i] == nums[i - 1]) continue;
                ds.Add(nums[i]);
                findSubsets(i + 1, nums, ds, ansList);
                ds.RemoveAt(ds.Count - 1);
            }
        }

        // Method to find all unique subsets of an array with duplicates
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> ansList = new List<IList<int>>();
            findSubsets(0, nums, new List<int>(), ansList);
            return ansList;
        }

        // Helper method to recursively find subsets
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static void findSubsets(int ind, int[] nums, List<int> ds, List<IList<int>> ansList)
        {
            ansList.Add(new List<int>(ds));
            for (int i = ind; i < nums.Length; i++)
            {
                if (i != ind && nums[i] == nums[i - 1]) continue;
                ds.Add(nums[i]);
                findSubsets(i + 1, nums, ds, ansList);
                ds.RemoveAt(ds.Count - 1);
            }
        }

        // Method to find all unique subsets of an array with duplicates
        // Time Complexity: O(2^n)
        // Space Complexity: O(2^n)
        public static IList<IList<int>> subsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> ansList = new List<IList<int>>();
            findSubsets(0, nums, new List<int>(), ansList);
            return ansList;
        }
    }
}
