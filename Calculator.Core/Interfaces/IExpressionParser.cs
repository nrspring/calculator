using System.Collections.Generic;

namespace Calculator.Core.Interfaces
{
    public interface IExpressionParser
    {
        IEnumerable<Models.Expression> ParseExpressions(string value);
    }
}