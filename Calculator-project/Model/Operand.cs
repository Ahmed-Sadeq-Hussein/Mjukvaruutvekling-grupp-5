using Calculator.Model;

namespace Calculator_project.Model
{
    class Operand : Token
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