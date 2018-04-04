using CompanyCars.Core.Domain.Customers;
using CompanyCars.Core.Domain.Products;
using System.Collections.Generic;

namespace CompanyCars.Core.Domain.Orders
{
    public class OrderDetails
    {
        public Order Order { get; protected set; }
        public Customer Customer { get; protected set; }
        public IEnumerable<Product> Products { get; protected set; }
    }
}
