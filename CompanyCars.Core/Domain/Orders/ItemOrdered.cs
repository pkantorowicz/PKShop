using System;

namespace CompanyCars.Core.Domain.Orders
{
    public class ItemOrdered
    {
        public Guid ProductId { get; protected set; }
        public string ProductName { get; protected set; }
    }
}
