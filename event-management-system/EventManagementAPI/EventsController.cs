using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Data // Adjust this namespace based on your project structure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
