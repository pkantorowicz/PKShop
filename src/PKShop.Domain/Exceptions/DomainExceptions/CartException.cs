using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class CartException : PKShopException
    {
        public CartException() { }

        public CartException(string code) : base(code) { }

        public CartException(string message, params object[] args) : base(string.Empty, message, args) { }

        public CartException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public CartException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public CartException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
