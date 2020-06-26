using System;
using System.Collections.Generic;
using System.Text;

namespace Kamni
{
    public class CheckVariantException : Exception
    {
        public CheckVariantException(string message) : base(message)
        {
        }
    }
}
