namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonalInfo")]
    public partial class PersonalInfo : TableHaveIdInt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonalInfo()
        {
            FamilyMembers = new HashSet<FamilyMember>();
            Students = new HashSet<Student>();
        }

        [Required]
        public int EthnicId { get; set; }

        [Required]
        public int ReligionId { get; set; }

        [Required]
        public int NationalityId { get; set; }

        [Required]
        [StringLength(255)]
        public string PermanentResidence { get; set; }

        public virtual Ethnic Ethnic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }

        public virtual Nationality Nationality { get; set; }

        public virtual Religion Religion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}