namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Permission")]
    public partial class Permission : TableHaveIdInt
    {
        [Required]
        public int AccountGroupId { get; set; }

        [Required]
        public int FunctionInScreenId { get; set; }

        [Required]
        public bool IsActived { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual FunctionInScreen FunctionInScreen { get; set; }
    }
}