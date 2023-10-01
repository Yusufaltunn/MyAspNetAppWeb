using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyAspNetAppWeb.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
 
        public DbSet<Product>Products  { get; set; }

        public void SaveChanges()
        {
        }

    
    }
}
