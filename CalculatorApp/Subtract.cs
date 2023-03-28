using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Subtract : ICalculate
    {
        public double InputOne { get; set; }
        public double InputTwo { get; set; }

        public double Calculate()
        {
            return InputOne - InputTwo;
        }
    }
}
