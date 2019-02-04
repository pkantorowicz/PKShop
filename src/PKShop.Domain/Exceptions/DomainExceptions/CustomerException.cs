using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class CustomerException : PKShopException
    {
        public CustomerException() { }

        public CustomerException(string code) : base(code) { }

        public CustomerException(string message, params object[] args) : base(string.Empty, message, args) { }

        public CustomerException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public CustomerException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public CustomerException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
