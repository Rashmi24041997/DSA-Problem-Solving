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
            // If the input array is null, return null
            if (nums is null)
                return null;

            // If the input array is empty, return an empty list of lists
            if (nums.Length < 1)
                return new List<IList<int>>();

            // Sort the array to handle duplicates
            Array.Sort(nums);

            // Initialize a pointer to track unique elements
            int i = 0;

            // Iterate through the array starting from the second element
            for (int j = 1; j < nums.Length; j++)
            {
                // If the current element is different from the last unique element
                if (nums[i] != nums[j])
                {
                    // Move the pointer to the next position
                    i++;

                    // Update the element at the pointer to the current element
                    nums[i] = nums[j];
                }
            }

            // Increment the pointer to get the count of unique elements
            i++;

            // Initialize the list to store all unique subsets
            IList<IList<int>> ansList = new List<IList<int>>();

            // Call the helper method to find all subsets starting from index 0
            FindSubsets(0, nums, i, new List<int>(), ansList);

            // Return the list of unique subsets
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
        private static void findSubsets(int ind, int[] nums, List<int> ds, IList<IList<int>> ansList)
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
        private static void findSubsets(int ind, int[] nums, List<int> ds, List<IList<int>> ansList)
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


        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            SubsetHelper(nums, 0, new List<int>(), result);
            return result;
        }

        private static void SubsetHelper(int[] nums, int i, List<int> subset, IList<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(new List<int>(subset));
                return;
            }
            subset.Add(nums[i]);
            SubsetHelper(nums, i + 1, subset, result);

            subset.RemoveAt(subset.Count - 1);
            SubsetHelper(nums, i + 1, subset, result);
        }

        public static void Reverse(Stack<int> s)
        {
            List<int> lst = new List<int>();
            Helper(s, lst);
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                s.Push(lst[i]);
            }
        }

        private static void Helper(Stack<int> s, List<int> lst)
        {
            if (s.Count == 0)
                return;
            int val = s.Pop();
            Helper(s, lst);
            lst.Add(val);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);
            findCombinations(0, candidates, target, ans, new List<int>());
            return ans;
        }

        private static void findCombinations(int ind, int[] arr, int target, IList<IList<int>> ans, List<int> ds)
        {
            if (target == 0)
            {
                ans.Add(new List<int>(ds));
                return;
            }
            if (ind == arr.Length || target < 0)
            {
                return;
            }
            for (int i = ind; i < arr.Length; i++)
            {
                int num = arr[i];
                if (num > target) break;
                ds.Add(num);
                findCombinations(i, arr, target - num, ans, ds);
                ds.Remove(num);
            }
        }

        public static IList<IList<int>> CombinationSumOpt(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            findCombinationsOpt(0, candidates, target, ans, new List<int>());
            return ans;
        }

        private static void findCombinationsOpt(int ind, int[] arr, int target, IList<IList<int>> ans, List<int> ds)
        {
            //if we've reached end of the array or target is exceeded, stop
            if (ind >= arr.Length || target < 0)
            {
                if (target == 0)
                {
                    ans.Add(new List<int>(ds));
                    //return;
                }
                return;
            }

            int num = arr[ind];

            //picking
            //to be picked, num should not be greater than target 
            if (num <= target)
            {
                //pick num
                ds.Add(num);
                findCombinationsOpt(ind, arr, target - num, ans, ds);
                //go to previous state
                ds.Remove(ds.Count - 1);
            }
            //not picking 
            findCombinationsOpt(ind + 1, arr, target, ans, ds);
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);
            findCombinations2(0, candidates, target, ans, new List<int>());
            return ans;
        }

        private static void findCombinations2(int ind, int[] arr, int target, IList<IList<int>> ans, List<int> ds)
        {
            if (target == 0)
            {
                ans.Add(new List<int>(ds));
                return;
            }
            if (ind == arr.Length || target < 0)
            {
                return;
            }
            for (int i = ind; i < arr.Length; i++)
            {
                int num = arr[i];
                if (i > ind && num == arr[i - 1]) continue;
                if (num > target) break;
                ds.Add(num);
                findCombinations2(i + 1, arr, target - num, ans, ds);
                ds.Remove(num);
            }
        }

        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<int> arr = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<IList<int>> ans = new List<IList<int>>();
            findCombinations3(0, k, arr, n, ans, new List<int>());
            return ans;
        }

        private static void findCombinations3(int ind, int k, List<int> arr, int target, IList<IList<int>> ans, List<int> ds)
        {
            if (ds.Count == k)
            {
                if (target == 0)
                {
                    ans.Add(new List<int>(ds));

                    //ds.Remove(ds.Count - 1);

                    //ds.Remove(ds.Count - 1);
                }
                return;
            }
            if (target < 0)
                return;

            for (int i = ind; i < arr.Count; i++)
            {
                int num = arr[i];
                if (num > target) break;
                ds.Add(num);
                findCombinations3(i + 1, k, arr, target - num, ans, ds);
                //if (ds.Count == 2 && i != ind)
                //    break;
                ds.Remove(num);
            }
        }

        /*46. Permutations
        Given an array arr of distinct integers, print all permutations of String/Array.
        */

        /// <summary>
        /// Run a for loop starting from 0 to nums.size() - 1. Check if the frequency of i is unmarked,
        /// if it is unmarked then it means it has not been picked and then we pick. And make sure it is marked as picked.
        /// Call the recursion with the parameters to pick the other elements when we come back from the recursion 
        /// make sure you throw that element out. And unmark that element in the map.
        /// Time Complexity:  N! x N
        /// Space Complexity:  O(N)
        /// </summary>
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            int len = nums.Length;
            bool[] freq = new bool[len];
            for (int i = 0; i < len; i++)
            {
                freq[i] = false;
            }
            PermuteHelper(nums, len, ans, new List<int>(), freq);
            return ans;
        }

        private static void PermuteHelper(int[] nums, int len, IList<IList<int>> ans, IList<int> ds, bool[] freq)
        {
            if (ds.Count == len)
            {
                ans.Add(ds);
                return;
            }
            for (int i = 0; i < len; i++)
            {
                if (freq[i]) continue;
                int num = nums[i];
                ds.Add(num);
                freq[i] = true;
                PermuteHelper(nums, len, ans, ds, freq);
                ds.Remove(num);
                freq[i] = false;
            }
        }

        public static IList<IList<int>> PermuteOpt(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            int len = nums.Length;
            PermuteHelperOpt(nums, len, 0, ans);
            return ans;
        }

        private static void PermuteHelperOpt(int[] nums, int len, int indx, IList<IList<int>> ans)
        {
            if (indx == len)
            {
                List<int> ds = new();
                for (global::System.Int32 i = 0; i < indx; i++)
                {
                    ds.Add(nums[i]);
                }
                ans.Add(ds);
                return;
            }
            for (int i = indx; i < len; i++)
            {
                Swap(nums, i, indx);
                PermuteHelperOpt(nums, len, indx + 1, ans);
                Swap(nums, i, indx);
            }
        }

        private static void Swap(int[] nums, int i, int v)
        {
            int temp = nums[i];
            nums[i] = nums[v];
            nums[v] = temp;
        }

        /*
         Given a string s, partition s such that every substring of the partition is a palindrome.
          Return all possible palindrome partitioning of s.
         */
        public static IList<IList<string>> PartitionBF(string s)
        {
            IList<IList<string>> ans = new List<IList<string>>(); // Stores the final list of partitions
            int len = s.Length;
            PartitionBFHelper(s, len, 0, ans, new List<string>()); // Call helper function to start backtracking
            return ans;
        }

        // Helper function to perform backtracking
        private static void PartitionBFHelper(string s, int len, int indx, IList<IList<string>> ans, IList<string> ds)
        {
            // Base Case: If the entire string is processed, add the current partition to the answer list
            if (indx == len)
            {
                ans.Add(new List<string>(ds)); // Create a new list to store the partition
                return;
            }

            // Iterate through all possible substrings starting at 'indx'
            for (int i = indx; i < len; i++)
            {
                // Extract the palindrome substring
                string ss = s.Substring(indx, i - indx + 1);

                // Check if the substring s[indx:i] is a palindrome
                if (IsPalindrome(ss))
                {
                    // Include this palindrome in the current partition list
                    ds.Add(ss);

                    // Recursively partition the remaining substring
                    PartitionBFHelper(s, len, i + 1, ans, ds);

                    // Backtrack: Remove the last added palindrome to try other possibilities
                    ds.RemoveAt(ds.Count - 1);
                }
            }
        }

        // Helper function to check if a substring is a palindrome
        private static bool IsPalindrome(string part)
        {
            int left = 0, right = part.Length - 1;
            // Compare characters from both ends
            while (left < right)
            {
                if (part[left++] != part[right--]) // If characters don't match, it's not a palindrome
                    return false;
            }
            return true; // If all matched, it's a palindrome
        }

        /* 79.
          Given an m x n grid of characters board and a string word, return true if word exists in the grid.
          The word can be constructed from letters of sequentially adjacent cells.
         The same letter cell may not be used more than once.
         */
        public static bool Exist(char[][] board, string word)
        {
            int n = board.Length;
            int m = board[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (global::System.Int32 j = 0; j < m; j++)
                {
                    if (board[i][j] == word[0])
                        if (Exist(board, word, 1, i, j, n, m))
                            return true;
                }
            }
            return false;
        }

        private static bool Exist(char[][] board, string word, int indx, int i, int j, int n, int m)
        {
            // if index reaches at the end that means we have found the word

            if (indx >= word.Length)
                return true;

            // Checking the boundaries if the character at which we are placed is not 
            //the required character

            if (i < 0 || i >= n || j < 0 || j >= m)
                return false;

            char chr = board[i][j];

            if (chr == ' ' || chr != word[indx])
                return false;

            // this is to prevent reusing of the same character
            board[i][j] = ' ';
            indx++;

            // right direction
            bool right = Exist(board, word, indx, i, j + 1, n, m);

            // left direction
            bool left = Exist(board, word, indx, i, j - 1, n, m);

            // top direction
            bool top = Exist(board, word, indx, i - 1, j, n, m);

            // bottom direction
            bool bottom = Exist(board, word, indx, i + 1, j, n, m);

            board[i][j] = chr; // undo change
            return right || left || top || bottom;
        }

        public static double myPowRev(double x, int n)
        {
            if (x == 0.0 || x == 1 || n == 1) return x;
            double ans = 1.0;
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            while (n > 0)
                if (n % 2 == 0)
                {
                    x = x * x;
                    n = n / 2;
                }
                else
                {
                    ans = ans * x;
                    n--;
                }
            var s = double.ma
            return ans;
           
        }
    }

    public static class RecursionHard
    {
        public static IList<IList<string>> SolveNQueens(int n)
        {
            var results = new List<IList<string>>();
            var result = new List<string>();
            bool[,] ban = new bool[n, n];
            bool[,] banCopy = new bool[n, n];
            int indx = 0;
            for (int i = 0; i < n; i++)
            {
                result = new List<string>();
                //ban.CopyTo(banCopy, 0);
                SolveNQueensHelper(n, 0, i, new bool[n, n], result);
                if (result.Count == n)
                    results.Add(result);
            }
            return results;
        }
        private static void SolveNQueensHelper(int n, int row, int col, bool[,] ban, List<string> result)
        {
            if (row >= n) return;
            bool possible = row == 0;
            if (!possible)
                for (int j = 0; j < n; j++)
                {
                    if (!ban[row, j])
                    {
                        col = j;
                        possible = true;
                        break;
                    }
                }
            if (!possible)
                return;
            string str = "";
            for (int i = 0, j = 0; j < n || i < n; i++, j++)
            {
                str += j == col ? "Q" : ".";

                if (i < n)
                    ban[i, col] = true;
                if (j < n)
                    ban[row, j] = true;
            }
            for (int i = row + 1, j = col + 1; i < n && j < n; i++, j++)
            {
                ban[i, j] = true;
            }
            for (int i = row + 1, j = col - 1; i < n && j >= 0; i++, j--)
            {
                ban[i, j] = true;
            }
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                ban[i, j] = true;
            }
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                ban[i, j] = true;
            }
            //for (int i = row, j = col, k = row, l = col; (i < n && j < n) || (k >= 0 && l >= 0); i++, j++, k--, l--)
            //{
            //    if (i < n && j < n)
            //        ban[i, j] = true;
            //    if (k >= 0 && l >= 0)
            //        ban[k, l] = true;
            //}
            result.Add(str);
            SolveNQueensHelper(n, row + 1, -1, ban, result);
        }
    }
}
