using System;
using Microsoft.SPOT;

namespace MFUnit
{
    public class AssertException : Exception
    {
        public AssertException(string message)
            : base(message)
        {
        }
    }
}
