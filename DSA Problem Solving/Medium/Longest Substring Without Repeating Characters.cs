namespace DSA_Problem_Solving.Medium
{
    internal class Longest_Substring_Without_Repeating_Characters
    {
        internal static int Solution(String prblm)
        {

            if (string.IsNullOrEmpty(prblm)) return 0;
            if (prblm.Length == 1) return 1;

            String rslt, temp = "";
            rslt = prblm.First().ToString();

            foreach (char c in prblm)
            {
                if (!temp.Contains(c))
                    temp += c.ToString();
                else
                {
                    if (temp.Length > rslt.Length)
                        rslt = temp;
                    temp = temp.Substring(temp.IndexOf(c) + 1) + c.ToString();
                }
            }
            if (temp.Length > rslt.Length)
                rslt = temp;
            return rslt.Length;
        }

    }
}
