using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options): DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    
    //override
    protected  void onModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }
}