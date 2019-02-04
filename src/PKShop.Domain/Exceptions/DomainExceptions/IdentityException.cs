using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class IdentityException : PKShopException
    {
        public IdentityException() { }

        public IdentityException(string code) : base(code) { }

        public IdentityException(string message, params object[] args) : base(string.Empty, message, args) { }

        public IdentityException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public IdentityException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public IdentityException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
