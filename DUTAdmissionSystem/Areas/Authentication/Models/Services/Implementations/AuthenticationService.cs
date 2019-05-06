using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System.Linq;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext db = new DataContext();

        public LoginResponseDto Login(LoginDto dto)
        {
            var result = new LoginResponseDto();

            dto.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(dto.Password));

            var accountFromDb = db.Accounts.FirstOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password && !x.DelFlag);

            if (accountFromDb == null)
            {
                return null;
            }

            var user = db.UserInfoes.FirstOrDefault(u => u.Id == accountFromDb.UserInfoId && !u.DelFlag);
            if (user != null)
            {
                result.User = new UserResponseDto(user, accountFromDb.UserName);
            }

            var group = db.AccountGroups.FirstOrDefault(g => g.Id == accountFromDb.AccountGroupId && !g.DelFlag);
            if (group != null)
            {
                result.Group = new GroupResponseDto
                {
                    Id = group.Id,
                    Name = group.Name
                };
            }

            db.SaveChanges();

            return result;
        }
    }
}