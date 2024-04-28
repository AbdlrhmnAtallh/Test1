using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrainBox.Models
{
    public class BrainBoxDbContext : IdentityDbContext
    {
        public BrainBoxDbContext() { }
        public BrainBoxDbContext(DbContextOptions<BrainBoxDbContext> options) { }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                    Initial Catalog=BrainBoxApplication;
                    Integrated Security=SSPI;
                    TrustServerCertificate=True;"
            );
        }
    }
}
