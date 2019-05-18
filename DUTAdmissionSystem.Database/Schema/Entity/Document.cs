namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Document")]
    public partial class Document : TableHaveIdInt
    {
        [Required]
        public int DocumentTypeId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        [StringLength(255)]
        public string ResponseMessage { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }


        public virtual DocumentType DocumentType { get; set; }

        public virtual Student Student { get; set; }

        public virtual Status Status { get; set; }


    }
}