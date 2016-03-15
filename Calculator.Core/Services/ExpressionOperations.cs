using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Enumerations;
using Calculator.Core.Interfaces;
using Calculator.Core.Models;

namespace Calculator.Core.Services
{
    public class ExpressionOperations : IExpressionOperations
    {
        public Models.Expression ProcessExpression(Models.Expression leftSide, Models.Expression operation,
            Models.Expression rightSide)
        {
            var returnItem = new Models.Expression()
            {
                ExpressionType = ExpressionTypes.Value
            };

            var operations = CreateOperationsDictionary();

            var selectedOperation = operations[operation.ExpressionType];
            var value = selectedOperation(leftSide.SegmentValue.ParsedValue, rightSide.SegmentValue.ParsedValue);
            returnItem.SegmentValue = new NumberSegment(value.ToString())
            {
                ParsedValue = value,
                ParseType = ParseType.Decimal
            };

            return returnItem;
        }

        private Dictionary<string, Func<decimal, decimal, decimal>> CreateOperationsDictionary()
        {
            return new Dictionary<string, Func<decimal, decimal, decimal>>()
            {
                {Core.Enumerations.ExpressionTypes.AddOperator, (decimal left, decimal right)=> left + right},
                {Core.Enumerations.ExpressionTypes.SubtractOperator,(decimal left, decimal right)=> left - right},
                {Core.Enumerations.ExpressionTypes.MultiplyOperator,(decimal left, decimal right)=> left * right},
                {Core.Enumerations.ExpressionTypes.DivideOperator,(decimal left, decimal right)=> left / right},
            };
        }
    }
}
