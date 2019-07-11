namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;

    public partial class AdmissionNews : TableHaveIdInt
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(200)]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }
    }
}