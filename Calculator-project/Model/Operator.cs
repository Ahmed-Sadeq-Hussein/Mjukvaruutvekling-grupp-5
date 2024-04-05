using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.Model
{
    abstract class Operator : Token
    {
        /// <summary>
        /// Computes the value of two doubles, no specified operation 
        /// </summary>
        /// <param name="x"> The left operand </param>
        /// <param name="y"> The right operand </param>
        /// <returns> The value of </returns>
        public abstract double compute(double x, double y);
    }
}
