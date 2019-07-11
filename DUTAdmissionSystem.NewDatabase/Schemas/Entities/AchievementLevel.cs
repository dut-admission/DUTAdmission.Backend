namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AchievementLevel")]
    public partial class AchievementLevel : TableHaveIdInt
    {
        public AchievementLevel()
        {
            Achievements = new HashSet<Achievement>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}