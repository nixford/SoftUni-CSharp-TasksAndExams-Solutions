﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private const int PERSONS_MIN_AGE = 0;
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public virtual int Age 
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value >= PERSONS_MIN_AGE)
                {
                    this.age = value;
                }
            }       
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
