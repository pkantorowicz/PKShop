using PKShop.Domain.Exceptions;
using PKShop.Domain.DomainClasses.Abstract;
using System;

namespace PKShop.Domain.DomainClasses.Products
{
    public class ProductCode : BaseEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public ProductCode()
        {
        }

        public ProductCode(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new PKShopException(ErrorCodes.InvalidProductCode,
                    "Product code is invalid.");
            }
            if (name.Length > 100)
            {
                throw new PKShopException(ErrorCodes.InvalidProductCode,
                    "Product code cannot be longer than 100 characters");
            }
            Name = name.ToLowerInvariant();
        }

        public static ProductCode Create(Guid id, string name)
            => new ProductCode(id, name);

        public static ProductCode Create(string name)
            => new ProductCode(Guid.NewGuid(), name);
    }
}
