using PKShop.Core.Domain.Countries;
using PKShop.Core.Interfaces;
using System;

namespace PKShop.Core.Domain.Tax
{
    public class CountryTax : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public Country Country { get; protected set; }
        public decimal Percentage { get; protected set; }
        public TaxType Type { get; protected set; }

        public enum TaxType
        {
            Business,
            Customer
        }
    }
}
