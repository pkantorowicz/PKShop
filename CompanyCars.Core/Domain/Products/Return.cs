using CompanyCars.Core.Domain.Customers;
using System;

namespace CompanyCars.Core.Domain.Products
{
    public class Return
    {
        public Product Product { get; protected set; }
        public Customer Customer { get; protected set; }
        public ReturnReason Reason { get; protected set; }
        public DateTime Created { get; protected set; }
        public string Note { get; protected set; }

        public enum ReturnReason
        {
            Faulty,
            NoReason
        }
    }
}
