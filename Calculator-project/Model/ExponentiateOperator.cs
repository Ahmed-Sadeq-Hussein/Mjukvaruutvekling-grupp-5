﻿namespace Calculator_project.Model
{
    using System;
    using Calculator_project.Exceptions;

    // The exponential operator

    /// <summary>
    /// implementation of the exponetial operator. pretty simple. good job.
    /// </summary>
    public class ExponentiateOperator : Operator
    {
        public override double Compute(double x, double y)
        {
            if (y % 1 != 0 && x < 0)
            {
                throw new ResultsInImaginaryNumberException();
            }

            return Math.Pow(x, y);
        }

        public override string ToString()
        {
            return $"[ExponentiateOperator]";
        }
    }
}
