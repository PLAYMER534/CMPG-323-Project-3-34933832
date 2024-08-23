using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Models; 

namespace TelemetryPortal_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Correctly define the DbSet for Projects
        public DbSet<Project> Projects { get; set; }

        // If you have a Clients table, you might also define it like this:
        public DbSet<Client> Clients { get; set; }
    }
}

