using System;
using System.Runtime.Serialization;

namespace Calculator_project.Exceptions
{
    internal class InvalidExpressionException : Exception
    {
        public InvalidExpressionException()
        {
        }

        public InvalidExpressionException(string? message) : base(message)
        {
        }

        public InvalidExpressionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Invalid expression";
    }
}
