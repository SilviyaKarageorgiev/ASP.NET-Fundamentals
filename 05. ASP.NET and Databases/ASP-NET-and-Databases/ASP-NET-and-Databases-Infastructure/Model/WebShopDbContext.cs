using Microsoft.EntityFrameworkCore;

namespace ASP_NET_and_Databases_Infastructure.Model
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }
    }
}
