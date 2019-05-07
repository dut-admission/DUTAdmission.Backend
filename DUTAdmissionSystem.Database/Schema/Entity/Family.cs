namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Family")]
    public partial class Family : TableHaveIdInt
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int MemberId { get; set; }

        public virtual FamilyMember FamilyMember { get; set; }

        public virtual Student Student { get; set; }
    }
}