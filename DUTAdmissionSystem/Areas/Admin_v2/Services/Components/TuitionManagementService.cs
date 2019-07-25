using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public class TuitionManagementService : ITuitionManagementService
    {

        private readonly DataContext context = new DataContext();

        public List<TutionInformation> UpdateTutionInformation(TutionInformation tutionInfor)
        {

        }
    }
}