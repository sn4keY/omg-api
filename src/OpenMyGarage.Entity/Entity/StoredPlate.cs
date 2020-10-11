using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenMyGarage.Entity.Entity
{
    public class StoredPlate : EntityBase
    {
        [Required]
        public string Plate { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string Nationality { get; set; }

        [Required]
        public string CarManufacturer { get; set; }

        public bool AutoOpen { get; set; }
    }
}
