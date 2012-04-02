using System;
using Microsoft.SPOT;

namespace MFUnit.Tests
{
    public class AssertTests
    {
        public void AssertIsNull_ShouldPass_WhenActualIsNull()
        {
            Assert.IsNull(null);
        }

        public void AssertIsNull_ShouldFail_WhenActualIsNotNull()
        {
            Assert.Throws(() => Assert.IsNull(1), typeof(AssertException));
        }

        public void AssertIsNotNull_ShouldPass_WhenActualIsNotNull()
        {
            Assert.IsNotNull(1);
        }

        public void AssertIsNotNull_ShouldFail_WhenActualIsNull()
        {
            Assert.Throws(() => Assert.IsNotNull(null), typeof(AssertException));
        }

        public void AssertIsTrue_ShouldPass_WhenActualIsTrue()
        {
            Assert.IsTrue(true);
        }

        public void AssertIsTrue_ShouldFail_WhenActualIsNull()
        {
            Assert.Throws(() => Assert.IsTrue(false), typeof(AssertException));
        }

        public void AssertIsFalse_ShouldPass_WhenActualIsFalse()
        {
            Assert.IsFalse(false);
        }

        public void AssertIsFalse_ShouldFail_WhenActualIsNull()
        {
            Assert.Throws(() => Assert.IsFalse(true), typeof(AssertException));
        }

        public void AssertFail_ShouldThrowException()
        {
            Assert.Throws(() => Assert.Fail("test"), typeof(AssertException));
        }

        public void AssertAreEqual_ShouldPass_WhenExpectedAndActualEqual()
        {
            Assert.AreEqual(1, 1);
        }

        public void AssertAreEqual_ShouldFail_WhenExpectedAndActualNotEqual()
        {
            Assert.Throws(() => Assert.AreEqual(1, 2), typeof(AssertException));
        }

        public void AssertThrows_ShouldPass_WhenExpectedExceptionThrown()
        {
            Assert.Throws(() => { throw new NotImplementedException(); }, typeof(NotImplementedException));
        }

        public void AssertThrows_ShouldFail_WhenExpectedExceptionThrown()
        {
            try
            {
                Assert.Throws(() => { return; }, typeof(NotImplementedException));
            }
            catch (AssertException)
            {
                return;
            }
            Assert.Fail("Assert.Throws did not fail when no exception was thrown.");
        }

        public void AssertThrows_ShouldOnlyCatchExpectedException()
        {
            try
            {
                Assert.Throws(() => { throw new NotImplementedException(); }, typeof(ArgumentException));
            }
            catch (NotImplementedException)
            {
                return;
            }
            Assert.Fail("NotImplementedException was caught by Assert.Throws when ArgumentException was specified.");
        }
    }
}
