using System;

namespace CompanyCars.Core.Domain
{
    public class Address : BaseEntity
    {
        public string Street { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Country { get; protected set; }
        public string ZipCode { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
