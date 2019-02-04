using PKShop.Domain.DomainClasses.Abstract;
using System;
using PKShop.Domain.Exceptions.DomainExceptions;

namespace PKShop.Domain.DomainClasses.Products
{
    public class Category : EntityBase
    {
        public ProductId ProductId { get; private set; }
        public Product Product { get; private set; }
        public string Name { get; private set; }

        protected Category()
        {
        }

        public Category(Guid categoryId, ProductId productId, Product product, string name)
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
