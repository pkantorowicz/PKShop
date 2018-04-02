using System;

namespace CompanyCars.Core.Exceptions
{
    public class CompanyCarsException : Exception
    {
        public string Code { get; }

        public CompanyCarsException()
        {
        }

        public CompanyCarsException(string code)
        {
            Code = code;
        }

        public CompanyCarsException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public CompanyCarsException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public CompanyCarsException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public CompanyCarsException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}