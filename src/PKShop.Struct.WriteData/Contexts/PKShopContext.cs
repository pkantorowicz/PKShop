using Microsoft.EntityFrameworkCore;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Struct.WriteData.EntityMappings;

namespace PKShop.Struct.WriteData.Contexts
{
    public class PKShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PKShopContext(DbContextOptions<PKShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());                     
            base.OnModelCreating(modelBuilder);
        }
    }
}