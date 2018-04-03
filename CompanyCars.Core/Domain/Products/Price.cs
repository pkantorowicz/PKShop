using CompanyCars.Core.Exceptions;
using System;

namespace CompanyCars.Core.Domain.Products
{
    public class Price : BaseEntity
    {
        public Product ProductId { get; protected set; }
        public string Name { get; protected set; }
        public string Currency { get; protected set; }
        public decimal Value { get; protected set; }
        public int Vat { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Price()
        {
        }

        public Price(Product productId, string name, string currency, decimal value, int vat)
        {
            ProductId = productId;
            SetName(name);
            SetCurrency(currency);
            SetValue(value);
            SetVat(vat);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CompanyCarsException("PriceName can not be empty");
            }
            if (name.Length > 100)
            {
                throw new CompanyCarsException("PriceName can not be longer than 100 character.");
            }
            if (Name == name)
            {
                return;
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetCurrency(string currency)
        {
            if (string.IsNullOrEmpty(currency))
            {
                throw new CompanyCarsException("Currency can not be empty");
            }
            if (currency.Length > 20)
            {
                throw new CompanyCarsException("Currency can not be longer than 20 character.");
            }
            if (Currency == currency)
            {
                return;
            }
            Currency = currency;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetVat(int vat)
        {
            if (vat > 23)
            {
                throw new CompanyCarsException("Vat can not be greather than 23%");
            }
            if (vat < 8)
            {
                throw new CompanyCarsException("Vat can not be smaller than 5%.");
            }
            if (Vat == vat)
            {
                return;
            }
            Vat = vat;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetValue(decimal value)
        {
            if (value > 100000)
            {
                throw new CompanyCarsException("PriceValue can not be grather than 100 000.");
            }
            if (value < 0)
            {
                throw new CompanyCarsException("PriceValue can not be smaller than 0.");
            }
            if (Value == value)
            {
                return;
            }
            Value = value;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Price Create(Product productId, string name, string currency, decimal value, int vat)
            => new Price(productId, name, currency, value, vat);
    }
}
