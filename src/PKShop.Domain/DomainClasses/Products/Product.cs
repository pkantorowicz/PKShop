using PKShop.Domain.Exceptions;
using PKShop.Domain.DomainClasses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using PKShop.Domain.Exceptions.DomainExceptions;

namespace PKShop.Domain.DomainClasses.Products
{
    public class Product : AggregateBase<ProductId>
    {
        private ISet<Return> _returns = new HashSet<Return>();
        private ISet<Category> _categories = new HashSet<Category>();

        public string Name { get; protected set; }
        public bool Active { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal Cost { get; protected set; }
        public ProductCode Code { get; protected set; }
        public Category Category { get; protected set; }

        public IEnumerable<Category> Categories
        {
            get => _categories;
            set => _categories = new HashSet<Category>(value);
        }

        public IEnumerable<Return> Returns
        {
            get => _returns;
            set => _returns = new HashSet<Return>(value);
        }

        protected Product()
        {
        }

        public Product(ProductId productId, string name, int quantity, decimal cost)
        {
            Id = productId;
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
            CreatedAt = DateTime.UtcNow;
        }

        public Product(ProductId productId, string name, int quantity, decimal cost, ProductCode code)
        {
            Id = productId;
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
            Code = code;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ProductException(Codes.InvalidProductName,
                    "CategoryName can not be empty.");
            }

            if (name.Length > 100)
            {
                throw new ProductException(Codes.InvalidProductName,
                    "CategoryName can not be longer than 100 characters.");
            }

            Name = name;
            SetUpdatedDate();
        }

        public void SetQuantity(int quantity)
        {
            if (quantity > 1000000 || quantity < 0)
            {
                throw new ProductException(Codes.InvalidProductQuantity,
                    "Quantity can not be greater than 1 000 000 and lower than 0.");
            }

            Quantity = quantity;
            SetUpdatedDate();
        }

        public void SetCost(decimal cost)
        {
            if (cost > 1000000 || cost < 0)
            {
                throw new ProductException(Codes.InvalidProductCost,
                    "Cost can not be greater than 1 000 000 and lower than 0.");
            }

            Cost = cost;
            SetUpdatedDate();
        }

        public void SetProductCode(ProductCode productCode)
        {
            Code = productCode ?? throw new ProductException(Codes.InvalidProductCode,
                       "Product code can not be empty.");
            SetUpdatedDate();
        }

        public void AddCategory(Category category)
        {
            var checkIfCategoryExists = GetCategory(category.Name);

            if (checkIfCategoryExists != null)
            {
                throw new ProductException(Codes.CategoryAlreadyExists,
                    $"Product already assigned to this category {category.Name}.");
            }

            _categories.Add(category);
            SetUpdatedDate();
        }

        public void RemoveCategory(string categoryName)
        {
            var category = GetCategoryAndHandle(categoryName);
            _categories.Remove(category);
            SetUpdatedDate();
        }

        public Category GetCategoryAndHandle(string categoryName)
        {
            var category = GetCategory(categoryName);

            if (category == null)
            {
                throw new ProductException(Codes.CategoryNotFound,
                    $"Not found category with name: {categoryName}.");
            }

            return category;
        }

        public Category GetCategory(string categoryName)
            => _categories.SingleOrDefault(x => x.Name == categoryName);
    }
}