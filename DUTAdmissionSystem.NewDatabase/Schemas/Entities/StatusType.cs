using DUTAdmissionSystem.NewDatabase.Schema.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    [Table("StatusType")]
    public class StatusType : TableHaveIdInt
    {
        public StatusType()
        {
            Statuses = new HashSet<Status>();
        }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}