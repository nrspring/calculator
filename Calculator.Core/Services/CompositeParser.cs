using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Enumerations;
using Calculator.Core.Interfaces;

namespace Calculator.Core.Services
{
    public class CompositeParser : ICompositeParser
    {
        private List<Interfaces.INumberParser> Parsers { get; set; } = new List<INumberParser>();

        public CompositeParser()
        {
            PopulateParsers();
        }

        public Models.NumberSegment GetSegmentFromValue(string value)
        {
            foreach (var currentParser in Parsers)
            {
                var result = currentParser.Parse(value);
                if(result.ParseType != ParseType.Unknown) return result;
            }

            return new Models.NumberSegment(value);
        }

        private void PopulateParsers()
        {
            Parsers.Add(new DecimalParser());
            Parsers.Add(new BinaryParser());
            Parsers.Add(new HexadecimalParser());
            Parsers.Add(new RomanParser());
        }
    }
}
