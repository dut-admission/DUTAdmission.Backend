using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs
{
    public class TutionInformation
    {
        public int IdStudent { get; set; }
        public bool IsPaid { get; set; }
        public decimal Money { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}