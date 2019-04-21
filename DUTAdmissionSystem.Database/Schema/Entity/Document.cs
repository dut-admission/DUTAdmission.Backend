namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Document")]
    public partial class Document : TableHaveIdInt
    {
        public int DocumentTypeId { get; set; }

        public int StudentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public bool IsValid { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual Student Student { get; set; }
    }
}