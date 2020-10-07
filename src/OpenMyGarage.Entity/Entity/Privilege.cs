using System.ComponentModel.DataAnnotations;

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
