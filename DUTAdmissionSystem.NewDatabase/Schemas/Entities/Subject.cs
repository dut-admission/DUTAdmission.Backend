namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Subject")]
    public partial class Subject : TableHaveIdInt
    {
        
        public Subject()
        {
            UniversityExamResults = new HashSet<UniversityExamResult>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<UniversityExamResult> UniversityExamResults { get; set; }
    }
}