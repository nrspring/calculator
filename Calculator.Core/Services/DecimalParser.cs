using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Enumerations;
using Calculator.Core.Interfaces;

namespace Calculator.Core.Services
{
    public class DecimalParser : INumberParser
    {
        public Models.NumberSegment Parse(string value)
        {
            var returnValue = new Models.NumberSegment(value);

            decimal parsedValue = 0;
            if (Decimal.TryParse(value, out parsedValue))
            {
                returnValue.ParsedValue = parsedValue;
                returnValue.ParseType = ParseType.Decimal;
            }

            return returnValue;
        }
    }
}
