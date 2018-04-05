using PKShop.Core.Exceptions;
using PKShop.Core.Interfaces;
using System;

namespace PKShop.Core.Domain.Countries
{
    public class Country : IAggregateRoot
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
                throw new PKShopException(ErrorCodes.InvalidCountry,
                    "Username is invalid.");
            }
            if (name.Length > 50)
            {
                throw new PKShopException(ErrorCodes.InvalidCountry,
                    "Usename cannot be longer than 50 characters");
            }
            Name = name.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public Country Create(string name)
            => Create(Guid.NewGuid(), name);

        public Country Create(Guid id, string name)
            => new Country(id, name);
    }
}
