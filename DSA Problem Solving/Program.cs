// See https://aka.ms/new-console-template for more information

using DSA_Problem_Solving;
using DSA_Problem_Solving.Algorithms;
using DSA_Problem_Solving.Basic_Maths;
using DSA_Problem_Solving.Data_Structures;
using DSA_Problem_Solving.Data_Structures.Arrays;
using DSA_Problem_Solving.Data_Structures.Arrays.Easy;
using DSA_Problem_Solving.Data_Structures.LinkedList;
using static DSA_Problem_Solving.Data_Structures.HeapProblems;

public class Solution
{
    public static void Main()
    {
        //Call_Roman_to_Integer();
        //Call_Two_Sum();
        //Call_AddTwoNumbers();
        //Call_Longest_Substring_Without_Repeating_Characters();
        //Call_MinStoneSum();
        //Call_Reverse_integer();
        //Call_Divide_Two_Integers();
        //Call_Linked_List_Mid();
        //Call_Binary_Tree_Level_Order_Traversal();
        //Call_TopView();
        //Console.WriteLine(Count_the_Digits_That_Divide_a_Number.CountDigits(121));
        //Console.WriteLine(ReverseBits.Sol(-1534236469));
        //Console.WriteLine(CheckPalindrome.Sol(121));
        //Console.WriteLine(IsArmstrong.Sol(371));
        //int[][] arr = new int[][]
        //{
        //    new int[] { 0, 1, 2, 0 },
        //    new int[] { 3, 4, 5, 2 },
        //    new int[] { 1, 3, 1, 5 }
        //};
        ////Console.WriteLine(ArrayMedium.SetMatrixZeroes(arr));
        //Console.WriteLine(ArrayMedium.SetMatrixZeroesOpt(arr));

        //int[][] a = new int[][] { new int[] { 0, 1 } };
        //Console.WriteLine(ArrayMedium.SetMatrixZeroes(a));
        //Console.WriteLine(ArrayMedium.SetMatrixZeroesOpt(a));
        //int[] arr = new int[] { 2, 0, 2, 1, 1, 0 };
        //Console.Clear();
        //arr.ToList().ForEach(i => Console.Write($"\t{i}"));
        //Console.WriteLine();
        //Console.WriteLine();
        //ArrayMedium.SortColorsBtr(arr).ToList().ForEach(i => Console.Write($"\t{i}"));
        //Console.WriteLine();
        //Console.WriteLine();
        //ArrayMedium.SortColorsOpt(new int[] { 2, 0, 2, 1, 1, 0 }).ToList().ForEach(i => Console.Write($"\t{i}"));

        //int[] arr1 = new int[] { 7, 1, 5, 3, 6, 4 };
        //Console.WriteLine(ArrayEasy.MaxProfit(arr1));
        //int[] arr1 = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        //int[] arr2 = new int[] { 5, 4, -1, 7, 8 };
        //Console.WriteLine(ArrayMedium.MaxSubArray(arr1));
        //Console.WriteLine(ArrayMedium.MaxSubArray(arr2));

        //Console.WriteLine(ArrayMedium.PascalTriangle(1).ForEach(lst => lst.ForEach(i => Console.Write($"\t{i}"))));
        //Console.WriteLine(ArrayMedium.PascalTriangle(1));

        //List<int> list = ArrayMedium.TwoSumBtr(new List<int>() { 2, 6, 5, 8, 11 }, 14);
        //int[] list = ArrayMedium.TwoSumOpt(new int[] { 3, 2, 4 }, 6);
        //list.ToList().ForEach(l => Console.WriteLine(l));

        //int[] arr = new int[] { 0 };
        //int cnt = ArrayMedium.LongestConsecutive(arr);
        ////Console.WriteLine(cnt);

        //ArrayMedium.SearchMatrix(new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } }, 3);
        ////IList<IList<int>> SubsetsWithDup =RecursionMedium.SubsetsWithDup(new int[] { 1, 2, 2 } );
        //IList<IList<int>> SubsetsWithDup2 =RecursionMedium.SubsetsWithDup2(new int[] { 1, 2, 2 });
        ListNode l1 = new(1) { next = new(1) { next = new(1) { next = new(1) { next = new(1) { next = new(2) } } } } };
        RecursionEasy.RemoveElements(l1, 1);
        ////ListNode l2 = new(0) /*{ next = new(9) { next = new(9) { next = new(9) { next = new(5) { next = new(6) } } }  }}*/;
        //LinkedListMedium.ReverseBetween(new ListNode(1) { next = new ListNode(2) }, 1, 2);
        //ListNode listNode = LinkedListEasy.ReverseListRev(new ListNode(2) { next = new ListNode(1) });
        //listNode = LinkedListEasy.ReverseListUsingStack(listNode);
        //l1 = LinkedListEasy.FindMiddle(l1);
        //l1 = LinkedListEasy.MergeTwoLists(l1,l2);
        //l1 = LinkedListMedium.RemoveNthFromEndOptimal(l1,3);
        //l1 = LinkedListMedium.AddTwoNumbers(l1, l2);
        //LinkedListMedium.RotateRight(l1, 2);
        //Console.WriteLine();
        //while (l1 != null)
        //{
        //    Console.WriteLine(l1.val);
        //    l1 = l1.next;
        //}

        //BitManipulation.Easy.countSetBits(6);
        //BitManipulation.Medium.Subsets(new int[] { 1, 2, 3 });
        //BitManipulation.Medium.MinBitFlips(3, 4);
        //BitManipulation.Medium.Divide(-2147483648, -1);
        //StringProblems.Medium.WordSubsets(new string[] { "amazon", "apple", "facebook", "google", "leetcode" }, new string[] { "le", "lo" });
        //StringProblems.Easy.ReverseWords("  world hello  ");
        //StringProblems.Easy.RomanToInt("MCMXCIV");
        //StringProblems.Medium.MyAtoi("2147483648898989875758755");
        //StringProblems.Medium.RotateString("abcde", "abcde");

        //BinarySearch.Medium.SingleNonDuplicate(new int[] { 1, 1, 2 });

        //StackProblems.Easy.NextGreaterElementBF(new int[] { 4, 2 }, new int[] { 1, 2, 3, 4 });
        //StackProblems.Easy.PrevSmaller(new List<int> { 34, 35, 27, 42, 5, 28, 39, 20, 28 });
        //StringProblems.Easy.AbsDifference("abcde");
        //int[] nums1 = new int[] {  };
        //int[] nums2 = new int[] { 2, 5, 6 };
        //ArrayMedium.MergeSortedArraysOptimal(nums1, 0, nums2, nums2.Length);
        //ArrayMedium.TopKFrequentBF(new int[] { 1, 2, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 2, 2 }, 3);
        //double res = ArrayMedium.MyPowBF(-1.0000, -2147483648);
        //double res = ArrayMedium.MyPowOptimal(2.000, -2);
        //double res = ArrayMedium.MajorityElementOpt(new int[] { 2, 2, 1, 1, 1, 2, 2 });
        //var res = ArrayMedium.MajorityElementN3(new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 5, 5, 5, 5, 5 });

        //var ans = ArrayMedium.UniquePaths(2, 100);
        //StringProblems.Medium.LengthOfLongestSubstringBtr("aababcabcdabcde");
        //MathProblems.Easy.CountPrimes(10);
        //StringProblems.Medium.LengthOfLongestSubstringOpt("aababcabcdabcde");
        //Sorting.Medium.MergeSort(new int[] { 4, 1, 3, 9, 7 }, 0, 4);
        //ArrayMedium.RemoveDuplicates(new int[] { 1, 1, 2, 3, 4 });
        //ArrayMedium.RemoveDuplicatesBtr(new int[] { 1, 1, 2, 3, 4 });
        //ArrayMedium.ThreeSumOpt(new int[] { -1, 0, 1, 2, -1, -4 });
        //var res = ArrayMedium.FourSum(new int[] { 1000000000, 1000000000, 1000000000, 1000000000 }, -294967296);
        //ListNode l2 = new(0) { next = new(9) { next = new(8) { next = new(7) } } };
        //ListNode l3 = new(1) { next = l2.next };
        //l2.next.next.next.next = l3;

        //LinkedListMedium.FirstNode(l2);

        //var res = ArrayMedium.SearchOpt(new int[] { 1, 2, 3, 4, 5, 6 }, 4);
        //var res = ArrayMedium.ReversePairsBF(new int[] { 2147483647, 2147483647, 2147483647, 2147483647, 2147483647, 2147483647 });
        //var res = ArrayEasy.FindMaxConsecutiveOnesBF(new int[] { 1, 1, 0, 1, 1, 1 });

        //var res = StackProblems.Easy.IsValidParenthesis("()[]{}");

        //int res = StringProblems.Easy.StrStrBF("leetcode", "de");

        //int res = ArrayHard.TrapRainWaterBF(new int[] { 4, 2, 0, 3, 2, 5 });
        //int res = ArrayHard.TrapRainWaterBtr(new int[] { 4, 2, 0, 3, 2, 5 });
        //int res = ArrayHard.TrapRainWaterOpt(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        //double res = ArrayHard.FindMedianSortedArraysOpt(new int[] { 1, 2 }, new int[] { 3, 4 });
        //int res = Sliding_Window_and_Two_pointers.Medium.LongestOnes(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 0);
        //int res = Sliding_Window_and_Two_pointers.Hard.SubarraysWithKDistinct(new int[] { 1, 2, 1, 3, 4 }, 3);
        //int[] res = StackProblems.Medium.NextGreaterElement(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 });
        //int res = ArrayMedium.SubarraySum(new int[] { 1, -1, 0 }, 0);
        //int res = ArrayMedium.MaxSubarraySumCircular(new int[] { 5, -3, 5 });
        //int res = ArrayMedium.MaxSubarraySumCircularOpt(new int[] { 5, -3, 5 });
        //int res = ArrayMedium.SumSubarrayMins(new int[] { 3, 1, 2, 4 });
        //var res = StringProblems.Easy.HasSameDigits("3902");
        //var res = RecursionMedium.Subsets(new int[] {1,2,3});

        //RecursionMedium.reverse(new Stack<int>(new List<int>() { 1, 2, 3 }));

        //RecursionMedium.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);

        //RecursionMedium.CombinationSumOpt(new int[] { 8, 7, 4, 3 }, 11);

        //RecursionMedium.CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5);

        //RecursionMedium.CombinationSum3(3, 9);

        //RecursionMedium.Permute(new int[] { 1, 2, 3 });

        //RecursionMedium.PermuteOpt(new int[] { 1, 2, 3 });

        //RecursionMedium.PartitionBF("aabb");

        //MyQueueUsing2stackOpt que = new();
        //que.Push(1);
        //que.Push(2);
        //que.Push(3);
        //que.Push(4);
        //int i1 = que.Pop();
        //que.Push(5);
        //int i2 = que.Peek();
        //int i3 = que.Pop();
        //int i4 = que.Pop();
        //int i5 = que.Pop();
        //int i6 = que.Pop();
        //var res = ArrayMedium.CountArrays(new int[] { 15, 78, 39 },
        //    new int[][]
        //    {
        //        new int[]{8,19},
        //        new int[]{ 68, 110 },
        //        new int[]{ 19, 92 }
        //    }
        // );
        //var res = ArrayMedium.LargestInteger(new int[] { 0, 0 }, 2);
        //var res = BinaryTreeProblems.Easy.LevelOrder(
        //    new TreeNode(3,
        //        new TreeNode(9),
        //        new TreeNode(20,
        //            new TreeNode(15),
        //            new TreeNode(7)
        //            )
        //        )
        //    );
        //var res = BinaryTreeProblems.Easy.LevelOrder(null);
        //var res = BinaryTreeProblems.Medium.TopView(new TreeNode(1, new TreeNode(2), new TreeNode(3)));
        //var res = BinaryTreeProblems.Hard.MaxPathSum(
        //    new TreeNode(10,
        //        new TreeNode(9),
        //            new TreeNode(-20,
        //                new TreeNode(45),
        //                new TreeNode(7)
        //        )
        //    )
        //);
        //var res = BinaryTreeProblems.Medium.ZigzagLevelOrder(
        //    new TreeNode(1,
        //        new TreeNode(2,
        //            new TreeNode(4),
        //            new TreeNode(5)
        //        ),
        //        new TreeNode(3,
        //            new TreeNode(6),
        //            new TreeNode(7)
        //        )
        //    )
        //);
        //var res = BinaryTreeProblems.Hard.BuildTreeInNPost(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
        //ArrayMedium.CountArraysCopy(
        //    new int[] { 57, 55, 75 },
        //    new int[][] { new int[] { 60, 106 }, new int[] { 43, 60 }, new int[] { 18, 67 }/*, new int[] { 4, 5 }*/ }
        //    );
        //ArrayMedium.MaxLen(new List<int>() { 15, -2, 2, -8, 1, 7, 10, 23 });
        //GraphProblems.Easy.BfsOfGraph(new List<int>[] {
        //    new(){2,3,1},
        //    new (){0},
        //    new (){0,4},
        //    new (){0},
        //    new (){2}
        //    });

        //GraphProblems.Easy.DfsOfGraph(new List<int>[] {
        //    new (){0, 4},
        //    new (){0, 5},
        //    new (){1, 2},
        //    new (){2, 5},
        //    new (){3, 4}
        //    });
        //ArrayMedium.NumOfUnplacedFruits(new int[] { 4, 2, 5 }, new int[] { 3, 5, 4 });

        //TreeNode nod = BinaryTreeProblems.Hard.deserialize("1,2,3,null,null,4,5");
        //string ans = BinaryTreeProblems.Hard.serialize(nod);

        //TreeNode nod = BSTProblems.Easy.SearchBST(BinaryTreeProblems.Hard.deserialize("4,2,7,1,3"), 2);

        //TreeNode nod = BSTProblems.Medium.BstFromPreorderBtr(new int[] { 8, 5, 1, 7, 10, 12 });
        //TreeNode nod = BSTProblems.Medium.BstFromPreorderOpt(new int[] { 8, 5, 1, 7, 10, 12 });
        //bool nod = BSTProblems.Medium.IsValidBST(BinaryTreeProblems.Hard.deserialize("2,2,2"));

        //bool ans = ArrayEasy.CheckPractice(new int[] { 2, 1, 3, 4 });

        //bool ans = RecursionMedium.Exist(
        //    new char[][] {
        //        new char[] { 'A', 'B', 'C', 'E' },
        //        new char[] { 'S', 'F', 'C', 'S' },
        //        new char[] { 'A', 'D', 'E', 'E' }
        //    },
        //    "ABCB");

        //RecursionHard.SolveNQueens(6);
        //BinaryTreeProblems.Medium.IsSymmetric(BinaryTreeProblems.Hard.deserialize("1,2,2,3,4,4,3,3,4,3,4,4,3,4,3"));
        //ArrayEasy.TotalNumbers(new int[] { 0, 1, 2 });
        //ArrayEasy.Rotate(new int[] { -1, -100, 3, 99 }, 2);
        //ArrayHard.MaxSum(new int[] { 1, 2, -1, -2, 1, 0, -1 });
        //EasyHP obj = new EasyHP();

        ////MathProblems.Easy.lcmAndGcd(1463, 1305);
        //MathProblems.Easy.sumOfDivisors(5);
        //StringProblems.Medium.FrequencySort("abaccadeeefaafcc");

        //BinarySearch.Medium.FindMin(new int[] { 5, 6, 0, 3, 4 });
        //BinarySearch.Medium.SingleNonDuplicateRev(new int[] { 1, 2, 2 });
        //BinarySearch.Medium.SearchMatrix(new int[][] { new int[] { -5} }, -5);
        //ArrayMedium.FindMedianSortedArraysRev(new int[] { 2, 4, 6 }, new int[] { 8, 10, 12, 14});
        //BinarySearch.Medium.MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 9);
        //StringProblems.Medium.MyAtoiRev("0-1");
        //StringProblems.Medium.CountAndSay(4);
        //StringProblems.Medium.BeautySum("qoqrexqdlercxoxjvoftclywlhupkjceyprbuzwbnippbsuljgrmviapfxnkwpkxpjpqaumztnxyeqznspsyx");
        //ArrayMedium.SortArray(new int[] { 100,99,18});
        //        ArrayMedium.SpiralOrder(
        //            new int[][] {
        //            new []{0 ,   11  ,21  ,31  ,41  ,51
        //},
        //            new []{1 ,   12  ,22  ,32  ,42  ,52
        //},
        //            new []{2 ,   13  ,23  ,33  ,43  ,53
        //},
        //            new []{3 ,   14  ,24  ,34  ,44  ,54
        //},
        //            new []{4 ,   15  ,25  ,35  ,45  ,55
        //},
        //            new []{5 ,   16 , 26 , 36 , 46 , 56

        //}
        //           });
        //RecursionMedium.myPowRev(2.0, -2);
        //ArrayMedium.TwoSumII(new int[] { 2, 3, 4 }, 6);
        //RecursionMedium.CountGoodNumbers(50);
        //StringProblems.Easy.IsPalindrome("Marge, let's \"[went].\" I await {news} telegram."

//);
    }
}