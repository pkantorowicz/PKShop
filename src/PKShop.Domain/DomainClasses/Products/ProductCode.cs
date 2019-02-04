using PKShop.Domain.DomainClasses.Abstract;
using System;

namespace PKShop.Domain.DomainClasses.Products
{
    public class ProductCode : ValueObject<ProductCode>
    {
        public string Code { get; protected set; }

        protected ProductCode()
        {
        }

        public ProductCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length > 100)
            {
                throw new ArgumentException("Product code can not be empty or longer than 100 characters.",
                    nameof(code));
            }

            Code = code;
        }

        public static ProductCode Create(string name)
            => new ProductCode(name);

        protected override bool EqualsCore(ProductCode other)
            => Code.Equals(other.Code);

        protected override int GetHashCodeCore() => Code.GetHashCode();
    }
}
