﻿using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions
{
    public interface IEmployeeProfileService
    {
        EmployeeProfile GetEmployeeProfile(string token);
        void UpdateEmployeeProfile(UpdateEmployeeProfile updateEmployeeProfile, string token);
    }
}
