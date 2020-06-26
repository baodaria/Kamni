using System;
using System.Collections.Generic;
using System.Text;

namespace Kamni
{
    public class CheckWrittennumbers : Exception
    {
        public CheckWrittennumbers(string message) : base(message)
        {
        }
    }
}
