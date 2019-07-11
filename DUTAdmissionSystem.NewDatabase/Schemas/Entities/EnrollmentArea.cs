namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EnrollmentArea")]
    public partial class EnrollmentArea : TableHaveIdInt
    {
        
        public EnrollmentArea()
        {
            Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public double BonusingPoint { get; set; }

        
        public virtual ICollection<Student> Students { get; set; }
    }
}