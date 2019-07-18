namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FamilyMember")]
    public partial class FamilyMember : TableHaveIdInt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FamilyMember()
        {
        }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int RelationId { get; set; }

        [Required]
        public int PersonalInfoId { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [Required]
        public int CareerTypeId { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual CareerType CareerType { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }

        public virtual RelationType RelationType { get; set; }
    }
}