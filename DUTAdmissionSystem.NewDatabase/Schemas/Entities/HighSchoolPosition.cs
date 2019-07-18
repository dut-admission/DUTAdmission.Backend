namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HighSchoolPosition")]
    public partial class HighSchoolPosition : TableHaveIdInt
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int PositionTypeId { get; set; }

        public virtual PositionType PositionType { get; set; }

        public virtual Student Student { get; set; }
    }
}