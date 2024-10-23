// See https://aka.ms/new-console-template for more information

using DSA_Problem_Solving;
using DSA_Problem_Solving.Basic_Maths.Easy;
using DSA_Problem_Solving.Data_Structures.Arrays.Easy;
using DSA_Problem_Solving.Easy;
using DSA_Problem_Solving.Easy.Binary_Tree;
using DSA_Problem_Solving.Easy.LinkedList;
using DSA_Problem_Solving.Medium;
using DSA_Problem_Solving.Medium.LinkedList;
using System;
using System.Collections;
using System.Xml.Linq;

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
        //Console.WriteLine(ArrayMedium.SetMatrixZeroes(new int[][]
        //{
        //    new int[] { 1, 1, 1 },
        //    new int[] { 1, 0, 1 },
        //    new int[] { 1, 1, 1 }
        //}));
        int[] arr = new int[] { 2, 0, 2, 1, 1, 0 };
        Console.Clear();
        arr.ToList().ForEach(i => Console.Write($"\t{i}"));
        Console.WriteLine();
        Console.WriteLine();
        ArrayMedium.SortColorsBtr(arr).ToList().ForEach(i => Console.Write($"\t{i}"));
        Console.WriteLine();
        Console.WriteLine();
        ArrayMedium.SortColorsOpt(new int[] { 2, 0, 2, 1, 1, 0 }).ToList().ForEach(i => Console.Write($"\t{i}"));
    }
    public static void Call_Roman_to_Integer()
    {
        //Roman to integer
        Roman_to_Integer obj = new Roman_to_Integer();
        string str = Console.ReadLine();
        Console.WriteLine(obj.Cnvrt_Roman_to_Integer(str));
    }
    public static void Call_Two_Sum()
    {
        try
        {
            Console.WriteLine(TwoSum.Sol(new int[] { 2, 7, 11, 12 }, 13));
        }
        catch (Exception ex) { }
    }

    public static void Call_AddTwoNumbers()
    {
        try
        {
            ListNode l1 = new(1, new(2, new(3)));
            ListNode l2 = new(3, new(8, new(8)));
            ListNode l3 = AddTwoNumbers_LinkedList.AddTwoNumbers(l1, l2);
        }
        catch (Exception ex) { }
    }

    public static void Call_Longest_Substring_Without_Repeating_Characters()
    {
        try
        {
            int ans = Longest_Substring_Without_Repeating_Characters.Solution("dvdf");
        }
        catch (Exception ex) { }
    }

    public static void Call_MinStoneSum()
    {
        int r = MinStoneSum.Solution(new int[] { 1391, 5916 }, 2);
    }
    public static void Call_Reverse_integer()
    {
        int i = Reverse_integer.Solution(-100);
    }

    public static void Call_Divide_Two_Integers()
    {
        int i = Divide_Two_Integers.Solution(-2147483648, 2);
    }

    public static void Call_Linked_List_Mid()
    {
        try
        {
            ListNode l1 = new(1, new(2, new(3, new(4, new(5, new(6))))));
            ListNode l2 = new(1, new(2, new(3)));
            ListNode l3 = new(1, new(2));
            ListNode l4 = new(1, new(2, new(3, new(3))));
            ListNode l5 = Linked_List_Mid.Solution(l1);
        }
        catch (Exception ex) { }
    }
    public static void Call_Binary_Tree_Level_Order_Traversal()
    {
        try
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.right.left = new TreeNode(8);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            root.right.right.left = new TreeNode(9);
            root.right.right.right = new TreeNode(10);

            List<List<int>> inOrder;
            //inOrder = (List<List<int>>)Binary_Tree_Level_Order_Traversal.LevelOrder(root);

        }
        catch (Exception ex) { }
    }
    public static void Call_TopView()
    {
        try
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.right.left = new TreeNode(8);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            root.right.right.left = new TreeNode(9);
            root.right.right.right = new TreeNode(10);

            List<int> inOrder;
            //inOrder = (List<int>)Top_View_of_Binary_Tree.TopView(root);

        }
        catch (Exception ex) { }
    }

}