using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class OrderException : PKShopException
    {
        public OrderException() { }

        public OrderException(string code) : base(code) { }

        public OrderException(string message, params object[] args) : base(string.Empty, message, args) { }

        public OrderException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public OrderException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public OrderException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
