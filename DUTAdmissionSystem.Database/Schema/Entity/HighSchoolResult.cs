namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HighSchoolResult")]
    public partial class HighSchoolResult : TableHaveIdInt
    {
        public int StudentId { get; set; }

        public int HightSchoolYearId { get; set; }

        public int ConductTypeId { get; set; }

        public int LearningAbilityId { get; set; }

        public double GPAScore { get; set; }

        public virtual ConductType ConductType { get; set; }

        public virtual HightSchoolYear HightSchoolYear { get; set; }

        public virtual LearningAbility LearningAbility { get; set; }

        public virtual Student Student { get; set; }
    }
}