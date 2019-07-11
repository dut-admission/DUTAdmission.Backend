namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FunctionInScreen")]
    public partial class FunctionInScreen : TableHaveIdInt
    {
        
        public FunctionInScreen()
        {
            Permissions = new HashSet<Permission>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int ScreenId { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(50)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionName { get; set; }

        public bool IsToViewIndex { get; set; }

        public virtual Screen Screen { get; set; }

        
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}