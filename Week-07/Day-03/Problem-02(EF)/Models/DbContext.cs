using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Creatings atbles for Db
        public DbSet<Movies> Movies { get; set; }
    }
}
