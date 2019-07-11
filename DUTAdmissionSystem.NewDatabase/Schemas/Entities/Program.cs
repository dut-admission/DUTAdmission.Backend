namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Program")]
    public partial class Program : TableHaveIdInt
    {
        
        public Program()
        {
            Departments = new HashSet<Department>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public double Fees { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}