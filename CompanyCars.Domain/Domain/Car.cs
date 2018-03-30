using System;

namespace CompanyCars.Core.Domain
{
    public class Car : BaseEntity
    {
        public Guid SerialNumber { get; protected set; }
        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public int Seats { get; protected set; }
        public Route Route { get; protected set; }
        public Category Category { get; protected set; }
        public Price Price { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
