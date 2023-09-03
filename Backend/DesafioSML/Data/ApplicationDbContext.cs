using DesafioSML.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace DesafioSML.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedingData.Seed(modelBuilder);
        }
    }
}
