using Microsoft.EntityFrameworkCore;

namespace aplicatie.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Utilizator> Utilizatori1 { get; set; }
        public DbSet<Produs> Produse1 { get; set; }
        public DbSet<Comanda> Comanda1 { get; set; }
        public DbSet<DetaliiComanda> DetaliiComanda1 { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            // Constructor
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("NumeBazaDateInMemorie");
        }
    }
}
