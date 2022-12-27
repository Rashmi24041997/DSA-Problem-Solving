// See https://aka.ms/new-console-template for more information

using DSA_Problem_Solving.Easy;
using DSA_Problem_Solving.Medium;
public class Solution
{
    public static void Main()
    {
        Call_Roman_to_Integer();
        Call_Two_Sum();
        Call_AddTwoNumbers();
        Call_Longest_Substring_Without_Repeating_Characters();

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
            Console.WriteLine(TwoSum.Sol( new int[] { 2,7,11,12}, 13));
        }
        catch (Exception ex) { }
    }

    public static void Call_AddTwoNumbers() {
        try 
        {
            ListNode l1 = new(1, new (2, new (3)));
            ListNode l2 = new(3, new (8, new (8)));
            ListNode l3 = AddTwoNumbers_LinkedList.AddTwoNumbers(l1, l2);
        }
        catch (Exception ex) { }
    }

    public static void Call_Longest_Substring_Without_Repeating_Characters()
    {
        try
        {
          int ans =  Longest_Substring_Without_Repeating_Characters.Solution("dvdf");
        }
        catch (Exception ex) { }
    }
}