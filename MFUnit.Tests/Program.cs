using System;
using Microsoft.SPOT;
using System.Reflection;

namespace MFUnit.Tests
{
    public class Program : TestApplication
    {
        public static void Main()
        {
            var app = new Program();
            app.Run(Assembly.GetAssembly(typeof(Program)));
        }
    }
}
