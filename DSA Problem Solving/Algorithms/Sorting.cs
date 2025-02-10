using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms;

public class Sorting
{
    public class Easy
    {
        // Selection Sort: Time Complexity O(n^2), Space Complexity O(1)
        public static void selectionSort(int[] arr)
        {
            // Iterate over each element in the array
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                // Find the minimum element in the remaining unsorted array
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                // Swap the found minimum element with the first element
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        // Bubble Sort: Time Complexity O(n^2), Space Complexity O(1)
        public static void BubbleSort(int[] arr)
        {
            bool swapped;
            // Iterate over the array from the end to the beginning
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                swapped = false;
                // Compare adjacent elements and swap if they are in the wrong order
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                // If no elements were swapped, the array is sorted
                if (!swapped) break;
            }
        }

        // Insertion Sort: Time Complexity O(n^2), Space Complexity O(1)
        public static void insertionSort(int[] arr)
        {
            // Iterate over each element in the array starting from the second element
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                // Move elements of arr[0..i-1], that are greater than arr[i], to one position ahead of their current position
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    int temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                    j--;
                }
            }
        }
    }
    public class Medium
    {
        public static void MergeSort(int[] arr, int low, int high)
        {
            if (low >= high) return;
            int mid = (low + high) / 2;
            MergeSort(arr, low, mid);
            MergeSort(arr, mid + 1, high);
            Merge(arr, low, mid, high);
        }

        private static void Merge(int[] arr, int low, int mid, int high)
        {
            // Create a temporary array of the size needed to store merged elements.
            int[] temp = new int[high - low + 1];

            int left = low;       // starting index for left subarray
            int right = mid + 1;  // starting index for right subarray
            int index = 0;        // index for the temporary array

            // Merge the two subarrays into temp in sorted order.
            while (left <= mid && right <= high)
            {
                if (arr[left] <= arr[right])
                {
                    temp[index] = arr[left];
                    left++;
                }
                else
                {
                    temp[index] = arr[right];
                    right++;
                }
                index++;
            }

            // If there are remaining elements in the left subarray, copy them.
            while (left <= mid)
            {
                temp[index] = arr[left];
                left++;
                index++;
            }

            // If there are remaining elements in the right subarray, copy them.
            while (right <= high)
            {
                temp[index] = arr[right];
                right++;
                index++;
            }

            // Transfer the merged elements from temp back to the original array.
            for (int i = low; i <= high; i++)
            {
                arr[i] = temp[i - low];
            }
        }
    }

    public class Hard
    {
    }
}

