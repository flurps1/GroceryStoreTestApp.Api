using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options): DbContext(options)
{
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CartItemModel> CartItems { get; set; }
    public DbSet<UserModel> Users { get; set; }
    
    //override
    protected  void onModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>().HasKey(x => x.Id);
        modelBuilder.Entity<ProductModel>().Property(x => x.Name).HasMaxLength(50);
        base.OnModelCreating(modelBuilder);
    }
}