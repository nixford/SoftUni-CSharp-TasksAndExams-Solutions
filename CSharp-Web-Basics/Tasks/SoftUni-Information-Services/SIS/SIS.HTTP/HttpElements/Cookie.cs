﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.HttpElements
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
