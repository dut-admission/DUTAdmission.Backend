namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CareerType")]
    public partial class CareerType : TableHaveIdInt
    {
        
        public CareerType()
        {
            FamilyMembers = new HashSet<FamilyMember>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}