using Microsoft.AspNetCore.Identity;
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

            #region Privileges
            builder.Entity<Privilege>().HasData(
                new Privilege() { ID = 1, UserPrivilege = Entity.UserPrivileges.UserPrivilege.OpenGate},
                new Privilege() { ID = 2, UserPrivilege = Entity.UserPrivileges.UserPrivilege.ManagePlates});

            builder.Entity<Entity.UserPrivilege>().HasKey(up => new { up.UserId, up.PrivilegeId });
            builder.Entity<Entity.UserPrivilege>()
                .HasOne(up => up.ApplicationUser)
                .WithMany(au => au.Privileges)
                .HasForeignKey(p => p.UserId);
            builder.Entity<Entity.UserPrivilege>()
                .HasOne(up => up.Privilege)
                .WithMany()
                .HasForeignKey(p => p.PrivilegeId);
            #endregion

            #region Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "RaspberryPi", NormalizedName = "RASPBERRYPI" },
                new IdentityRole { Id = "2", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "3", Name = "User", NormalizedName = "USER" });
            #endregion
        }
    }
}
