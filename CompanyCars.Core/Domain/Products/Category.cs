using CompanyCars.Core.Exceptions;

namespace CompanyCars.Core.Domain.Products
{
    public class Category
    {
        public Product ProductId { get; set; }
        public string Name { get; protected set; }

        protected Category()
        {
        }

        public Category(Product productId, string name)
        {
            ProductId = productId;
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CompanyCarsException("CategoryName can not be empty.");
            }
            if (name.Length > 100)
            {
                throw new CompanyCarsException("CategoryName can not be longer than 100 characters.");
            }
            Name = name;
        }

        public static Category Create(Product productId, string name)
            => new Category(productId, name);
    }
}
