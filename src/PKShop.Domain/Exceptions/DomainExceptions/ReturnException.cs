using System;
namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class ReturnException : PKShopException
    {
        public ReturnException() { }

        public ReturnException(string code) : base(code) { }

        public ReturnException(string message, params object[] args) : base(string.Empty, message, args) { }

        public ReturnException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public ReturnException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public ReturnException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
