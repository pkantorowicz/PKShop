using CompanyCars.Core.Domain.Purchases;
using System;
using System.Collections.Generic;

namespace CompanyCars.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        private List<Payment> _payments = new List<Payment>();

        public Guid Id { get; set; }
        public CustomerType Type { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Payment> Payments => _payments.AsReadOnly();

        

        public enum CustomerType
        {
            Person = 1,
            Company = 2
        }
    }
}
