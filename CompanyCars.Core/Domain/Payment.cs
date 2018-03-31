using System;

namespace CompanyCars.Core.Domain
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; protected set; }
        public PaymentType Type { get; protected set; }
        public PaymentMethod Method { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public decimal Value { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreateAt { get; protected set; }
    }
}
