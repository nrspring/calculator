using System;
using System.Collections.Generic;
using Calculator.Core.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Calculator.Test.Services
{
    [TestClass]
    public class RomanParser
    {
        [TestMethod]
        public void TestValidRomanNumeralValues()
        {
            var items = new List<Tuple<string,decimal>>()
            {
                new Tuple<string, decimal>("I",1),
                new Tuple<string, decimal>("V",5),
                new Tuple<string, decimal>("X",10),
                new Tuple<string, decimal>("L",50),
                new Tuple<string, decimal>("C",100),
                new Tuple<string, decimal>("D",500),
                new Tuple<string, decimal>("M",1000),
                new Tuple<string, decimal>("DCCC",800),
                new Tuple<string, decimal>("CD",400),
                new Tuple<string, decimal>("IX",9),
                new Tuple<string, decimal>("VI",6),
                new Tuple<string, decimal>("VII",7),
                new Tuple<string, decimal>("LXXX",80),
                new Tuple<string, decimal>("MCMLXXXIV",1984),
                new Tuple<string, decimal>("MMDCCLXXXIV",2784),
            };

            var parser = new Calculator.Core.Services.RomanParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current.Item1);
                Assert.AreEqual(Core.Enumerations.ParseType.Roman, result.ParseType);
                Assert.AreEqual(current.Item2, result.ParsedValue);
            }
        }

        [TestMethod]
        public void TestInvalidRomanNumeralValues()
        {
            var items = new List<String>()
            {
                "A",
                "100",
                "B1010101",
                "HGGGG"
            };

            var parser = new Calculator.Core.Services.RomanParser();

            foreach (var current in items)
            {
                var result = parser.Parse(current);
                Assert.AreEqual(Core.Enumerations.ParseType.Unknown, result.ParseType);
                Assert.AreEqual(0, result.ParsedValue);
            }
        }
    }
}
