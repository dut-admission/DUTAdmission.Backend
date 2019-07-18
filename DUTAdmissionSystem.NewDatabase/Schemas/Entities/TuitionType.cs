using DUTAdmissionSystem.NewDatabase.Schema.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    [Table("TuitionType")]
    public class TuitionType : TableHaveIdInt
    {
        [Required]
        public double Money { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public int SchoolYear { get; set; }
    }
}