using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenMyGarage.Entity.Entity.UserPrivileges
{
    public class Privilege
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public UserPrivilege UserPrivilege { get; set; }
    }
}
