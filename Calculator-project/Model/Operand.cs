using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.Model
{
    abstract class Operand : Token
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