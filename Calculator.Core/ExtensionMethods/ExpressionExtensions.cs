using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.ExtensionMethods
{
    public static class ExpressionExtensions
    {
        public static string AddTokens(this string value, string searchToken)
        {
            return value.Replace(searchToken, $"|{searchToken}|");
        }

        public static string AddAllTokens(this string value)
        {
            return value.AddTokens("+").AddTokens("-").AddTokens("*").AddTokens("/");
        }
    }
}
