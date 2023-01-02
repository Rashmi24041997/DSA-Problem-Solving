using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Medium;

internal class Divide_Two_Integers
{
    public static int Solution(int y, int x)
    {
        //not best, taking 1611 ms, beats only 21% solution
        if (x == 1) return y;
        if (x == -1) return (0 - y) == y ? (0 - (y + 1)) : (0 - y);
        if (y == 0) return 0;
        if (y == x) return 1;
        int q = 0; int temp = 0; bool flag = false;

        if (y < 0 && ((0 - y) == y))
        {
            temp = (y + 1);
            flag = true;
        }
        else temp = y;

        if (x < 0 && ((0 - x) == x)) return 0;
        if (y > 0)
        {
            if (x > 0)
            {
                while (temp >= x)
                {
                    temp -= x; q++;
                }
            }
            else
            {
                while (temp >= (0 - x))
                {
                    temp += x; q--;
                }
            }
        }
        else
        {
            if (x > 0)
            {
                while ((0 - temp) >= x)
                {
                    temp += x; q--;
                }
                if (flag)
                {
                    temp--;
                    while ((0 - temp) >= x)
                    {
                        temp += x; q--;
                    }
                }
            }
            if (x < 0)
            {
                while ((0 - temp) >= (0 - x))
                {
                    temp -= x; q++;
                }
                if (flag)
                {
                    temp--;
                    while ((0 - temp) >= (0 - x))
                    {
                        temp -= x; q++;
                    }
                }
            }
        }
        return q;
    }
}
