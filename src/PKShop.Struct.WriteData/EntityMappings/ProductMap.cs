using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PKShop.Domain.DomainClasses.Products;

namespace PKShop.Struct.WriteData.EntityMappings
{    
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnType("int")
                .IsRequired();   

            builder.Property(x => x.Cost)
                .HasColumnType("decimal(15,2)")
                .IsRequired();   
        }
    }
}