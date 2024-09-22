using Infrastructure.Data.Entities;
using Infrastructure.Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Abstractions
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }
    }
}
