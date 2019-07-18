namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RelationType")]
    public partial class RelationType : TableHaveIdInt
    {
        
        public RelationType()
        {
            FamilyMembers = new HashSet<FamilyMember>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}