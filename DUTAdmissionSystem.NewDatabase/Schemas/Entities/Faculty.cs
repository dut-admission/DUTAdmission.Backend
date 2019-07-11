namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faculty")]
    public partial class Faculty : TableHaveIdInt
    {
        
        public Faculty()
        {
            Departments = new HashSet<Department>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        public virtual ICollection<Department> Departments { get; set; }
    }
}
