using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class DependencyInsertion
    {
        private Add add;
        private Percentage percentage;
        private Divide divide;
        private Multiply multiply;
        private Subtract subtract;
        public ICalculate GetObject(string Operator)
        {
            switch(Operator)
            {
                case "/":
                    if(divide!=null)
                        return divide;
                    else
                        divide = new Divide();
                        return divide;

                case "+":
                    if (add != null)
                        return add;
                    else
                        add = new Add();
                    return add;

                case "-":
                    if (subtract != null)
                        return subtract;
                    else
                        subtract = new Subtract();
                    return subtract;

                case "X":
                    if (multiply != null)
                        return multiply;
                    else
                        multiply = new Multiply();
                    return multiply;
                case "%":
                    if (percentage != null)
                        return percentage;
                    else
                        percentage = new Percentage();
                    return percentage;
                default: return null;
            }
        }
    }
}
