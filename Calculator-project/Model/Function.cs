namespace Calculator_project.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq; // Needed for possible future extensions
    using Calculator.Model;

    public class FunctionList
    {
        public int Count;
        public string[] Names;


        // Constructor to initialize the function list
        public FunctionList()
        {
            // Initialize the list
            this.Functions = new List<Function>();
            this.Count = 0;

            // Add predefined functions to the list
            this.AddFunction(new CosineFunction());
            this.AddFunction(new SineFunction());
            this.AddFunction(new TangentFunction());
            this.AddFunction(new AshFunction());

            // adds names here
            this.Names = new string[this.Count];
            this.Names[0] = "cos";
            this.Names[1] = "sin";
            this.Names[2] = "tan";
            this.Names[3] = "ash";
        }

        // Define a list to store functions
        public List<Function> Functions { get; private set; }

        // Method to add a function to the list
        public void AddFunction(Function func)
        {
            this.Functions.Add(func);
            this.Count++;
        }
    }

    /// <summary>
    /// Represents the cosine function.
    /// </summary>
    public class CosineFunction : Function
    {
        public override double Execute(double[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Cosine function requires only one parameter.");
            }

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
            {
                throw new ArgumentException("Sine function requires only one parameter.");
            }

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
            {
                throw new ArgumentException("Tangent function requires only one parameter.");
            }

            return Math.Tan(parameters[0]);
        }

        public override string ToString()
        {
            return "Tangent Function Token";
        }
    }

    public class AshFunction : Function
    {
        public override double Execute(double[] parameters)
        {
            return 69;
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