namespace Calculator_project.Model
{
    using Calculator.Model;

    /// <summary>
    /// the token for operatos . Good for abstraction and polymorphism.
    /// </summary>
    public class Operand : Token
    {
        // The value of the operand
        public double Value;

        public Operand()
        {
        }

        public Operand(double value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}