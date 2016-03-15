using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Enumerations;

namespace Calculator.Core.Models
{
    public class NumberSegment
    {
        public string OriginalValue { get; set; }
        public decimal ParsedValue { get; set; }
        public string ParseType { get; set; } = Enumerations.ParseType.Unknown;

        public NumberSegment(string originalValue)
        {
            OriginalValue = originalValue;
        }
    }
}
