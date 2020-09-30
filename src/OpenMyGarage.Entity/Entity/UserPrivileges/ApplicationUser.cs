using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMyGarage.Entity.Entity.UserPrivileges
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Privilege> Privileges { get; set; }
    }
}
