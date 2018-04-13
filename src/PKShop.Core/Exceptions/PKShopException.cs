using System;

namespace PKShop.Core.Exceptions
{
    public class PKShopException : Exception
    {
        public string Code { get; }

        public PKShopException()
        {
        }

        public PKShopException(string code)
        {
            Code = code;
        }

        public PKShopException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public PKShopException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public PKShopException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public PKShopException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}