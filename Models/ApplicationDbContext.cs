using Microsoft.EntityFrameworkCore;

namespace zoo_website.Models;

public class ApplicationDbContext : DbContext 
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
        public DbSet<Animal> Animals { get; set; }
        

}