using CompanyCars.Core.Interfaces;
using System;

namespace CompanyCars.Core.Domain.Countries
{
    public class Country : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
