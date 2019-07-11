namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LearningAbility")]
    public partial class LearningAbility : TableHaveIdInt
    {
        
        public LearningAbility()
        {
            HighSchoolResults = new HashSet<HighSchoolResult>();
        }

        [Required]
        [StringLength(50)]
        public string Level { get; set; }

        [Required]
        public double StartingPoint { get; set; }

        [Required]
        public double EndingPoint { get; set; }

        
        public virtual ICollection<HighSchoolResult> HighSchoolResults { get; set; }
    }
}