using System;
using System.ComponentModel.Design.Serialization;
using System.Linq;

/// <summary>
/// Summary description for Class1
/// </summary>
public class TwoSum
{
    public static int[] Sol(int[] nums, int target)
    {
        int[] arr = new int[2];
        //Dictionary<int, int> set = nums.Select((index, value) => new { index, value }).ToDictionary(pair => pair.value, pair => pair.index);
        Dictionary<int, int> set = new();

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    set.Add(i, nums[i]);
        //}
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    int val = target - nums[i];
        //    set.Remove(i);
        //    if (set.ContainsValue(val))
        //    {
        //        arr[0] = i;
        //        arr[1] = set.FirstOrDefault(x => x.Value == val).Key;
        //        return arr;
        //        return new int[] { arr[0], arr[1] };
        //    }
        //}

        List<int> lst = nums.ToList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int val = target - nums[i];
            int indx = lst.LastIndexOf(val);
            if (indx > i)
            {
                arr[0] = i;
                arr[1] = lst.IndexOf(val);
                return new int[] { arr[0], arr[1] };
            }
        }
        return new int[] { };

    }
}

