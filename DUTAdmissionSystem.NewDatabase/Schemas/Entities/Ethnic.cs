namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ethnic")]
    public partial class Ethnic : TableHaveIdInt
    {

        public Ethnic()
        {
            UserInfors = new HashSet<UserInfo>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<UserInfo> UserInfors { get; set; }
    }
}