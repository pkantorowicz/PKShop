using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class ProductException : PKShopException
    {
        public ProductException() { }

        public ProductException(string code) : base(code) { }

        public ProductException(string message, params object[] args) : base(string.Empty, message, args) { }

        public ProductException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public ProductException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public ProductException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
