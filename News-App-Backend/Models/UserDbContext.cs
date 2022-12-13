using Microsoft.EntityFrameworkCore;

namespace News_App_Backend.Models
{
    public class UserDbContext : DbContext
    {
      //  public UserDbContext() { }
        public UserDbContext(DbContextOptions options) : base(options) 
        { 
            
        }
        public DbSet<User> Users { get; set; }
    }
}
