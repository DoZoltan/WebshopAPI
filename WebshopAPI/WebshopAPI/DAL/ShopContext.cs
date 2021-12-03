using Microsoft.EntityFrameworkCore;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // A ModelBuilder-hez írt extension metódus meghívása
            modelbuilder.Seed();
        }
    }
}
