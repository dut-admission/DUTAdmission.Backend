using DUTAdmissionSystem.Database.Schema.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTAdmissionSystem.Database.Schema.Entity
{
    [Table("YouthGroupInfo")]
    public class YouthGroupInfo : TableHaveIdInt
    {
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateOfJoiningYouthGroup { get; set; }

        [Required]
        [StringLength(255)]
        public string PlaceOfJoinYouthGroup { get; set; }

        [Required]
        public bool HavingBooksOfYouthGroup { get; set; }

        [Required]
        public bool HavingCardsOfYouthGroup { get; set; }
    }
}