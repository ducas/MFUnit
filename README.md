MFUnit
======

A .Net Micro Framework Unit Testing Library.

Getting Started
---------------

### NuGet Installation

1. Create a Micro Framework Console Application for your tests.
2. Install-Package MFUnit
3. Profit!

### Manual Installation

1. Create a Micro Framework Console Application for your tests.
2. Add a reference to MFUnit and Microsoft.SPOT.TinyCore.
3. Make your Program class inherit TestApplication and add the code after this list to your Main entry point method.
4. Write your tests

Your main should look like this:

	var app = new Program();
	app.Run(Assembly.GetAssembly(typeof(Program)));


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
			Assert.IsNull(1);
		}

		public void AssertIsNull_ShouldFail_WhenActualIsNotNull()
		{
			Assert.Throws(() => Assert.IsNull(1), typeof(AssertException));
		}
	}

This will produce the following messages in the Output window's Debug output.

	A first chance exception of type 'MFUnit.AssertException' occurred in MFUnit.dll
	FAIL AssertTests.AssertIsNull_ShouldPass_WhenActualIsNull: Expected: "null", Actual: "not null".
		#### Exception MFUnit.AssertException - 0x00000000 (3) ####
		#### Message: Expected: "null", Actual: "not null".
		#### MFUnit.Assert::Fail [IP: 0005] ####
		#### MFUnit.Assert::IsNull [IP: 000f] ####
		#### MFUnit.Tests.AssertTests::<AssertIsNull_ShouldFail_WhenActualIsNotNull>b__0 [IP: 0007] ####
		#### MFUnit.Assert::Throws [IP: 0006] ####
		#### MFUnit.Tests.AssertTests::AssertIsNull_ShouldFail_WhenActualIsNotNull [IP: 0021] ####
		#### System.Reflection.MethodBase::Invoke [IP: 0000] ####
		#### MFUnit.TestRun::Execute [IP: 00b6] ####
	A first chance exception of type 'MFUnit.AssertException' occurred in MFUnit.dll
	PASS AssertTests.AssertIsNull_ShouldFail_WhenActualIsNotNull