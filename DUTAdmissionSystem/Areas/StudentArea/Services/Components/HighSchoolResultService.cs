using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class HighSchoolResultService : IHighSchoolResultService
    {
        private DataContext context = new DataContext();

        public List<HighSchoolResult> GetHighSchoolResults(int idUser)
        {
            return context.UserInfoes.FirstOrDefault(x => x.Id == idUser && !x.DelFlag)
                .Students.FirstOrDefault(x => !x.DelFlag).HighSchoolResults.Where(x => !x.DelFlag).Select(x => new HighSchoolResult()
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
        public HighSchoolResult AddHighSchoolResult(HighSchoolResult result, int idUser)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag).Id;
            if(context.HighSchoolResults.FirstOrDefault(x => x.StudentId == studentId && x.HighSchoolYearId == result.HightSchoolYearId && !x.DelFlag) != null)
            {
                return null;
            }
            result.Id = context.HighSchoolResults.Max(x => x.Id) + 1;
            context.HighSchoolResults.Add(new NewDatabase.Schema.Entity.HighSchoolResult
            {
                StudentId         = studentId,
                HighSchoolYearId  = result.HightSchoolYearId,
                ConductTypeId     = result.ConductTypeId,
                LearningAbilityId = result.LearningAbilityId,
                GPAScore          = result.GPAScore
            });
            context.SaveChanges();
            return new HighSchoolResult()
            {
                Id                  = result.Id,
                ConductTypeId       = result.ConductTypeId,
                GPAScore            = result.GPAScore,
                HightSchoolYearId   = result.HightSchoolYearId,
                LearningAbilityId   = result.LearningAbilityId,
                ConductTypeName     = context.ConductTypes.FirstOrDefault(x => !x.DelFlag && x.Id == result.ConductTypeId).Level,
                HightSchoolYear     = context.HighSchoolYears.FirstOrDefault(x => !x.DelFlag && x.Id == result.HightSchoolYearId).Year,
                LearningAbilityName = context.LearningAbilities.FirstOrDefault(x => !x.DelFlag && x.Id == result.LearningAbilityId).Level
            };
        }

        public HighSchoolResult UpdateHighSchoolResult(HighSchoolResult result, int idUser)
        {
            context.HighSchoolResults.Where(x =>  x.Id == result.Id && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.HighSchoolResult
            {
                HighSchoolYearId  = result.HightSchoolYearId,
                ConductTypeId     = result.ConductTypeId,
                LearningAbilityId = result.LearningAbilityId,
                GPAScore          = result.GPAScore
            });
            context.SaveChanges();
            return new HighSchoolResult()
            {
                Id = result.Id,
                ConductTypeId = result.ConductTypeId,
                GPAScore = result.GPAScore,
                HightSchoolYearId = result.HightSchoolYearId,
                LearningAbilityId = result.LearningAbilityId,
                ConductTypeName = context.ConductTypes.FirstOrDefault(x => !x.DelFlag && x.Id == result.ConductTypeId).Level,
                HightSchoolYear = context.HighSchoolYears.FirstOrDefault(x => !x.DelFlag && x.Id == result.HightSchoolYearId).Year,
                LearningAbilityName = context.LearningAbilities.FirstOrDefault(x => !x.DelFlag && x.Id == result.LearningAbilityId).Level
            };  
        }
        public bool DeleteHighSchoolResult(int idUser, int highSchoolYearId)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser).Id;
            var result = context.HighSchoolResults.FirstOrDefault(x => x.StudentId == studentId && x.HighSchoolYearId == highSchoolYearId && !x.DelFlag);
            if(result == null)
            {
                return false;
            }
            result.DelFlag = true;
            context.SaveChanges();  
            return true;
        }
    }
}