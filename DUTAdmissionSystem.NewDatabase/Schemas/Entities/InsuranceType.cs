namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("InsuranceType")]
    public partial class InsuranceType : TableHaveIdInt
    {
        
        public InsuranceType()
        {
            Insurances = new HashSet<Insurance>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Required]
        public double Fees { get; set; }

        
        public virtual ICollection<Insurance> Insurances { get; set; }
    }
}