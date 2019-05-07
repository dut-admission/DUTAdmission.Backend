using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface IStudentProfileService
    {
        ProfileResponseDto GetStudentProfileByIdAccount(int id);
    }
}