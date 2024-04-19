using Calculator.Model;

namespace Calculator_project.Model
{
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