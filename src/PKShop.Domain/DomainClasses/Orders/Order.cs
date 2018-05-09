using PKShop.Domain.DomainClasses.Abstract;
using System;
using System.Collections.Generic;

namespace PKShop.Domain.DomainClasses.Orders
{
    public class Order : BaseEntity
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

        protected Order()
        {      
        }

        public Order(Guid id, Guid customerId, long number, decimal totalTax, decimal totalAmount,
            OrderStatus status, Address shippingTo)
        {
            Id = id;
            CustomerId = customerId;
            Number = number;
            TotalTax = totalTax;
            TotalAmount = totalAmount;
            status = OrderStatus.Created;
            ShippingToAddress = shippingTo;
            CreatedAt = DateTime.UtcNow;
        }

        public enum OrderStatus
        {
            Created = 0,
            Completed = 1,
            Canceled = 2
        }
    }
}
