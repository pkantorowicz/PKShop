using CompanyCars.Core.Exceptions;

namespace CompanyCars.Core.Domain.Products
{
    public class Category
    {       
        public string Name { get; protected set; }

        protected Category()
        {
        }

        public Category(string name)
        {
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

        public static Category Create(string name)
            => new Category(name);
    }
}
