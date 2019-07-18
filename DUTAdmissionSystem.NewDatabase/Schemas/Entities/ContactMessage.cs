using DUTAdmissionSystem.NewDatabase.Schema.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    [Table("ContactMessage")]
    public class ContactMessage : TableHaveIdInt
    {
        [StringLength(50)]
        [Required]
        public string FullName { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(500)]
        [Required]
        public string Message { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}