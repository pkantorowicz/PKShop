using CompanyCars.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyCars.Core.Domain.Purchases
{
    public class Purchase : IAggregateRoot
    {
        private List<PurchasedOrder> _purchasedOrders = new List<PurchasedOrder>();

        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public PurchaseMethod PaymentMethod { get; protected set; }
        public IEnumerable<PurchasedOrder> PurchasedOrder => _purchasedOrders.AsReadOnly();
        public decimal TotalAmount => _purchasedOrders.Sum(x => x.TotalCost);
        public decimal TotalTaz => _purchasedOrders.Sum(x => x.TotalTax);
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreateAt { get; protected set; }

        public enum PurchaseMethod
        {
            CreditCard = 0,
            Cash = 1,

        }
    }
}
