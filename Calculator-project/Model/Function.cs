using Calculator.Model;
using System;
using System.Linq; // Needed for possible future extensions




namespace Calculator_project.Model
{
    /// <summary>
    /// Represents the cosine function.
    /// </summary>
    public class CosineFunction : Function
    {
        public override double Execute(double[] parameters)
        {
            if (parameters.Length != 1)
                throw new ArgumentException("Cosine function requires only one parameter.");
            return Math.Cos(parameters[0]);
        }

        public override string ToString()
        {
            return "Cosine Function Token";
        }
    }

    /// <summary>
    /// Represents the sine function.
    /// </summary>
    public class SineFunction : Function
    {
        public override double Execute(double[] parameters)
        {
            if (parameters.Length != 1)
                throw new ArgumentException("Sine function requires only one parameter.");
            return Math.Sin(parameters[0]);
        }

        public override string ToString()
        {
            return "Sine Function Token";
        }
    }

    /// <summary>
    /// Represents the tangent function.
    /// </summary>
    public class TangentFunction : Function
    {
        public override double Execute(double[] parameters)
        {
            if (parameters.Length != 1)
                throw new ArgumentException("Tangent function requires only one parameter.");
            return Math.Tan(parameters[0]);
        }

        public override string ToString()
        {
            return "Tangent Function Token";
        }
    }

    /// <summary>
    /// A token for mathematical functions. Enables the use of various mathematical operations that require multiple parameters.
    /// </summary>
    public abstract class Function : Token
    {
        /// <summary>
        /// Executes the function with the given parameters.
        /// </summary>
        /// <param name="parameters">An array of doubles as parameters for the function.</param>
        /// <returns>The result of the function as a double.</returns>
        public abstract double Execute(double[] parameters);
    }
}