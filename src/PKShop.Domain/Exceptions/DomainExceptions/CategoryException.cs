using System;

namespace PKShop.Domain.Exceptions.DomainExceptions
{
    public class CategoryException : PKShopException
    {
        public CategoryException() { }

        public CategoryException(string code) : base(code) { }

        public CategoryException(string message, params object[] args) : base(string.Empty, message, args) { }

        public CategoryException(string code, string message, params object[] args) : base(null, code, message, args) { }

        public CategoryException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args) { }

        public CategoryException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) { }
    }
}
