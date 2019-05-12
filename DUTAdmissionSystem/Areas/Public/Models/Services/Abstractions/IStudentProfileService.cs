using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface IStudentProfileService
    {
        ProfileResponseDto GetStudentProfileByIdAccount(int id);
        void UpdatePass(UpdatePassword updatePassword);
    }
}