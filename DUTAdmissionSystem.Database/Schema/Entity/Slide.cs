namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Slide")]
    public partial class Slide : TableHaveIdInt
    {
        [StringLength(255)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsShowing { get; set; }

        [StringLength(255)]
        public string Url { get; set; }
    }
}