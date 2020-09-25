using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenMyGarage.Entity.Entity;

namespace OpenMyGarage.Entity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<EntryLog> EntryLogs { get; set; }

        public DbSet<StoredPlate> StoredPlates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
