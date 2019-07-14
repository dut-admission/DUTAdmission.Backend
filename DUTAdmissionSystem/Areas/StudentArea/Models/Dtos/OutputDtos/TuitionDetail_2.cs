using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.OutputDtos
{
    public class TuitionDetail_2
    {
        public List<TuitionType_2> TuitionTypes { get; set; }

        public double TuitionFee { get; set; }

        public double TotalOfFee { get; set; }
    }

    public class TuitionType_2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public string Description { get; set; }
        public int SchoolYear { get; set; }
    }
}