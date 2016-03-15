using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Enumerations;
using Calculator.Core.Interfaces;

namespace Calculator.Core.Services
{
    public class ExpressionProcessor : IExpressionProcessor
    {
        public IExpressionParser ParserExpression { get; set; }
        public ICompositeParser ParserComposite { get; set; }
        public IExpressionOperations OperationsExpression { get; set; }

        public ExpressionProcessor(IExpressionParser parserExpression, ICompositeParser parserComposite, IExpressionOperations operationsExpression)
        {
            ParserExpression = parserExpression;
            ParserComposite = parserComposite;
            OperationsExpression = operationsExpression;
        }

        public Models.ExpressionResult Process(string value)
        {
            var returnValue = new Models.ExpressionResult()
            {
                OriginalValue = value
            };

            var parsed = ParserExpression.ParseExpressions(value).ToList();
            parsed.ForEach(PopulateSegmentValue);


            returnValue.Expressions = parsed;
            returnValue.IsValid = AreAllSegmentsValid(parsed);
            returnValue.TotalSum = GetTotalValue(parsed);

            return returnValue;
        }

        private decimal GetTotalValue(List<Models.Expression> expressions)
        {
            var processDivide = CollapseGivenOperation(expressions, ExpressionTypes.DivideOperator);
            var processMultiply = CollapseGivenOperation(processDivide, ExpressionTypes.MultiplyOperator);
            var processSubtraction = CollapseGivenOperation(processMultiply, ExpressionTypes.SubtractOperator);
            var processAddition = CollapseGivenOperation(processSubtraction, ExpressionTypes.AddOperator);

            return processAddition[0].SegmentValue.ParsedValue;
        }

        private List<Models.Expression> CollapseGivenOperation(List<Models.Expression> expressions, string expressionType)
        {
            if(expressions.All(x => x.ExpressionType != expressionType)) return expressions;

            var returnValue = new List<Models.Expression>();

            for (int index = 0; index < expressions.Count; index++)
            {
                var left = expressions[index];
                var middle = index>expressions.Count-2?null: expressions[index + 1];
                var right = index > expressions.Count - 3 ? null : expressions[index + 2];

                if (middle == null || right == null ||middle.ExpressionType != expressionType)
                {
                    returnValue.Add(left);
                }
                else
                {
                    returnValue.Add(OperationsExpression.ProcessExpression(left,middle,right));
                    index = index + 2;
                }
            }

            return CollapseGivenOperation(returnValue,expressionType);
        }


        private bool AreAllSegmentsValid(List<Models.Expression> expressions)
        {
            return
                expressions.Where(x => x.ExpressionType == ExpressionTypes.Value)
                    .All(y => y.SegmentValue.ParseType != ParseType.Unknown);
        }

        private void PopulateSegmentValue(Models.Expression value)
        {
            if (value.ExpressionType == ExpressionTypes.Value)
            {
                value.SegmentValue = ParserComposite.GetSegmentFromValue(value.OriginalValue);
            }
        }
    }
}
