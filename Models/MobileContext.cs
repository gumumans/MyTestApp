using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

public class MobileContext : DbContext
{
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    
    public MobileContext(DbContextOptions<MobileContext> options) : base(options) {}

    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}