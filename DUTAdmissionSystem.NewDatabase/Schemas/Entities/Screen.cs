namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Screen")]
    public partial class Screen : TableHaveIdInt
    {
        
        public Screen()
        {
            FunctionInScreens = new HashSet<FunctionInScreen>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<FunctionInScreen> FunctionInScreens { get; set; }
    }
}