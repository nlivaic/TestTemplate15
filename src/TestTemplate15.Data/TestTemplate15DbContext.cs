using MassTransit;
using Microsoft.EntityFrameworkCore;
using TestTemplate15.Core.Entities;

namespace TestTemplate15.Data
{
    public class TestTemplate15DbContext : DbContext
    {
        public TestTemplate15DbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
