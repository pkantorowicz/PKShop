using CompanyCars.Core.Interfaces;
using System;

namespace CompanyCars.Core.Domain.Products
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public int Seats { get; protected set; }
        public byte[] Img { get; protected set; }
        public int Quantity { get; protected set; }
        public bool Available { get; protected set; }
        public decimal Mileage { get; protected set; }
        public Route Route { get; protected set; }
        public string CategoryName { get; protected set; }
        public Category Category { get; protected set; }
        public decimal ProductPrice { get; protected set; }
        public string Currency { get; protected set; }
        public Price Price { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Product()
        {
        }

        public Product(int id, string Name, string Brand, int Seats)
        {

        }

    }
}
