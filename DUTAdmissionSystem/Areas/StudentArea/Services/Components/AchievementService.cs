using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class AchievementService : IAchievementService
    {
        private DataContext context = new DataContext();

        public List<Achievement> GetAchievements(int idUser)
        {
            return context.UserInfoes.FirstOrDefault(x => x.Id == idUser && !x.DelFlag)
                .Students.FirstOrDefault(x => !x.DelFlag).Achievements.Where(x => !x.DelFlag).Select(x => new Achievement()
                {
                    Id                   = x.Id,
                    AchievementLevelId   = x.AchievementLevelId,
                    AchievementLevelName = x.AchievementLevel.Name,
                    AchievementPrizeId   = x.AchievementPrizeId,
                    AchievementPrizeName = x.AchievementPrize.Name,
                    AchievementTypeId    = x.AchievementTypeId,
                    AchievementTypeName  = x.AchievementType.Name,
                    Description          = x.Description
                }
               ).ToList();
        }
        public Achievement AddAchievement(Achievement achievement, int idUser)
        {
            var studentId  = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag).Id;
            achievement.Id = context.Achievements.Max(x => x.Id) + 1;
            context.Achievements.Add(new NewDatabase.Schema.Entity.Achievement
            {
                StudentId          = studentId,
                AchievementLevelId = achievement.AchievementLevelId,
                AchievementPrizeId = achievement.AchievementPrizeId,
                AchievementTypeId  = achievement.AchievementTypeId,
                Description        = achievement.Description
            });
            context.SaveChanges();
            return new Achievement()
            {
                Id                   = achievement.Id,
                AchievementLevelId   = achievement.AchievementLevelId,
                AchievementLevelName = context.AchievementLevels.FirstOrDefault(x => !x.DelFlag && x.Id == achievement.AchievementLevelId).Name,
                AchievementPrizeId   = achievement.AchievementPrizeId,
                AchievementPrizeName = context.AchievementPrizes.FirstOrDefault(x => !x.DelFlag && x.Id == achievement.AchievementPrizeId).Name,
                AchievementTypeId    = achievement.AchievementTypeId,
                AchievementTypeName  = context.AchievementTypes.FirstOrDefault(x => !x.DelFlag && x.Id == achievement.AchievementTypeId).Name,
                Description          = achievement.Description
            };
        }

        public Achievement UpdateAchievement(Achievement achievement, int idUser)
        {
            context.Achievements.Where(x => x.Id == achievement.Id && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.Achievement
            {
                AchievementLevelId = achievement.AchievementLevelId,
                AchievementPrizeId = achievement.AchievementPrizeId,
                AchievementTypeId  = achievement.AchievementTypeId,
                Description        = achievement.Description
            });
            context.SaveChanges();
            return new Achievement()
            {
                Id                   = achievement.Id,
                AchievementLevelId   = achievement.AchievementLevelId,
                AchievementLevelName = context.AchievementLevels.FirstOrDefault(x => !x.DelFlag && x.Id == achievement.AchievementLevelId).Name,
                AchievementPrizeId   = achievement.AchievementPrizeId,
                AchievementPrizeName = context.AchievementPrizes.FirstOrDefault(x => !x.DelFlag && x.Id == achievement.AchievementPrizeId).Name,
                AchievementTypeId    = achievement.AchievementTypeId,
                AchievementTypeName  = context.AchievementTypes.FirstOrDefault(x => !x.DelFlag && x.Id == achievement.AchievementTypeId).Name,
                Description          = achievement.Description
            };
        }
        public bool DeleteAchievement(int idUser, int id)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser).Id;
            var result = context.Achievements.FirstOrDefault(x => x.StudentId == studentId && x.Id == id && !x.DelFlag);
            if (result == null)
            {
                return false;
            }
            result.DelFlag = true;
            context.SaveChanges();
            return true;
        }
    }
}