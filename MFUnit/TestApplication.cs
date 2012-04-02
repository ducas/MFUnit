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

        public void Run(Assembly testAssembly)
        {
            this.TestAssembly = testAssembly;

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
