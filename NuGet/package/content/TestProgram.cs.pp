using System;
using Microsoft.SPOT;
using System.Reflection;

namespace $rootnamespace$
{
    public class TestProgram : TestApplication
    {
        public static void Main()
        {
            var app = new TestProgram();
            app.Run(Assembly.GetAssembly(typeof(TestProgram)));
        }
    }
}
