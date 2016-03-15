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
    public class BinaryParser : INumberParser
    {
        public Models.NumberSegment Parse(string value)
        {
            var returnValue = new Models.NumberSegment(value);

            if (value.IsMarkedAsBinary())
            {
                try
                {
                    returnValue.ParsedValue = value.GetDecimalFromBinary();
                    returnValue.ParseType = ParseType.Binary;
                }
                catch (Exception)
                {

                }
            }

            return returnValue;
        }
    }
}
