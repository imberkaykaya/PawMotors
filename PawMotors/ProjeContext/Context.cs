using Microsoft.EntityFrameworkCore;
using PawMotors.Entity;

namespace PawMotors.ProjeContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BERKAY\\SQLEXPRESS;database=PawMotorsDB;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
