using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class CountryException : PKShopException
    {
        public CountryException() { }

        public CountryException(string code) : base(code) { }

        public CountryException(string message, params object[] args) : base(string.Empty, message, args) { }

        public CountryException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public CountryException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public CountryException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
