using System;

namespace Calculator_project.Model
{
    // The division operator 
    public class DivideOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            if (y == 0)
<<<<<<< HEAD
            {
                return 0;
            }
            else
            {
                return x / y;
            }
=======
                throw new DivideByZeroException();

            return x / y;
>>>>>>> origin/main
        }

        public override string ToString()
        {
            return ($"[DivideOperator]");
        }
    }
}
