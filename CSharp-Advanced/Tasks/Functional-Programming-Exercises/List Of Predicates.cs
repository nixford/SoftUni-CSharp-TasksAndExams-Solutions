﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> numbers = new List<int>();

            Func<int, bool>[] predicates = dividers
                .Select(div => (Func<int, bool>)(n => n % div == 0))
                .ToArray();

            for (int i = 1; i <= endRange; i++)
            {
                if (ChaeckForValidation(predicates, i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool ChaeckForValidation(Func<int, bool>[] predicates, int num)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(num))
                {
                    return false;
                }
            }
            return true;
        }    
    }
}
