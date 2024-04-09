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
        public override double compute(double x, double y)
        {
            if (y == 0)
            {
                return 0;
            }
            else
            {
                return x / y;
            }
        }

        public override string ToString()
        {
            return ($"[DivideOperator]");
        }
    }
}
