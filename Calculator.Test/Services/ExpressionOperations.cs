using System;
using Calculator.Core.Enumerations;
using Calculator.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test.Services
{
    [TestClass]
    public class ExpressionOperations
    {
        [TestMethod]
        public void DoesExpressionOperationProperlyAddValues()
        {
            decimal expectedValue = 13;

            var leftSide = CreateSide(6);
            var rightSide = CreateSide(7);
            var opr = CreateOperator(ExpressionTypes.AddOperator);

            var operationsExpression = new Core.Services.ExpressionOperations();

            var result = operationsExpression.ProcessExpression(leftSide, opr, rightSide);
            Assert.AreEqual(expectedValue,result.SegmentValue.ParsedValue);
        }

        [TestMethod]
        public void DoesExpressionOperationProperlySubtractValues()
        {
            decimal expectedValue = 3;

            var leftSide = CreateSide(62);
            var rightSide = CreateSide(59);
            var opr = CreateOperator(ExpressionTypes.SubtractOperator);

            var operationsExpression = new Core.Services.ExpressionOperations();

            var result = operationsExpression.ProcessExpression(leftSide, opr, rightSide);
            Assert.AreEqual(expectedValue, result.SegmentValue.ParsedValue);
        }

        [TestMethod]
        public void DoesExpressionOperationProperlyMultiplyValues()
        {
            decimal expectedValue = 30;

            var leftSide = CreateSide(10);
            var rightSide = CreateSide(3);
            var opr = CreateOperator(ExpressionTypes.MultiplyOperator);

            var operationsExpression = new Core.Services.ExpressionOperations();

            var result = operationsExpression.ProcessExpression(leftSide, opr, rightSide);
            Assert.AreEqual(expectedValue, result.SegmentValue.ParsedValue);
        }

        [TestMethod]
        public void DoesExpressionOperationProperlyDivideValues()
        {
            decimal expectedValue = 2.5m;

            var leftSide = CreateSide(5);
            var rightSide = CreateSide(2);
            var opr = CreateOperator(ExpressionTypes.DivideOperator);

            var operationsExpression = new Core.Services.ExpressionOperations();

            var result = operationsExpression.ProcessExpression(leftSide, opr, rightSide);
            Assert.AreEqual(expectedValue, result.SegmentValue.ParsedValue);
        }


        private Core.Models.Expression CreateSide(decimal value)
        {
            return new Core.Models.Expression()
            {
                ExpressionType = ExpressionTypes.Value,
                SegmentValue = new NumberSegment(value.ToString())
                {
                    ParsedValue = value,
                    ParseType = ParseType.Decimal
                }
            };
        }

        private Core.Models.Expression CreateOperator(string opr)
        {
            return new Expression()
            {
                ExpressionType = opr
            };
        }
    }
}
