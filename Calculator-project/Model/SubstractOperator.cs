using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.Model
{
    //The substraction operator
    internal class SubstractOperator :Operator
    {
        public override double compute(double x, double y)
        {
            return x - y;
        }

        public override string ToString()
        {
            return ($"[SubtractOperator]");
        }
    }
}
