using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Calculator.Core.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class CompositeParser
    {
        [TestMethod]
        public void DoesParserReturnCorrectValues()
        {
            var items = new List<Tuple<string, decimal, string>>()
            {
                new Tuple<string, decimal, string>("152.3", 152.3m, ParseType.Decimal),
                new Tuple<string, decimal, string>("B101010", 42, ParseType.Binary),
                new Tuple<string, decimal, string>("HFFFF", 65535, ParseType.Hexadecimal),
                new Tuple<string, decimal, string>("MMXVI", 2016, ParseType.Roman),
                new Tuple<string, decimal, string>("BOB", 0, ParseType.Unknown),
            };

            var parser = new Core.Services.CompositeParser();

            foreach (var current in items)
            {
                var result = parser.GetSegmentFromValue(current.Item1);
                Assert.AreEqual(current.Item2,result.ParsedValue);
                Assert.AreEqual(current.Item3, result.ParseType);
            }
        }
    }
}
