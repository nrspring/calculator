using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public class ExpressionResult
    {
        public decimal TotalSum { get; set; }
        public string OriginalValue { get; set; }
        public bool IsValid { get; set; }
        public List<Expression> Expressions { get; set; } = new List<Expression>();
    }
}
