namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HighSchoolResult")]
    public partial class HighSchoolResult : TableHaveIdInt
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int HightSchoolYearId { get; set; }

        [Required]
        public int ConductTypeId { get; set; }

        [Required]
        public int LearningAbilityId { get; set; }

        [Required]
        public double GPAScore { get; set; }

        public virtual ConductType ConductType { get; set; }

        public virtual HightSchoolYear HightSchoolYear { get; set; }

        public virtual LearningAbility LearningAbility { get; set; }

        public virtual Student Student { get; set; }
    }
}