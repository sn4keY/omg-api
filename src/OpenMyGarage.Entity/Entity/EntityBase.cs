using System.ComponentModel.DataAnnotations;

namespace OpenMyGarage.Entity.Entity
{
    public class EntityBase
    {
        [Key]
        public int ID { get; set; }
    }
}
