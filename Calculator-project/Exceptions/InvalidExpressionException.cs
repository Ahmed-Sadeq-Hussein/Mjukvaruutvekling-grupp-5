﻿namespace Calculator_project.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException()
        {
        }

        public InvalidExpressionException(string? message)
            : base(message)
        {
        }

        public InvalidExpressionException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected InvalidExpressionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override string Message => $"Invalid expression";
    }
}
