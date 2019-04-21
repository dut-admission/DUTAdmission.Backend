namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Insurance")]
    public partial class Insurance : TableHaveIdInt
    {
        public int InsuranceTypeId { get; set; }

        public int StudentId { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual Student Student { get; set; }
    }
}