namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CircumstanceType")]
    public partial class CircumstanceType : TableHaveIdInt
    {
        
        public CircumstanceType()
        {
            Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        public virtual ICollection<Student> Students { get; set; }
    }
}