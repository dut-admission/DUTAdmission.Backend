namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Nationality")]
    public partial class Nationality : TableHaveIdInt
    {
        
        public Nationality()
        {
            UserInfors = new HashSet<UserInfo>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<UserInfo> UserInfors { get; set; }
    }
}