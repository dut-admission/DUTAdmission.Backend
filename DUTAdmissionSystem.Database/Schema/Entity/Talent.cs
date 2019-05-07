namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Talent")]
    public partial class Talent : TableHaveIdInt
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int TalentTypeId { get; set; }

        public virtual Student Student { get; set; }

        public virtual TalentType TalentType { get; set; }
    }
}