using OpenMyGarage.Entity.Entity.UserPrivileges;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMyGarage.Entity.Entity
{
    public class UserPrivilege
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }
    }
}
