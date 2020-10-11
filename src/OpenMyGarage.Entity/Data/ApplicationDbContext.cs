using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenMyGarage.Entity.Entity;
using OpenMyGarage.Entity.Entity.UserPrivileges;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "RaspberryPi", NormalizedName = "RASPBERRYPI" },
                new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "3", Name = "User", NormalizedName = "USER" });
            #endregion

            #region Indexes
            builder.Entity<StoredPlate>()
                .HasIndex(p => p.Plate)
                .IsUnique();
            #endregion
        }
    }
}
