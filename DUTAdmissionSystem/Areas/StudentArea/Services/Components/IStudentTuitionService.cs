using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public interface IStudentTuitionService
    {
       
        Profile GetProfile(int id);

        TuitionDetail GetTuitionDetail(int id);

        string UpdateAvatar(Avartar avatar, int id, string host);

        Profile SaveProfile(Profile profile);
    }
}
