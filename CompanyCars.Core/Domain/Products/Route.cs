using System;

namespace CompanyCars.Core.Domain.Products
{
    public class Route 
    {
        public int ProductId { get; protected set; }
        public int CustomerId { get; protected set; }
        public double Kilometer { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
