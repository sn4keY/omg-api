using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OpenMyGarage.Entity.Entity.UserPrivileges
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Entity.UserPrivilege> Privileges { get; set; }
    }
}
