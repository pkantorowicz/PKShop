namespace CompanyCars.Core.Domain.Customers
{
    public class Address 
    {
        public string Street { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Country { get; protected set; }
        public string ZipCode { get; protected set; }
    }
}
