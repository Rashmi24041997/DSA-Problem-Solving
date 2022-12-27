using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Easy
{
    internal class Roman_to_Integer
    {
        //Console.WriteLine("Hello, World!");

        public int Cnvrt_Roman_to_Integer(string? s)
        {
            int num = 0;
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            else
            {
                char c;

                for (int i = 0; i < s.Length; i++)
                {
                    c = s[i];
                    switch (c)
                    {
                        case 'I'://1
                            if (((i + 1) < s.Length) &&  s[i + 1] == 'V')
                            {
                                num += 4; i++;
                            }
                            else if ((i + 1) < s.Length && s[i + 1] == 'X')
                            {
                                num += 19; i++;
                            }
                            else
                                num += 1;
                            break;
                        case 'V'://5
                            num += 5;
                            break;

                        case 'X'://10
                            if ((i + 1) < s.Length && s[i + 1] == 'L')
                            { num += 40; i++; }

                            else if ((i + 1) < s.Length && s[i + 1] == 'C')
                            { num += 90; i++; }
                            else
                                num += 10;
                            break;

                        case 'L'://50
                            num += 50;
                            break;

                        case 'C'://100
                            if ((i + 1) < s.Length && s[i + 1] == 'D')
                            { num += 400; i++; }
                            else if ((i + 1) < s.Length && s[i + 1] == 'M')
                            {
                                num += 900; i++;
                            }
                            else
                                num += 100;
                            break;

                        case 'D'://500
                            num += 500;
                            break;

                        case 'M'://1000
                            num += 1000;
                            break;
                    }
                }
            }
            return num;
        }


    }
}
