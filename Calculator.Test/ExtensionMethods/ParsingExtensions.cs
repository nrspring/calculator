using System;
using System.Collections.Generic;
using Calculator.Core.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.ExtensionMethods
{
    [TestClass]
    public class ParsingExtensions
    {
        [TestMethod]
        public void DoesIsMarkedAsBinaryWorkCorrectly()
        {
            string goodValue = "B101";
            string badValue = "101";

            Assert.IsTrue(goodValue.IsMarkedAsBinary());
            Assert.IsFalse(badValue.IsMarkedAsBinary());
        }

        [TestMethod]
        public void DoesGetDecimalFromBinaryWorkCorrectly()
        {
            string stringValue = "B101";
            decimal decimalValue = 5;

            Assert.AreEqual(decimalValue,stringValue.GetDecimalFromBinary());
        }

        [TestMethod]
        public void DoesIsMarkedAsHexadecimalWorkCorrectly()
        {
            string goodValue = "HFFFF";
            string badValue = "FFFF";

            Assert.IsTrue(goodValue.IsMarkedAsHexadecimal());
            Assert.IsFalse(badValue.IsMarkedAsHexadecimal());
        }

        [TestMethod]
        public void DoesIsValidRomanNumeralWorkCorrectlyForValidNumerals()
        {
            var items = new List<String>()
            {
                "I","V","X","L","C","D","M",
                "i","v","x","l","c","d","m",
                "XIV","MMM","LCM"
            };

            foreach (var current in items)
            {
                Assert.IsTrue(current.IsValidRomanNumeral());
            }
        }

        [TestMethod]
        public void DoesIsValidRomanNumeralWorkCorrectlyForInvalidNumerals()
        {
            var items = new List<String>()
            {
                "A","VA","123","B101","HFFFF","MCM8"
            };

            foreach (var current in items)
            {
                Assert.IsFalse(current.IsValidRomanNumeral());
            }
        }
    }
}
