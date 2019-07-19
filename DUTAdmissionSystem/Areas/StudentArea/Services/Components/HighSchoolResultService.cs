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
        public bool AddHighSchoolResult(HighSchoolResult result, int idUser)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag).Id;
            if(context.HighSchoolResults.FirstOrDefault(x => x.StudentId == studentId && x.HighSchoolYearId == result.HightSchoolYearId) != null)
            {
                return false;
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
            return true;
        }

        public bool UpdateHighSchoolResult(HighSchoolResult result, int idUser)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag).Id;
            context.HighSchoolResults.Where(x => x.StudentId == studentId && x.Id == result.Id && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.HighSchoolResult
            {
                HighSchoolYearId  = result.HightSchoolYearId,
                ConductTypeId     = result.ConductTypeId,
                LearningAbilityId = result.LearningAbilityId,
                GPAScore          = result.GPAScore
            });
            context.SaveChanges();
            return true;
        }
        public bool DeleteHighSchoolResult(int idUser, int highSchoolYearId)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser).Id;
            var student = context.HighSchoolResults.FirstOrDefault(x => x.StudentId == studentId && x.HighSchoolYearId == highSchoolYearId && !x.DelFlag);
            if(student == null)
            {
                return false;
            }
            student.DelFlag = true;
            context.SaveChanges();
            return true;
        }
    }
}