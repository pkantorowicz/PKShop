using CompanyCars.Core.Exceptions;
using CompanyCars.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyCars.Core.Domain.Products
{
    public class Product : BaseEntity, IAggregateRoot
    {
        private ISet<Route> _routes = new HashSet<Route>();
        private ISet<Price> _prices = new HashSet<Price>();

        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public int Seats { get; protected set; }
        public byte[] Img { get; protected set; }
        public int Stock { get; protected set; }
        public decimal Cost { get; protected set; }
        public bool Available { get; protected set; }
        public Category CategoryName { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<Route> Routes
        {
            get { return _routes; }
            set { _routes = new HashSet<Route>(value); }
        }
        public IEnumerable<Price> Prices
        {
            get { return _prices; }
            set { _prices = new HashSet<Price>(value); }
        }

        protected Product(string name, string brand, int seats)
        {
            SetName(name);
            SetBrand(brand);
            SetSeats(seats);
        }

        public void SetCategoryName(string categoryName)
        {
            CategoryName = Category.Create(categoryName);
            UpdatedAt = DateTime.UtcNow;
        }

        public Product(int id, string Name, string Brand, int Seats)
        {

        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CompanyCarsException("ProductName can not be empty");
            }
            if (name.Length > 150)
            {
                throw new CompanyCarsException("ProductName can not be longer than 150 character.");
            }
            if (Name == name)
            {
                return;
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                throw new CompanyCarsException("ProductBrand can not be empty");
            }
            if (brand.Length > 150)
            {
                throw new CompanyCarsException("ProductBrand can not be longer than 150 character.");
            }
            if (Brand == brand)
            {
                return;
            }
            Brand = brand;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetSeats(int seats)
        {
            if (seats < 0)
            {
                throw new CompanyCarsException("Seats must be greater than 0.");
            }

            if (seats > 9)
            {
                throw new CompanyCarsException("You can not provide more than 9 seats");
            }

            if (Seats == seats)
            {
                return;
            }
            Seats = seats;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new CompanyCarsException("Stock must be greater than 0.");
            }
            if (Stock == stock)
            {
                return;
            }
            Stock = stock;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddRoute(Product productId, string name, double startValue, double mileageBefore, double mileageAfter)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if (route != null)
            {
                throw new CompanyCarsException($"Route with name: '{name}' already exists for product with id: {Name}");
            }
            _routes.Add(Route.Create(productId, name, startValue, mileageBefore, mileageAfter));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteRoute(string name)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if (route == null)
            {
                throw new CompanyCarsException($"Route with name: '{name}' for product name: '{Name}' was not found.");
            }
            _routes.Remove(route);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddPrice(Product productId, string name, string currency, decimal value, int vat)
        {
            var price = Prices.SingleOrDefault(x => x.Name == name || x.ProductId == productId);
            if (price != null)
            {
                throw new CompanyCarsException($"Price with name: '{name}' already exists for product with id: '{Name}'");
            }
            _prices.Add(Price.Create(productId, name, currency, value, vat));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeletePrice(Product productId, string name)
        {
            var price = Prices.SingleOrDefault(x => x.Name == name || x.ProductId == productId);
            if (price == null)
            {
                throw new CompanyCarsException($"Price with name: '{name}' for product name: '{Name}' was not found.");
            }
            _prices.Remove(price);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
