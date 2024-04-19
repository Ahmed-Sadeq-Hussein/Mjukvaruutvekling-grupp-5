using System;

namespace Calculator_project.Model
{
    // The division operator 
    /// <summary>
    /// implementation of the divide operator. Good implementations with divide error 
    /// perfect.
    /// </summary>
    public class DivideOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();

            return x / y;
        }

        public override string ToString()
        {
            return ($"[DivideOperator]");
        }
    }
}
