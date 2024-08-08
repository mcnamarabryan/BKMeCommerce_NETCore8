using BKMeCommerceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BKMeCommerceWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
