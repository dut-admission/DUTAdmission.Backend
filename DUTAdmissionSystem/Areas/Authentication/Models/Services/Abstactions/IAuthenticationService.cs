using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstactions
{
    public interface IAuthenticationService
    {
        LoginResponseDto Login(LoginDto dto);

    }
}
