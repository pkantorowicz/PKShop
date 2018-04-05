using System;

namespace PKShop.Core.Domain.Purchases
{
    public class PurchasedOrder
    {
        public Guid PurchaseId { get; protected set; }
        public Guid OrderId { get; protected set; }
        public int Quantity { get; protected set; }
        public int TotalCost { get; protected set; }
        public int TotalTax { get; protected set; }
    }
}
