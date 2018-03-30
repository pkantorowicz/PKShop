using System;

namespace CompanyCars.Core.Domain
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public decimal Price { get; set; }
        public Price Price { get; set; }

    }
}
