using PKShop.Domain.Exceptions;
using PKShop.Domain.DomainClasses.Abstract;
using System;

namespace PKShop.Domain.DomainClasses.Products
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; protected set; }

        protected Category()
        {
        }

        public Category(Guid id, string name)
        {
            Id = id;
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new PKShopException(Codes.InvalidProductCategory,
                    "CategoryName can not be empty.");
            }
            if (name.Length > 100)
            {
                throw new PKShopException(Codes.InvalidProductCategory,
                    "CategoryName can not be longer than 100 characters.");
            }
            Name = name;
        }

        public static Category Create(string name)
            => Create(Guid.NewGuid(), name);

        public static Category Create(Guid id, string name)
            => new Category(id, name);
    }
}
