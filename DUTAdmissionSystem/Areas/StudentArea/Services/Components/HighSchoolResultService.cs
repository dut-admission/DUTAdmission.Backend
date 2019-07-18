using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class HighSchoolResultService : IHighSchoolResultService
    {
        private DataContext context = new DataContext();

        public List<HighSchoolResult> GetHighSchoolResults(int idUser)
        {
            return context.UserInfoes.FirstOrDefault(x => x.Id == idUser && !x.DelFlag)
                .Students.FirstOrDefault(x => !x.DelFlag).HighSchoolResults.Select(x => new HighSchoolResult()
                {
                    Id = x.Id,
                    ConductTypeId = x.ConductTypeId,
                    GPAScore = x.GPAScore,
                    HightSchoolYearId = x.HighSchoolYearId,
                    LearningAbilityId = x.LearningAbilityId,
                    ConductTypeName = x.ConductType.Level,
                    HightSchoolYear = x.HighSchoolYear.Year,
                    LearningAbilityName = x.LearningAbility.Level
                }
               ).ToList();
        }
    }
}