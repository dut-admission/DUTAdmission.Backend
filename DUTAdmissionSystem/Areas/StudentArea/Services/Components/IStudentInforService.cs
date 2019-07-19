using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public interface IStudentInforService
    {
       
        Profile GetProfile(int id);

        string UpdateAvatar(Avatar avatar, int id, string host);


        Profile SaveProfile(Profile profile, int id);
    }
}
