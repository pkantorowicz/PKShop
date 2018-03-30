using System;

namespace CompanyCars.Core.Domain
{
    public class Price : BaseEntity
    {
        public string Name { get; protected set; }
        public string Currency { get; protected set; }
        public decimal Value { get; protected set; }
        public int Vat { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
