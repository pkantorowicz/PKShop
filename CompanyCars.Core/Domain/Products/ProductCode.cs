using CompanyCars.Core.Interfaces;
using System;

namespace CompanyCars.Core.Domain.Products
{
    public class ProductCode : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
