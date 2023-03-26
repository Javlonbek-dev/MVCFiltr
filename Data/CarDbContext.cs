using Microsoft.EntityFrameworkCore;
using Task1.Models.Car;

namespace Task1.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Car> Cars { get; set; }
    }
}
