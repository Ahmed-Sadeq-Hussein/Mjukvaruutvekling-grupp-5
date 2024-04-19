namespace Calculator_project.Model
{
    //The multiplication operator
    public class MultiplyOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            return x * y;
        }

        public override string ToString()
        {
            return ($"[MultiplyOperator]");
        }
    }
}
