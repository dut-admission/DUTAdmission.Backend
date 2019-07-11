namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DocumentType")]
    public partial class DocumentType : TableHaveIdInt
    {
        
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        [Required]
        public bool IsRequired { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        
        public virtual ICollection<Document> Documents { get; set; }
    }
}