using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms
{
    public class RecursionMedium
    {
        public static List<int> SubsetSums(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return new List<int>();

            List<int> subsetSums = new();
            SubsetSumsHelper(0, 0, arr.Length, arr, subsetSums);
            return subsetSums;
        }

        /// <summary>
        /// return the array of all possible subset sums by picking or not picking the element
        /// </summary>
        /// <param name="ind"></param>
        /// <param name="sum"></param>
        /// <param name="len"></param>
        /// <param name="arr"></param>
        /// <param name="subsetSums"></param>
        public static void SubsetSumsHelper(int ind, int sum, int len, int[] arr, List<int> subsetSums)
        {
            if (ind == len)
            {
                subsetSums.Add(sum);
                return;
            }
            // pick the element 
            SubsetSumsHelper(ind + 1, sum + arr[ind], len, arr, subsetSums);

            // Do-not pick the element
            SubsetSumsHelper(ind + 1, sum, len, arr, subsetSums);
        }
    }
}
