using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace PizzaPortal.Infrastructure.Context
{
    public class PizzaPortalContext : DbContext
    {
        
        public DbSet<Address> Address { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaTemplates> PizzaTemplates { get; set; }
        
        public DbSet<Image> Images { get; set; }
        
        public PizzaPortalContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.PizzaPortalApi.db");
                /*x => x.MigrationsAssembly("PizzaPortal"))*/;
        }
        
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaTemplates>()
                .HasMany(x => x.Ingredients)
                .WithOne(y => y.PizzaTemplates)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PizzaTemplates>()
                .HasMany(x => x.Images)
                .WithOne(y => y.PizzaTemplates)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
    
}