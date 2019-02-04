using System;
using PKShop.Domain.DomainClasses.Abstract;

namespace PKShop.Domain.DomainClasses.Products
{
    public class ProductId : IAggregateId
    {
        private const string IdAsStringPrefix = "Product-";

        public Guid Id { get; }

        private ProductId(Guid id)
        {
            Id = id;
        }

        public ProductId(string id)
        {
            Id = Guid.Parse(id.StartsWith(IdAsStringPrefix) ? id.Substring(IdAsStringPrefix.Length) : id);
        }

        public override string ToString()
        {
            return IdAsString();
        }

        public override bool Equals(object obj)
        {
            return obj is ProductId id && Equals(Id, id.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static ProductId NewProductId()
        {
            return new ProductId(Guid.NewGuid());
        }

        public string IdAsString()
        {
            return $"{IdAsStringPrefix}{Id.ToString()}";
        }

        public static bool operator !=(ProductId left, ProductId right)
        {
            return !(left == right);
        }

        public static bool operator ==(ProductId left, ProductId right)
        {
            return Equals(left?.Id, right?.Id);
        }
    }
}