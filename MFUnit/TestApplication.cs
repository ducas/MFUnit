using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using MFUnit.Interface;
using System.Reflection;

namespace MFUnit
{
    public class TestApplication : Application
    {
        public Assembly TestAssembly { get; set; }

        public TestApplication()
        {
            TestAssembly = Assembly.GetAssembly(this.GetType());
        }

        public TestApplication(Assembly testAssembly)
        {
            this.TestAssembly = testAssembly;
        }

        public new void Run()
        {
            Run(new Window() { Height = SystemMetrics.ScreenHeight, Width = SystemMetrics.ScreenWidth, Visibility = Visibility.Visible });
        }

        protected override void OnStartup(EventArgs e)
        {
            var controller = new TestRunController(TestAssembly);
            controller.Show();
            base.OnStartup(e);
        }
    }
}
