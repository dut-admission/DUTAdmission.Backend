namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TalentType")]
    public partial class TalentType : TableHaveIdInt
    {
        
        public TalentType()
        {
            Talents = new HashSet<Talent>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<Talent> Talents { get; set; }
    }
}