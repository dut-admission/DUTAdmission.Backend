namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Account")]
    public partial class Account : TableHaveIdInt
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Avatar { get; set; }

        [Required]
        public int AccountGroupId { get; set; }

        [Required]
        public int UserInfoId { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}