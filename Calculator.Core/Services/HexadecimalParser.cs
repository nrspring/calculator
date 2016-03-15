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
    public class HexadecimalParser : INumberParser
    {
        public Models.NumberSegment Parse(string value)
        {
            var returnValue = new Models.NumberSegment(value);

            if (value.IsMarkedAsHexadecimal())
            {
                try
                {
                    returnValue.ParsedValue = value.GetDecimalFromHexadecimal();
                    returnValue.ParseType = ParseType.Hexadecimal;
                }
                catch (Exception)
                {

                }
            }

            return returnValue;
        }
    }
}
