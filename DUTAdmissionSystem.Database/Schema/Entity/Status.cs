using DUTAdmissionSystem.Database.Schema.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTAdmissionSystem.Database.Schema.Entity
{
    [Table("Status")]
    public class Status : TableHaveIdInt
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int StatusTypeId { get; set; }
        public virtual StatusType StatusType { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}