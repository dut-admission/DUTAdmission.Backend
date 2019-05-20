using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos
{
    public class TuitionDetail
    {
        public List<TuitionType> TuitionTypes { get; set; }

        public double TuitionFee { get; set; }

        public double TotalOfFee { get; set; }
    }

    public class TuitionType {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public string Description { get; set; }
    }

}