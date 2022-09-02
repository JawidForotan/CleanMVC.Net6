using Microsoft.EntityFrameworkCore;

namespace SimpleMVC.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> products => Set<Product>();
        public DbSet<Message> messages => Set<Message>();
    }
}
