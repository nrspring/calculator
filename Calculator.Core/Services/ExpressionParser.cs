using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Enumerations;
using Calculator.Core.ExtensionMethods;
using Calculator.Core.Interfaces;

namespace Calculator.Core.Services
{
    public class ExpressionParser : IExpressionParser
    {
        public IEnumerable<Models.Expression> ParseExpressions(string value)
        {
            var tokens = value.AddAllTokens().Split(new char[] { '|'}, StringSplitOptions.RemoveEmptyEntries);
            var typeMappings = GetTypeMappings();

            return tokens.Select(current =>
                new Models.Expression()
                {
                    OriginalValue = current.Trim(),
                    ExpressionType = typeMappings.ContainsKey(current) ? typeMappings[current] : ExpressionTypes.Value
                });
        }

        private Dictionary<string, string> GetTypeMappings()
        {
            return new Dictionary<string, string>()
            {
                {"+", ExpressionTypes.AddOperator},
                {"-", ExpressionTypes.SubtractOperator},
                {"*", ExpressionTypes.MultiplyOperator},
                {"/", ExpressionTypes.DivideOperator},
            };
        }
    }
}
