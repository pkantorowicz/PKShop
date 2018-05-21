using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace PKShop.Domain.Factories
{
    public class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>
     where T : DbContext
    {
        public T CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<T>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            var dbContext = (T)Activator.CreateInstance(
                typeof(T),
                builder.Options);
            return dbContext;
        }
    }
}