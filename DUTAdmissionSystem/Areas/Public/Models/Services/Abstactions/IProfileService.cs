using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstactions
{
    public interface IProfileService
    {
        string UpdatePassWord(UpdatePassword updatePassword);
    }
}
