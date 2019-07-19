using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs
{
    public class Achievement
    {
        public int Id                      { get; set; }
        public int AchievementTypeId       { get; set; }
        public string AchievementTypeName  { get; set; }
        public int AchievementLevelId      { get; set; }
        public string AchievementLevelName { get; set; }
        public int AchievementPrizeId      { get; set; }
        public string AchievementPrizeName { get; set; }
        public string Description          { get; set; }
    }
}