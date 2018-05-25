using Microsoft.EntityFrameworkCore;
using PKShop.Core.Events;
using PKShop.Struct.WriteData.EntityMappings;

namespace PKShop.Struct.WriteData.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}