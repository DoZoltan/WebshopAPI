using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL
{
    public class ShopContext : IdentityDbContext<User>
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartContent> CartContent { get; set; }
        public DbSet<OrderContent> OrderContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Cart)
            //    .WithOne(c => c.Owner)
            //    .HasForeignKey<ShoppingCart>(c => c.OwnerId);

            // A ModelBuilder-hez írt extension metódus meghívása
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
