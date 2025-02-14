﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidUrlException : Exception
    {
        private const string EXC_MSG = "Invalid URL!";
        public InvalidUrlException()
            : base(EXC_MSG)
        {
           
        }

        public InvalidUrlException(string message) 
            : base(message)
        {

        }
    }
}
