namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;

    public partial class AdmissionNews : TableHaveIdInt
    {
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string Summary { get; set; }

        public string Content { get; set; }
    }
}