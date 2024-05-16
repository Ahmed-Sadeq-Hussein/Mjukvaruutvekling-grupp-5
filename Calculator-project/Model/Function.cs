using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq; // Needed for possible future extensions




namespace Calculator_project.Model
{
    public class FunctionList
    {
        // Define a list to store functions
        public List<Function> Functions { get; private set; }
        public int count;
        public string[] names;

        // Constructor to initialize the function list
        public FunctionList()
        {
            // Initialize the list
            Functions = new List<Function>();
            count = 0;

            // Add predefined functions to the list
            AddFunction(new CosineFunction());
            AddFunction(new SineFunction());
            AddFunction(new TangentFunction());
            AddFunction(new AshFunction());
            // adds names here
            names = new string[count];
            names[0] = "cos";
            names[1] = "sin";
            names[2] = "tan";
            names[3] = "ash";
        }

        // Method to add a function to the list
        public void AddFunction(Function func)
        {
            Functions.Add(func);
            count++;
            
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
    /// 
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