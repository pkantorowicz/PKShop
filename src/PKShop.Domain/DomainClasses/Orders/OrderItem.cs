using System;
using PKShop.Domain.DomainClasses.Products;

namespace PKShop.Domain.DomainClasses.Orders
{
    public class OrderItem 
    {
        public Guid ProductId { get; protected set; }
        public Guid OrderId { get; protected set; }
        public string Name { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal Cost { get; protected set; }

        protected OrderItem()
        {         
        }

        public OrderItem(Product product, Guid orderId)
        {
            OrderId = orderId;
            ProductId = product.Id;
            Name = product.Name;
            Quantity = product.Quantity;
            Cost = product.Cost;
        }
    }
}
