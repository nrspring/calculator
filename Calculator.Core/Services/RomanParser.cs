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
    public class RomanParser : INumberParser
    {
        public Models.NumberSegment Parse(string value)
        {
            var returnValue = new Models.NumberSegment(value);

            if (value.IsValidRomanNumeral())
            {
                try
                {
                    returnValue.ParsedValue = value.GetDecimalFromRomanNumeral();
                    returnValue.ParseType = ParseType.Roman;
                }
                catch (Exception)
                {

                }
            }

            return returnValue;
        }
    }
}
