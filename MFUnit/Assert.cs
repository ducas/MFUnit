using System;
using Microsoft.SPOT;

namespace MFUnit
{
    public class Assert
    {
        public static void AreEqual(object expected, object actual)
        {
            if (expected == null && expected == actual) return;
            if (expected == null || !expected.Equals(actual)) Fail("Expected: \"" + expected + "\", Actual: \"" + actual + "\".");
        }

        public static void IsTrue(bool actual)
        {
            AreEqual(true, actual);
        }

        public static void IsFalse(bool actual)
        {
            AreEqual(false, actual);
        }

        public static void Fail(string message)
        {
            throw new AssertException(message);
        }

        public static void IsNull(object actual)
        {
            if (actual != null) Fail("Expected: \"null\", Actual: \"not null\".");
        }

        public static void IsNotNull(object actual)
        {
            if (actual == null) Fail("Expected: \"not null\", Actual: \"null\".");
        }

        public static void Throws(ThrowsAction action, Type exceptionType)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == exceptionType) return;
                throw;
            }
            Fail("Expected exception of type " + exceptionType.Name + " was not thrown.");
        }

        public delegate void ThrowsAction();
    }
}
