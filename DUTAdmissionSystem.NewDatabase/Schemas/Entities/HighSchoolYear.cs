namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HighSchoolYear")]
    public partial class HighSchoolYear : TableHaveIdInt
    {
        
        public HighSchoolYear()
        {
            HighSchoolResults = new HashSet<HighSchoolResult>();
        }

        [Required]
        public int Year { get; set; }

        
        public virtual ICollection<HighSchoolResult> HighSchoolResults { get; set; }
    }
}
