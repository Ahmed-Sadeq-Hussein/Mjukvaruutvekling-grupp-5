using System;

namespace Calculator_project.Model
{
    // The exponential operator
    internal class ExponentiateOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public override string ToString()
        {
            return ($"[ExponentiateOperator]");
        }
    }
}
