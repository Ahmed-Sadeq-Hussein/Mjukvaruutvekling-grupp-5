namespace Calculator_project.Model
{
    //The substraction operator
    internal class SubtractOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            return x - y;
        }

        public override string ToString()
        {
            return ($"[SubtractOperator]");
        }
    }
}
