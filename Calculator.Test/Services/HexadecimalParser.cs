using System;
using System.Collections.Generic;
using Calculator.Core.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class HexadecimalParser
    {
        [TestMethod]
        public void TestValidHexadecimalValues()
        {
            var items = new List<String>()
            {
                "H0",
                "H1",
                "HFFFF",
                "H5000"
            };

            var parser = new Calculator.Core.Services.HexadecimalParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Hexadecimal, result.ParseType);
                Assert.AreEqual(current.GetDecimalFromHexadecimal(), result.ParsedValue);
            }
        }

        [TestMethod]
        public void TestInvalidHexadecimalValues()
        {
            var items = new List<String>()
            {
                "A",
                "XVII",
                "100",
                "B1010101",
                "HGGGG"
            };

            var parser = new Calculator.Core.Services.HexadecimalParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Unknown, result.ParseType);
                Assert.AreEqual(0, result.ParsedValue);
            }
        }
    }
}
