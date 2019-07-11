namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserInfo")]
    public partial class UserInfo : TableHaveIdInt
    {

        public UserInfo()
        {
            Accounts = new HashSet<Account>();
            Students = new HashSet<Student>();
            FamilyMembers = new HashSet<FamilyMember>();
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
        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(255)]
        public string PlaceOfBirth { get; set; }

        [Required]
        public bool Sex { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string IdentityNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfIssue { get; set; }

        [StringLength(255)]
        public string PlaceOfIssue { get; set; }

        [StringLength(255)]
        public string PermanentResidence { get; set; }

        [Required]
        public int EthnicId { get; set; }

        [Required]
        public int ReligionId { get; set; }

        [Required]
        public int NationalityId { get; set; }

        public int? StudentUserInfoId { get; set; }

        public virtual Ethnic Ethnic { get; set; }

        public virtual Nationality Nationality { get; set; }

        public virtual Religion Religion { get; set; }

        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Receipt> ReceiptsForCollector { get; set; }

        public virtual ICollection<Receipt> ReceiptsForPayer { get; set; }
    }
}