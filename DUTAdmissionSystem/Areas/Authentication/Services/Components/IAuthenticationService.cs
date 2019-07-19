using DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs;

namespace DUTAdmissionSystem.Areas.Authentication.Services.Components
{
    public interface IAuthenticationService
    {
        LoginResponseDto Login(LoginDto dto);

        bool ForgetPass(ForgetPassword input);

        int ChangePass(ChangePassword input,int id);
    }
}