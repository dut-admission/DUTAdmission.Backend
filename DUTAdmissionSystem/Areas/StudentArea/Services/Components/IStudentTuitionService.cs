﻿using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public interface IStudentTuitionService
    {
       
        Profile GetProfile(string token);

        TuitionDetail GetTuitionDetail(int id);
    }
}
