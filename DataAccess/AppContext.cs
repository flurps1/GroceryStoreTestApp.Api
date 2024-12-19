using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options): DbContext(options)
{
    public DbSet<ProductsModel> Products { get; set; }
    
    //override
    protected  void onModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductsModel>().HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }
}