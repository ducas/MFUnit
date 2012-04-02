using System;
using Microsoft.SPOT;

namespace MFUnit
{
    public class TestResult
    {
        public bool Pass { get; set; }
        public string TestClass { get; set; }
        public string TestMethod { get; set; }
        public string Message { get; set; }
    }
}
