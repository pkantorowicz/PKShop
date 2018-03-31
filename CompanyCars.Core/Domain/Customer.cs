using System;

namespace CompanyCars.Core.Domain
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
