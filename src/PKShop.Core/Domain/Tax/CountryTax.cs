using PKShop.Core.Domain.Countries;
using PKShop.Core.Exceptions;
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

        protected CountryTax()
        {         
        }

        public CountryTax(Guid id, Country country, decimal percentage, TaxType type)
        {
            Id = id;
            Country = country;
            Percentage = percentage;
            Type = type;
        }

        public void SetPercentage(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new PKShopException(ErrorCodes.InvalidTaxPercentage,
                    "Tax can not be lower than 0 and greather than 100.");
            }
            Percentage = percentage;
        }

        public static CountryTax Create(Guid id, Country country, decimal percentage, TaxType type)
            => new CountryTax(id, country, percentage, type);
        
        public static CountryTax Create(Country country, decimal percentage, TaxType type)
            => Create(Guid.NewGuid(), country, percentage, type);

        public enum TaxType
        {
            Business,
            Customer
        }
    }
}
