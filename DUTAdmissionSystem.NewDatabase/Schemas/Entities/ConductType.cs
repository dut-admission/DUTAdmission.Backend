namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ConductType")]
    public partial class ConductType : TableHaveIdInt
    {
        
        public ConductType()
        {
            HighSchoolResults = new HashSet<HighSchoolResult>();
        }

        [Required]
        [StringLength(50)]
        public string Level { get; set; }

        
        public virtual ICollection<HighSchoolResult> HighSchoolResults { get; set; }
    }
}