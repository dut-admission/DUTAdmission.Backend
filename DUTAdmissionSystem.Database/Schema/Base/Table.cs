using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTAdmissionSystem.Database.Schema.Base
{
    public abstract class Table
    {
        public DateTime? CreatedAt { set; get; }

        public int CreatedBy { set; get; } = 0;

        public DateTime? UpdatedAt { set; get; }

        public int? UpdatedBy { set; get; }

        public bool DelFlag { set; get; } = false;
    }

    public abstract class TableHaveIdInt : Table
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; } = 0;
    }
}