using System;
using System.Runtime.Serialization;

namespace Calculator_project.Exceptions
{
    internal class ResultsInImaginaryNumberException : Exception
    {
        public ResultsInImaginaryNumberException()
        {
        }

        public ResultsInImaginaryNumberException(string? message) : base(message)
        {
        }

        public ResultsInImaginaryNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ResultsInImaginaryNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Expression resulted in an imaginary number";
    }
}
