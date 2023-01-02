using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Medium
{
    internal class Reverse_integer
    {
        public static int Solution(int x)
        {
            //string s = x.ToString();
            //if (s.Length == 1) return x;

            //string sign = "";
            string rev = "";

            //if (s.StartsWith("-"))
            //{
            //    s = s.Replace("-", "");
            //    if (s.Length == 1) return x;
            //    sign = "-";
            //}
            ////foreach (char c in s.ToCharArray())
            ////    rev = c + rev;
            //char[] charArray = s.ToCharArray();
            //Array.Reverse(charArray);
            //rev= new string(charArray);

            //while (rev != "" && rev.StartsWith("0"))
            //    rev = rev.Remove(0,1);

            int temp = x, r; bool flag = false;
            while (temp != 0)
            {
                r = temp % 10;

                //keep string empty till adding 0s
                //if string is not empty => string has digits 1-9, add only middle zeroes
                //here minus sign of non 0 values will also be added 
                rev += r != 0 ? r : rev == "" ? "" : "0";
                temp /= 10;
                temp = !flag ? Math.Abs(temp) : temp;
                flag = true;
            }
            rev = (x < 0 && !rev.Contains("-") ? "-" : "") +rev;
            try
            {
                return Int32.Parse(rev);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
