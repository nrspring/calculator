using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Core.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class ExpressionParser
    {
        [TestMethod]
        public void DoesTheParserParseItemsCorrectly()
        {
            string original = "10+HFFFF - B10101    * XIV / 32.5";

            var expectedResults = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>(ExpressionTypes.Value, "10"),
                new Tuple<string, string>(ExpressionTypes.AddOperator, "+"),
                new Tuple<string, string>(ExpressionTypes.Value, "HFFFF"),
                new Tuple<string, string>(ExpressionTypes.SubtractOperator, "-"),
                new Tuple<string, string>(ExpressionTypes.Value, "B10101"),
                new Tuple<string, string>(ExpressionTypes.MultiplyOperator, "*"),
                new Tuple<string, string>(ExpressionTypes.Value, "XIV"),
                new Tuple<string, string>(ExpressionTypes.DivideOperator, "/"),
                new Tuple<string, string>(ExpressionTypes.Value, "32.5")
            };

            var parser = new Core.Services.ExpressionParser();
            var result = parser.ParseExpressions(original).ToList();

            Assert.AreEqual(expectedResults.Count, result.Count);

            for (int index = 0; index < result.Count; index++)
            {
                Assert.AreEqual(result[index].OriginalValue,expectedResults[index].Item2);
                Assert.AreEqual(result[index].ExpressionType, expectedResults[index].Item1);
            }
        }
    }
}
