using Calculator.Model;
using System;
using System.Linq; // Needed for methods on arrays like Average

namespace Calculator_project.Model
{
    /// Represents a function token that can perform calculations on an array of doubles.
    public class FunctionToken : Token
    {
        // Delegate to hold the function.
        private Func<double[], double> function;

        /// Initializes a new instance of the FunctionToken class with the specified function.
        /// <param name="function">The function this token will represent.</param>
        public FunctionToken(Func<double[], double> function)
        {
            this.function = function;
        }

        /// Executes the function with the provided double array.
        /// <param name="args">Array of doubles as arguments to the function.
        /// <returns>The result of the function.</returns>
        public double Execute(double[] args)
        {
            return function(args);
        }
    }
}
