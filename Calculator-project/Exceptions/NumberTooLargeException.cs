using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_project.Exceptions
{
    internal class NumberTooLargeException : Exception
    {
        public NumberTooLargeException()
        {
        }

        public NumberTooLargeException(string? message) : base(message)
        {
        }

        public NumberTooLargeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NumberTooLargeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Expression resulted in a too large number";
    }
}
