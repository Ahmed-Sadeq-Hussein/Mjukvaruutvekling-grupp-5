namespace Calculator_project.Model
{
    // The sum operator
    internal class SumOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            return x + y;
        }

        public override string ToString()
        {
            return ($"[SumOperator]");
        }
    }
}