using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Database;
using System.Linq;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class StudentProfileService : IStudentProfileService
    {
        private DataContext context = new DataContext();
        public ProfileResponseDto GetStudentProfileByIdAccount(int id)
        {
            var account = context.Accounts.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            if (account == null)
            {
                return null;
            }
            return null;
        }
    }
}