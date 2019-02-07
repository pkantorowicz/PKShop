using System;
using PKShop.Domain.Exceptions.DomainExceptions;
using PKShop.Core.Types;

namespace PKShop.Domain.DomainClasses.Products
{
    public class Category : EntityBase
    {
        public Guid ProductId { get; protected set; }
        public Product Product { get; protected set; }
        public string Name { get; protected set; }

        protected Category()
        {
        }

        public Category(Guid categoryId, Guid productId, Product product, string name)
        {
            Id = categoryId;
            ProductId = productId;
            Product = product;
            SetName(name);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CategoryException(Codes.InvalidProductCategory,
                    "CategoryName can not be empty.");
            }

            if (name.Length > 100)
            {
                throw new CategoryException(Codes.InvalidProductCategory,
                    "CategoryName can not be longer than 100 characters.");
            }

            Name = name;
            SetUpdatedDate();
        }
    }
}
