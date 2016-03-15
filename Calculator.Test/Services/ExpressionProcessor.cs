using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class ExpressionProcessor
    {
        [TestMethod]
        public void DoesTheProcessorReturnCorrectValuesForIsValid()
        {
            var items = new List<Tuple<string,bool>>()
            {
                new Tuple<string, bool>("1+2+3+4", true),
                new Tuple<string, bool>("1+XIV+B101+HFF", true),
                new Tuple<string, bool>("1+BOB+3+4", false)
            };

            var processor = GetProcessor();

            foreach (var current in items)
            {
                var result = processor.Process(current.Item1);
                Assert.AreEqual(current.Item2,result.IsValid);
            }
        }

        [TestMethod]
        public void DoesTheProcessorProperlyIdentifySegments()
        {
            string original = "1+XIV+B101+HFF";
            int expectedSegements = 7;

            var processor = GetProcessor();
            var result = processor.Process(original);

            Assert.AreEqual(expectedSegements,result.Expressions.Count);
        }

        [TestMethod]
        public void DoesTheProcessorProperlyCalculateTotals()
        {
            var items = new List<Tuple<string,decimal>>()
            {
                new Tuple<string, decimal>("1+2+3+4",10),
                new Tuple<string, decimal>("4+5+6",15),
                new Tuple<string, decimal>("10-2+3-5",6),
                new Tuple<string, decimal>("10+XIV+HFF+B101",284),
                new Tuple<string, decimal>("3+6/2",6),
                new Tuple<string, decimal>("3*6/2+ 5",14),
                new Tuple<string, decimal>("100/10/2",5),
            };

            var processor = GetProcessor();

            foreach (var current in items)
            {
                var result = processor.Process(current.Item1);
                Assert.AreEqual(current.Item2, result.TotalSum);
            }

        }

        private Core.Services.ExpressionProcessor GetProcessor()
        {
            //Not truly a unit test because the dependencies arent mocked, but I am rolling a number of tests in to
            //one to be refactored later
            var parserExpression = new Core.Services.ExpressionParser();
            var parserComposite = new Core.Services.CompositeParser();
            var operationsExpression = new Core.Services.ExpressionOperations();
            return new Core.Services.ExpressionProcessor(parserExpression, parserComposite, operationsExpression);
        }
    }
}
