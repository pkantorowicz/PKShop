using System;

namespace CompanyCars.Core.Domain
{
    public class Stocks : BaseEntity
    {
        public int CarId { get; protected set; }
        public string CarName { get; protected set; }
        public int Quantity { get; protected set; }
        public int OnRent { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
