namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Achievement")]
    public partial class Achievement : TableHaveIdInt
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int AchievementTypeId { get; set; }

        [Required]
        public int AchievementLevelId { get; set; }

        [Required]
        public int AchievementPrizeId { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public virtual AchievementPrize AchievementPrize { get; set; }

        public virtual AchievementType AchievementType { get; set; }

        public virtual AchievementLevel AchievementLevel { get; set; }

        public virtual Student Student { get; set; }
    }
}