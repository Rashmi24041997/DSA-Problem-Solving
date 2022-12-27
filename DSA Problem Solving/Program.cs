// See https://aka.ms/new-console-template for more information

using DSA_Problem_Solving.Easy;
public class Solution
{
    public static void Main()
    {
        //Call_Roman_to_Integer();
        Call_Two_Sum();
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

        //Roman to integer
        List<int> arr = new List<int>();
        try
        {
            Console.WriteLine(TwoSum.Sol( new int[] { 2,7,11,12}, 13));
        }
        catch (Exception ex)
        {

            
        }
    }

}