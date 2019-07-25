namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Document")]
    public partial class Document : TableHaveIdInt
    {
        [Required]
        public int DocumentTypeId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public bool IsSubmitted { get; set; }

        public int StatusId { get; set; }

        public string ResponseMessage { get; set; }

        public string Url { get; set; }

        public string FileName { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual Student Student { get; set; }

        public virtual Status Status { get; set; }


    }
}