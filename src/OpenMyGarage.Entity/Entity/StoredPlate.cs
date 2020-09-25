using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenMyGarage.Entity.Entity
{
    public class StoredPlate
    {
        [Key]
        [Required]
        public string Plate { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Nationality { get; set; }

        [Required]
        public string CarManufacturer { get; set; }

        public bool AutoOpen { get; set; }
    }
}
