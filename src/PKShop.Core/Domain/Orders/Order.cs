using PKShop.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace PKShop.Core.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        private List<OrderItem> _orderItems = new List<OrderItem>();

        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public long Number { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; } 
        public Address ShippingToAddress { get; protected set; }
        public decimal TotalAmount { get; protected set; }
        public decimal TotalTax { get; protected set; }
        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public OrderStatus Status { get; protected set; }

        public enum OrderStatus
        {
            Created = 0,
            Completed = 1,
            Canceled = 2
        }
    }
}
