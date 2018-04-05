using System;

namespace PKShop.Core.Domain.Carts
{
    public class CartItem
    {
        public Guid CartId { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public int Quantity { get; protected set; }
        public Guid ProductId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public decimal Cost { get; protected set; }
        public decimal TotalCost => Quantity * Cost;
        public decimal Tax { get; set; }
    }
}
