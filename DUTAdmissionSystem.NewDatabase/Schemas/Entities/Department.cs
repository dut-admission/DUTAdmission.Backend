namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Department")]
    public partial class Department : TableHaveIdInt
    {
        
        public Department()
        {
            Classes = new HashSet<Class>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string DepartmentCode { get; set; }

        [Required]
        public int FacultyId { get; set; }

        public int ProgramId { get; set; }

        public virtual Program Program { get; set; }


        
        public virtual ICollection<Class> Classes { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}