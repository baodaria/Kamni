using System;
using System.Collections.Generic;
using System.Text;

namespace Kamni
{
    public class CheckNumberException : Exception
    {
        public CheckNumberException(string message) : base(message)
        {
        }
    }
}
