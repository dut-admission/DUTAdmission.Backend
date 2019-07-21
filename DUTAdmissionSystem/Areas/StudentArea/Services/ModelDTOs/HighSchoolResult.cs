using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs
{
    public class HighSchoolResult
    {
        public int Id { get; set; }
        public int HighSchoolYearId { get; set; }
        public int HighSchoolYear { get; set; }
        public int ConductTypeId { get; set; }
        public string ConductTypeName { get; set; }
        public int LearningAbilityId { get; set; }
        public string LearningAbilityName { get; set; }
        public double GPAScore { get; set; }
    }
}