﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.FirstName} {this.LastName} is {this.Age} years old.");

            return sb.ToString().TrimEnd();
        }
    }
}
