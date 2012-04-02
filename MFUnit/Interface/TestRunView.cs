using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace MFUnit.Interface
{
    class TestRunView : ContentControl
    {
        StackPanel mainPanel;
        Text passedCount;
        Text failedCount;
        Text completeLabel;

        public TestRunView()
        {
            mainPanel = new StackPanel(Orientation.Vertical) { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };

            var passedPanel = new StackPanel(Orientation.Horizontal);

            var passedLabel = new Text(Resources.GetFont(Resources.FontResources.nina14), "Passed: ") { ForeColor = Colors.Green };
            passedPanel.Children.Add(passedLabel);

            passedCount = new Text(Resources.GetFont(Resources.FontResources.nina14), "0");
            passedPanel.Children.Add(passedCount);

            mainPanel.Children.Add(passedPanel);

            var failedPanel = new StackPanel(Orientation.Horizontal);

            var failedLabel = new Text(Resources.GetFont(Resources.FontResources.nina14), "Failed: ");
            failedLabel.ForeColor = Colors.Green;
            failedPanel.Children.Add(failedLabel);

            failedCount = new Text(Resources.GetFont(Resources.FontResources.nina14), "0");
            failedPanel.Children.Add(failedCount);

            mainPanel.Children.Add(failedPanel);

            completeLabel = new Text(Resources.GetFont(Resources.FontResources.nina14), "Test run complete!");
            completeLabel.Visibility = Visibility.Hidden;
            mainPanel.Children.Add(completeLabel);

            this.Child = mainPanel;
        }

        public string PassedCount
        {
            get { return passedCount.TextContent; }
            set
            {
                passedCount.Dispatcher.BeginInvoke(new DispatcherOperationCallback(delegate(object args)
                {
                    passedCount.TextContent = args as string;
                    return null;
                }), value);
            }
        }

        public string FailedCount
        {
            get { return failedCount.TextContent; }
            set
            {
                failedCount.Dispatcher.BeginInvoke(new DispatcherOperationCallback(delegate(object args)
                {
                    failedCount.TextContent = args as string;
                    return null;
                }), value);
            }
        }

        public void Complete()
        {
            completeLabel.Dispatcher.BeginInvoke(new DispatcherOperationCallback(delegate(object args)
            {
                completeLabel.ForeColor = FailedCount != "0" ? Colors.Red : Colors.Green;
                completeLabel.Visibility = Visibility.Visible;
                return null;
            }), null);
        }
    }
}
