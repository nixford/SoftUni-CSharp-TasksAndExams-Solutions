﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {


        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type
                .GetMethods
                (BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attrubutes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attrubutes)
                    {
                        Console.WriteLine("{0} is written by {1}", 
                            method.Name, attr.Name);
                    }
                }
            }
        }
    }
}
