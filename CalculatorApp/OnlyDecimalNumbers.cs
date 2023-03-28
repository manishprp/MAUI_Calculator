using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class OnlyDecimalNumbers
    {
        public bool CheckForNumber(string input)
        {
            bool containsDigits = input.Any(char.IsDigit); 
            return containsDigits;
        }
    }
}
