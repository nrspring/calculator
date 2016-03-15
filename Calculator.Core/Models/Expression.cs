using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public class Expression
    {
        public string ExpressionType { get; set; }
        public string OriginalValue { get; set; }
        public NumberSegment SegmentValue { get; set; }
    }
}
