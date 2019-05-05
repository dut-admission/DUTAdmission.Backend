using DUTAdmissionSystem.Database.Schema.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTAdmissionSystem.Database.Schema.Entity
{
    [Table("YouthGroupInfo")]
    public class YouthGroupInfo : TableHaveIdInt
    {
        [Column(TypeName = "datetime2")]
        public DateTime DateOfJoiningYouthGroup { get; set; }

        [StringLength(255)]
        public string PlaceOfJoinYouthGroup { get; set; }

        public bool HavingBooksOfYouthGroup { get; set; }

        public bool HavingCardsOfYouthGroup { get; set; }
    }
}