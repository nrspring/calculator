﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Interfaces
{
    public interface INumberParser
    {
        Models.NumberSegment Parse(string value);
    }
}
