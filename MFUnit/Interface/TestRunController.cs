using System;
using Microsoft.SPOT;
using System.Threading;
using System.Reflection;

namespace MFUnit.Interface
{
    class TestRunController
    {
        private TestRunView view;
        private TestRun runner;
        private Assembly testAssembly;

        public TestRunController(Assembly testAssembly)
        {
            this.testAssembly = testAssembly;
        }

        public void Show()
        {
            this.view = new TestRunView();
            Application.Current.MainWindow.Child = view;

            runner = new TestRun(testAssembly);
            runner.TestCompleted += new TestCompletedEventHandler(runner_TestCompleted);
            runner.AllTestsCompleted += new EventHandler(runner_AllTestsCompleted);
            new Thread(new ThreadStart(runner.Execute)).Start();
        }

        int passed = 0, failed = 0;
        void runner_TestCompleted(TestRun sender, TestCompletedEventArgs args)
        {
            var testList = view as TestRunView;
            if (testList == null) return;
            if (args.Result.Pass)
                testList.PassedCount = (++passed).ToString();
            else
                testList.FailedCount = (++failed).ToString();
        }

        void runner_AllTestsCompleted(object sender, EventArgs e)
        {
            var testList = view as TestRunView;
            if (testList == null) return;
            testList.Complete();
        }
    }
}
