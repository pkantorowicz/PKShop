using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class TaxException : PKShopException
    {
        public TaxException() { }

        public TaxException(string code) : base(code) { }

        public TaxException(string message, params object[] args) : base(string.Empty, message, args) { }

        public TaxException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public TaxException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public TaxException(Exception innerException, string code, string message, params object[] args)
                : base(string.Format(message, args), innerException) { }
    }
}


