namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AchievementType")]
    public partial class AchievementType : TableHaveIdInt
    {
        public AchievementType()
        {
            Achievements = new HashSet<Achievement>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}