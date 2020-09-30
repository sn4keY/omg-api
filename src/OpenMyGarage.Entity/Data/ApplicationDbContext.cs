using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenMyGarage.Entity.Entity;
using OpenMyGarage.Entity.Entity.UserPrivileges;

namespace OpenMyGarage.Entity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<EntryLog> EntryLogs { get; set; }

        public DbSet<StoredPlate> StoredPlates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
