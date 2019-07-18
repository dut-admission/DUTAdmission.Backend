namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Insurance")]
    public partial class Insurance : TableHaveIdInt
    {
        [Required]
        public int InsuranceTypeId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual Student Student { get; set; }
    }
}