using System;
using PKShop.Core.Commands;

namespace PKShop.Domain.Commands.Products
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; protected set; }
        public bool Active { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal Cost { get; protected set; }
    }
}