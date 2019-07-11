namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public partial class Student : TableHaveIdInt
    {

        public Student()
        {
            Achievements = new HashSet<Achievement>();
            Documents = new HashSet<Document>();
            FamilyMembers = new HashSet<FamilyMember>();
            HighSchoolResults = new HashSet<HighSchoolResult>();
            HighSchoolPositions = new HashSet<HighSchoolPosition>();
            Insurances = new HashSet<Insurance>();
            Talents = new HashSet<Talent>();
            UniversityExamResults = new HashSet<UniversityExamResult>();
        }

        [Required]
        [StringLength(50)]
        public string IdentificationNumber { get; set; }

        [Required]
        public int UserInfoId { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int CircumstanceTypeId { get; set; }

        [Required]
        public int EnrollmentAreaId { get; set; }

        [Required]
        public int ElectionTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string HighSchoolName { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateOfJoiningYouthGroup { get; set; }

        [StringLength(255)]
        public string PlaceOfJoinYouthGroup { get; set; }

        [Required]
        public bool HavingBooksOfYouthGroup { get; set; }

        [Required]
        public bool HavingCardsOfYouthGroup { get; set; }

        public virtual CircumstanceType CircumstanceType { get; set; }

        public virtual Class Class { get; set; }

        public virtual ElectionType ElectionType { get; set; }

        public virtual EnrollmentArea EnrollmentArea { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }

        public virtual ICollection<HighSchoolResult> HighSchoolResults { get; set; }

        public virtual ICollection<HighSchoolPosition> HighSchoolPositions { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }

        public virtual ICollection<Talent> Talents { get; set; }

        public virtual ICollection<UniversityExamResult> UniversityExamResults { get; set; }
    }
}