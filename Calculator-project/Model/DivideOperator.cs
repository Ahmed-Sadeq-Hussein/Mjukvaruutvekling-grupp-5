using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.Model
{
    // The division operator 
    internal class DivideOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            return x / y;
        }

        public override string ToString()
        {
            return ($"[DivideOperator]");
        }
    }
}
