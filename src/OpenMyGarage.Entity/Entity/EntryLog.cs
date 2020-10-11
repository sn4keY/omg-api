using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenMyGarage.Entity.Entity
{
    public class EntryLog : EntityBase
    {
        [Required]
        public string Plate { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long EntryTime { get; set; }
    }
}
