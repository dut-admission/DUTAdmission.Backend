namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HightSchoolPosition")]
    public partial class HightSchoolPosition : TableHaveIdInt
    {
        public int StudentId { get; set; }

        public int PositionTypeId { get; set; }

        public virtual PositionType PositionType { get; set; }

        public virtual Student Student { get; set; }
    }
}