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
            Families = new HashSet<Family>();
        }

        [Required]
        public int RelationId { get; set; }

        [Required]
        public int PersonalInfo { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [Required]
        public int CareerTypeId { get; set; }

        [Required]
        public int ContactId { get; set; }

        public virtual CareerType CareerType { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Families { get; set; }

        public virtual PersonalInfo PersonalInfo1 { get; set; }

        public virtual RelationType RelationType { get; set; }
    }
}