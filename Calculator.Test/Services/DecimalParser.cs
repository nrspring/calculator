using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class DecimalParser
    {
        [TestMethod]
        public void TestValidDecimalValues()
        {
            var items = new List<String>()
            {
                "0",
                "123",
                "45.73",
                "1000000",
                "1,000,000"
            };

            var parser = new Calculator.Core.Services.DecimalParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Decimal,result.ParseType);
                Assert.AreEqual(Decimal.Parse(current),result.ParsedValue);
            }
        }

        [TestMethod]
        public void TestInvalidDecimalValues()
        {
            var items = new List<String>()
            {
                "A",
                "XVII",
                "H100",
                "B1010101",
                "1.00.00"
            };

            var parser = new Calculator.Core.Services.DecimalParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Unknown, result.ParseType);
                Assert.AreEqual(0, result.ParsedValue);
            }
        }
    }
}
