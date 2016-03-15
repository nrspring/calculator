using System;
using System.Collections.Generic;
using Calculator.Core.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class BinaryParser
    {
        [TestMethod]
        public void TestValidBinaryValues()
        {
            var items = new List<String>()
            {
                "B0",
                "B1",
                "B11",
                "B1101",
                "b0",
                "b1",
                "b11",
                "b1101"
            };

            var parser = new Calculator.Core.Services.BinaryParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Binary, result.ParseType);
                Assert.AreEqual(current.GetDecimalFromBinary(), result.ParsedValue);
            }
        }

        [TestMethod]
        public void TestInvalidVBinaryValues()
        {
            var items = new List<String>()
            {
                "A",
                "XVII",
                "H100",
                "1010101",
                "1.00.00"
            };

            var parser = new Calculator.Core.Services.BinaryParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Unknown, result.ParseType);
                Assert.AreEqual(0, result.ParsedValue);
            }
        }
    }
}
