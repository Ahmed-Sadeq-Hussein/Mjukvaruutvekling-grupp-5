using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.Model
{
    // The exponential operator
    internal class ExponentiateOperator : Operand
    {
        public override double compute(double x, double y)
        {
            return Math.Pow (x , y);
        }

        public override string ToString()
        {
            return ($"[ExponentiateOperator]");
        }
    }
}
