using CompanyCars.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CompanyCars.Core.Domain.Products
{
    public class Product : IAggregateRoot
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
    }
}
