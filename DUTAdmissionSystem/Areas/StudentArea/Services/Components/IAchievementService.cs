using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public interface IAchievementService
    {
        List<Achievement> GetAchievements(int idUser);
        bool AddAchievement(Achievement result, int idUser);
        bool UpdateAchievement(Achievement result, int idUser);
        bool DeleteAchievement(int idUser, int highSchoolYearId);
    }
}
