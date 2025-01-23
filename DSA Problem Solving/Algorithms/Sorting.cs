using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Algorithms
{
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
        }
        public class Hard
        {
        }
    }
}
