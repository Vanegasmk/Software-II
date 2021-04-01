using Microsoft.EntityFrameworkCore;

namespace SoftwareII.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        
    }
}