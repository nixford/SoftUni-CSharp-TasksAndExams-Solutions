﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = Console.ReadLine();
            String str2 = Console.ReadLine();

            if ((str1[0] == '-' || str2[0] == '-') &&
                (str1[0] != '-' || str2[0] != '-'))
                Console.Write("-");

            if (str1[0] == '-' && str2[0] != '-')
            {
                str1 = str1.Substring(1);
            }
            else if (str1[0] != '-' && str2[0] == '-')
            {
                str2 = str2.Substring(1);
            }
            else if (str1[0] == '-' && str2[0] == '-')
            {
                str1 = str1.Substring(1);
                str2 = str2.Substring(1);
            }
            Console.WriteLine(multiply(str1, str2));
        }

        static String multiply(String num1, String num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;
            if (len1 == 0 || len2 == 0)
            {
                return "0";
            }                           
            int[] result = new int[len1 + len2];            
            int i_n1 = 0;
            int i_n2 = 0;
            int i;
            
            for (i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = num1[i] - '0';               
                i_n2 = 0;
                
                for (int j = len2 - 1; j >= 0; j--)
                {                    
                    int n2 = num2[j] - '0';                    
                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;                   
                    carry = sum / 10;                   
                    result[i_n1 + i_n2] = sum % 10;
                    i_n2++;
                }

                if (carry > 0)
                {
                    result[i_n1 + i_n2] += carry;
                }          
                i_n1++;
            }            
            i = result.Length - 1;

            while (i >= 0 && result[i] == 0)
            {
                i--;
            }              

            if (i == -1)
            {
                return "0";
            }
            
            String s = "";

            while (i >= 0)
            {
                s += (result[i--]);
            }               

            return s;
        }
    }
}
