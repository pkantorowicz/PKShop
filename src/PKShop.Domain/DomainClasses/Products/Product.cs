using PKShop.Domain.Exceptions;
using PKShop.Domain.DomainClasses.Abstract;
using System;
using System.Collections.Generic;

namespace PKShop.Domain.DomainClasses.Products
{
    public class Product : BaseEntity
    {
        private List<Return> _returns = new List<Return>();

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public bool Active { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal Cost { get; protected set; }
        public ProductCode Code { get; protected set; }
        public Category Category { get; protected set; }
        public IEnumerable<Return> Returns => _returns.AsReadOnly();

        protected Product()
        {
        }

        public Product(Guid id, string name, int quantity, decimal cost)
        {
            Id = id;
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
            UpdatedAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
        }

        public Product(Guid id, string name, int quantity, decimal cost,
            ProductCode code, Category category)
        {
            Id = id;
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
            Code = code;
            Category = category;
            UpdatedAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new PKShopException(ErrorCodes.InvalidProductName,
                    "CategoryName can not be empty.");
            }
            if (name.Length > 100)
            {
                throw new PKShopException(ErrorCodes.InvalidProductName,
                    "CategoryName can not be longer than 100 characters.");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity > 1000000 || quantity < 0)
            {
                throw new PKShopException(ErrorCodes.InvalidProductQuantity,
                    "Quantity can not be greater than 1 000 000 and lower than 0.");
            }
            Quantity = quantity;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetCost(decimal cost)
        {
            if (cost > 1000000 || cost < 0)
            {
                throw new PKShopException(ErrorCodes.InvalidProductCost,
                    "Cost can not be greater than 1 000 000 and lower than 0.");
            }
            Cost = cost;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Product Create(string name, int quantity, decimal cost, ProductCode code, Category category)
            => Create(Guid.NewGuid(), name, quantity, cost, code, category);

        public static Product Create(Guid id, string name, int quantity, decimal cost,
            ProductCode code, Category category)
            => new Product(id, name, quantity, cost, code, category);
    }
}
