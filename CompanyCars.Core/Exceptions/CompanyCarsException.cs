using System;

namespace CompanyCars.Core.Exceptions
{
    public class CompanyCarsException : CustomException
    {
        public CompanyCarsException()
        {
        }

        public CompanyCarsException(string code) : base(code)
        {
        }

        public CompanyCarsException(string message, params object[] args) : base(string.Empty, message, args)
        {
        }

        public CompanyCarsException(string code, string message, params object[] args) : base(null, code, message, args)
        {
        }

        public CompanyCarsException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {
        }

        public CompanyCarsException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }
    }
}