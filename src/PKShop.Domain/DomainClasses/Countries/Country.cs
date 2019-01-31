using PKShop.Domain.Exceptions;
using PKShop.Domain.DomainClasses.Abstract;
using System;

namespace PKShop.Domain.DomainClasses.Countries
{
    public class Country : BaseEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Country()
        {
        }

        public Country(Guid id, string name)
        {
            Id = id;
            SetName(name);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new PKShopException(Codes.InvalidCountry,
                    "Username is invalid.");
            }
            if (name.Length > 100)
            {
                throw new PKShopException(Codes.InvalidCountry,
                    "Usename can not be longer than 100 characters");
            }
            Name = name.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public Country Create(Guid id, string name)
            => new Country(id, name);

        public Country Create(string name)
            => Create(Guid.NewGuid(), name);
    }
}
