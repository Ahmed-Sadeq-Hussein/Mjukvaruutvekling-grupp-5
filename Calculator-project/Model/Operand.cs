using Calculator.Model;

namespace Calculator_project.Model
{
    /// <summary>
    /// the token for operatos . Good for abstraction and polymorphism
    /// </summary>
    public class Operand : Token
    {
        //The value of the operand
        public double value;

        public Operand() { }
        public Operand(double value) { this.value = value; }

        public override string ToString()
        {
            return $"{this.value}";
        }
    }
}