﻿using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public interface ITuitionManagementService
    {
        bool UpdateTutionInformation(TutionInformation tutionInfor, int idUser);
    }
}
