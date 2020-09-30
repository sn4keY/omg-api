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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity.UserPrivilege>().HasKey(up => new { up.UserId, up.PrivilegeId });
            builder.Entity<Entity.UserPrivilege>()
                .HasOne(up => up.ApplicationUser)
                .WithMany(au => au.Privileges)
                .HasForeignKey(p => p.UserId);
            builder.Entity<Entity.UserPrivilege>()
                .HasOne(up => up.Privilege)
                .WithMany()
                .HasForeignKey(p => p.PrivilegeId);
        }
    }
}
