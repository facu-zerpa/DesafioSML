using Microsoft.EntityFrameworkCore;

namespace DesafioSML.Data.Seeding
{
    public class SeedingData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Customer customer = new Customer { CustomerId = 1, FirstName = "Facundo", LastName = "Zerpa", Address = "Av Pueyrredon 285" };

            modelBuilder.Entity<Customer>().HasData(customer);
        }
    }
}
