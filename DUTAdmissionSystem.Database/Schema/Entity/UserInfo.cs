namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserInfo")]
    public partial class UserInfo : TableHaveIdInt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInfo()
        {
            Accounts = new HashSet<Account>();
            Students = new HashSet<Student>();
            ReceiptsForCollector = new HashSet<Receipt>();
            ReceiptsForPayer = new HashSet<Receipt>();

        }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string Avatar { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public int BirthInfoId { get; set; }

        [Required]
        public int IdentityId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }

        public virtual BirthInfo BirthInfo { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        public virtual IdentityInfo IdentityInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Receipt> ReceiptsForCollector { get; set; }

        public virtual ICollection<Receipt> ReceiptsForPayer { get; set; }

    }
}