namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Account")]
    public partial class Account : TableHaveIdInt
    {
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Token { get; set; }

        public int AccountGroupId { get; set; }

        public int UserInfoId { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}