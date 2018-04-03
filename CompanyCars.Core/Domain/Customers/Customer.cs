using System;

namespace CompanyCars.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public CustomerType Type { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public enum CustomerType
        {
            Person = 1,
            Company = 2
        }
    }
}
