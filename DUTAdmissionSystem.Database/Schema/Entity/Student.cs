namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public partial class Student : TableHaveIdInt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Achievements = new HashSet<Achievement>();
            Documents = new HashSet<Document>();
            Families = new HashSet<Family>();
            HighSchoolResults = new HashSet<HighSchoolResult>();
            HightSchoolPositions = new HashSet<HightSchoolPosition>();
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
        public int PersonalInfoId { get; set; }

        [Required]
        public int CircumstanceTypeId { get; set; }

        [Required]
        public int EnrollmentAreaId { get; set; }

        [Required]
        public int ElectionTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string HightSchoolName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Achievement> Achievements { get; set; }

        public virtual CircumstanceType CircumstanceType { get; set; }

        public virtual Class Class { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }

        public virtual ElectionType ElectionType { get; set; }

        public virtual EnrollmentArea EnrollmentArea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Families { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HighSchoolResult> HighSchoolResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HightSchoolPosition> HightSchoolPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Insurance> Insurances { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        public int? YouthGroupInfoId { get; set; }

        public virtual YouthGroupInfo YouthGroupInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Talent> Talents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UniversityExamResult> UniversityExamResults { get; set; }
    }
}