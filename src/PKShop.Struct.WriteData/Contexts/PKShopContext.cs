using Microsoft.EntityFrameworkCore;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Struct.WriteData.EntityMappings;

namespace PKShop.Struct.WriteData.Context
{
    public class PKShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());                     
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();
            
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
    }
}