using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface IStudentProfileService
    {
        ProfileResponseDto GetStudentProfileByIdAccount(string token);
        bool UpdatePass(UpdatePassword updatePassword,string token);
        LibrariesOfProFile GetLibrariesOfProFile();

        void UpdateAddAchievement(Achievement achievement, string token);
        void UpdateAddFamilyMember(FamilyMember FamilyMember, string token);
        void UpdateAddHighSchoolResult(HighSchoolResult HighSchoolResult, string token);
        bool DeletionObject(DeletionObject deletionObject, string token);


    }
}