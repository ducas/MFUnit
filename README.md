MFUnit
======

A .Net Micro Framework Unit Testing Library.

Getting Started
---------------

*** NuGet
1. Create a Micro Framework Console Application for your tests.
2. Install-Package MFUnit
3. Profit!

*** Manual Installation

1. Create a Micro Framework Console Application for your tests.
2. Add a reference to MFUnit and Microsoft.SPOT.TinyCore.
3. Make your Program class inherit TestApplication and add the following code to your Main entry point method:

	var app = new Program();
	app.Run(Assembly.GetAssembly(typeof(Program)));

4. Write your tests.

Writing Tests
-------------

MFUnit uses convention to discover tests. It looks for classes ending in the word "Tests" and executes any public methods that have a void return type.

Using the Assert static class, you can ensure your methods return the correct results. E.g.

	public class SampleTests
	{
		public void AddNumbers()
		{
			Assert.AreEqual(2, 1 + 1);
		}
	}

Running Tests
-------------

Simply hit F5! Then watch the emulator count through your tests. If you have failed tests, open the Output window in Visual Studio and spend a minute (or 10) going through the Debug messages. Look for lines that start with "FAIL".
