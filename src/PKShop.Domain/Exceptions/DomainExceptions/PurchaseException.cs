using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class PurchaseException : PKShopException
    {
        public PurchaseException() { }

        public PurchaseException(string code) : base(code) { }

        public PurchaseException(string message, params object[] args) : base(string.Empty, message, args) { }

        public PurchaseException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public PurchaseException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public PurchaseException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
