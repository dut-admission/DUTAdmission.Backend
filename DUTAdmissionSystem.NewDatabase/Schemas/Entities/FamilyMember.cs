namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FamilyMember")]
    public partial class FamilyMember : TableHaveIdInt
    {
        public FamilyMember()
        {
        }
        [Required]
        public int UserInfoId { get; set; }

        [Required]
        public int RelationId { get; set; }
        
        [Required]
        public int CareerTypeId { get; set; }
        
        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual CareerType CareerType { get; set; }

        public virtual RelationType RelationType { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}