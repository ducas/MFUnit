MFUnit
======

A .Net Micro Framework Unit Testing Library.

Getting Started
---------------

### NuGet Installation

1. Create a Micro Framework Console Application for your tests.
2. Install-Package MFUnit
3. Profit!

NOTE: The NuGet installer will create a class named TestProgram that inherits MFUnit.TestApplication which kicks off the TestRun. If you want to write your own bootstrapper or use an existing entry point then delete this class or set the Startup Object in your Project Properties. Otherwise, simply delete your Program class and you're on your way!

### Manual Installation

1. Create a Micro Framework Console Application for your tests.
2. Add a reference to MFUnit and Microsoft.SPOT.TinyCore.
3. Make your Program class inherit TestApplication and add the code after this list to your Main entry point method.
4. Write your tests

Your Main method should look like this:

	new Program().Run();


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

Tests that pass will be displayed as `PASS [TestClass].[TestMethod]`. Tests that failed will be displayed as `FAIL [TestClass].[TestName]: [Message]`.

Take the following test class:

	public class AssertTests
	{
		public void AssertIsNull_ShouldPass_WhenActualIsNull()
		{
			Assert.IsNull(null);
		}

		public void AssertIsNull_ShouldFail_WhenActualIsNotNull()
		{
			Assert.IsNull(1);
		}
	}

This will produce the following messages in the Output window's Debug output.

	PASS AssertTests.AssertIsNull_ShouldFail_WhenActualIsNull
	    #### Exception MFUnit.AssertException - 0x00000000 (3) ####
		#### Message: Expected: "null", Actual: "not null".
		#### MFUnit.Assert::Fail [IP: 0005] ####
		#### MFUnit.Assert::IsNull [IP: 000f] ####
		#### MFUnit.Tests.AssertTests::AssertIsNull_ShouldPass_WhenActualIsNull [IP: 0008] ####
		#### System.Reflection.MethodBase::Invoke [IP: 0000] ####
		#### MFUnit.TestRun::Execute [IP: 00b6] ####
	A first chance exception of type 'MFUnit.AssertException' occurred in MFUnit.dll
	FAIL AssertTests.AssertIsNull_ShouldPass_WhenActualIsNotNull: Expected: "null", Actual: "not null".
