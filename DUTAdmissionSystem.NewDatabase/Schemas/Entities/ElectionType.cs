namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ElectionType")]
    public partial class ElectionType : TableHaveIdInt
    {
        
        public ElectionType()
        {
            Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        public virtual ICollection<Student> Students { get; set; }
    }
}