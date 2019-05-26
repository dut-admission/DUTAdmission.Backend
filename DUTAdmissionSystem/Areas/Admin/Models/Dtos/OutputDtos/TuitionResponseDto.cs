using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class TuitionResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public double TuitionFee { get; set; }
        public string TotalTuition { get; set; }
        public bool IsPaid { get; set; }
        public Receipt Receipt { get; set; }
    }

    public class Receipt
    {
        public int Id { get; set; }
        public int CollectorUserId { get; set; }
        public int PayerUserId { get; set; }
        public double Money { get; set; }
        public string ReceiptNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CollectionDate { get; set; }
    }
}