namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LearningAbility")]
    public partial class LearningAbility : TableHaveIdInt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HighSchoolResult> HighSchoolResults { get; set; }
    }
}