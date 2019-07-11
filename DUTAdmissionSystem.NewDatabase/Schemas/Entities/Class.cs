namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Class")]
    public partial class Class : TableHaveIdInt
    {
        
        public Class()
        {
            Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int SchoolYear { get; set; }

        public virtual Department Department { get; set; }

        
        public virtual ICollection<Student> Students { get; set; }
    }
}