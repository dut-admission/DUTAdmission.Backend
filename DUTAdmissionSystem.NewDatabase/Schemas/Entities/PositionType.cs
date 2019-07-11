namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PositionType")]
    public partial class PositionType : TableHaveIdInt
    {
        
        public PositionType()
        {
            HighSchoolPositions = new HashSet<HighSchoolPosition>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<HighSchoolPosition> HighSchoolPositions { get; set; }
    }
}