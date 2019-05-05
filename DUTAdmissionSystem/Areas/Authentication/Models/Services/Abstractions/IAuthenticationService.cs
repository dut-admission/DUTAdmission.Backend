using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions
{
    public interface IAuthenticationService
    {
        LoginResponseDto Login(LoginDto dto);
    }
}